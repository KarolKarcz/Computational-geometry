using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using Microsoft.Win32;
using MeshGO.Models;
using Path = System.Windows.Shapes.Path;

namespace MeshGO.Views
{
    public partial class PictureView : UserControl
    {
        /// <summary>
        /// Variables and data containers that are available in entire view
        /// </summary>
        string imgSrc;
        int tolerance = 5;
        BitmapImage bitMap;
        byte[] pixels;
        PixelColor[,] result;
        List<Node> nodes;
        
        public PictureView()
        {
            InitializeComponent();

            nodes = new List<Node>();
            bitMap = new BitmapImage();
        }

        //----------------------------------------------------------------------Click methods----------------------------------------------------------------------//
        /// <summary>
        /// Function called after clicking GEN QUAD TREE button
        /// </summary>
        private void GENERATE_Click(object sender, RoutedEventArgs e)
        {
            constructQT();
        }
        /// <summary>
        /// Function called after clicking LOAD IMAGE button
        /// Create path to file and display Image
        /// </summary>
        private void fileLoad_Click(object sender, RoutedEventArgs e)
        {
            Cnva.Children.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";

            if (ofd.ShowDialog() == true)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(ofd.FileName);
                imgSrc = fileInfo.FullName;

                Image image = Helpers.processImage.image(fileInfo);

                Cnva.Children.Add(image);

                Canvas.SetZIndex(image, 0);
                Canvas.SetLeft(image, 0);
                Canvas.SetTop(image, 0);
            }

            // function that generates bitmap
            getBitmap();

            GENERATE.IsEnabled = true;
     
        }
        //----------------------------------------------------------------------Bitmap Operations----------------------------------------------------------------------//

        /// <summary>
        /// Function that read bytes from image which are later used for QuadTree generation
        /// </summary>
        private void getBitmap()
        {
            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(imgSrc, UriKind.Relative);
            bitMap.EndInit();

            result = new PixelColor[bitMap.PixelWidth, bitMap.PixelHeight];

            int stride = (int)bitMap.PixelWidth * (bitMap.Format.BitsPerPixel / 8);

            CopyPixels(bitMap, result, stride, 0);
        
            //write(result);
        }

        /// <summary>
        /// Function that fill Array with RGBA data
        /// </summary>
        /// <param name="source">Image we process</param>
        /// <param name="pixels">Array of pixels to which we save data</param>
        public void CopyPixels(BitmapSource source, PixelColor[,] pixels, int stride, int offset)
        {
            var height = source.PixelHeight;
            var width = source.PixelWidth;
            var pixelBytes = new byte[height * width * 4];
            source.CopyPixels(pixelBytes, stride, 0);
            int y0 = offset / width;
            int x0 = offset - width * y0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    pixels[x + x0, y + y0] = new PixelColor
                    {
                        Blue = pixelBytes[(y * width + x) * 4 + 0],
                        Green = pixelBytes[(y * width + x) * 4 + 1],
                        Red = pixelBytes[(y * width + x) * 4 + 2],
                        Alpha = pixelBytes[(y * width + x) * 4 + 3],
                    };
        }

        //----------------------------------------------------------------------File operation----------------------------------------------------------------------//

        /// <summary>
        /// Function that allow to easly look into each Pixel RGBA data
        /// Text file is easiest form of containing this data
        /// Usage significantly slows program
        /// </summary>
        /// <param name="result">Array with each Pixel RGBA information</param>
        void write(PixelColor[,] result)
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "pixelInfo.txt".
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, $"pixelInfo.txt")))
            {
                for (int i = 0; i < bitMap.PixelWidth; i++)
                {
                    for (int j = 0; j < bitMap.PixelHeight; j++)
                    {
                        outputFile.WriteLine($"i:{i} ||j:{j} ||R {result[i,j].Red} ||G {result[i, j].Green} ||B {result[i, j].Blue} ||A {result[i, j].Alpha}");
                    }
                }
            }
        }
        //----------------------------------------------------------------------QuadTree----------------------------------------------------------------------//
        /// <summary>
        /// Function that checks every rectangle 
        /// Checks if it has white and black pixels
        /// </summary>
        /// <param name="rect">Rectangle which function check</param>
        /// <returns>Information whether both colors are found</returns>
        Boolean checkFill(Rect rect)
        {
            Boolean mixed = false;
            Boolean isBlack = false;
            Boolean isWhite = false;

            for (int wi = (int)rect.X; wi < ((int)rect.X + rect.Width); wi++)
            {
                for (int hi = (int)rect.Y; hi < ((int)rect.Y + rect.Height); hi++)
                {

                    if (result[wi, hi].Red == 0 && result[wi, hi].Green == 0 && result[wi, hi].Red == 0)
                        isBlack = true;

                    if (result[wi, hi].Red == 255 && result[wi, hi].Green == 255 && result[wi, hi].Red == 255)
                        isWhite = true;

                    if (isBlack && isWhite)
                        mixed = true;
                }
            }

            return mixed;

        }

        /// <summary>
        /// Recursive function that creates new rectangles
        /// </summary>
        /// <param name="root"></param>
        void subdivide(Node root)
        {
            if (checkFill(root.rectangle))
            {
                int width = (int)root.rectangle.Width / 2;
                int height = (int)root.rectangle.Height / 2;

                if (width > tolerance && height > tolerance)
                {
                    Node n1 = new Node(drawRectangle(new Point(root.rectangle.X, root.rectangle.Y), width, height), null, null, null, null);
                    Node n2 = new Node(drawRectangle(new Point(root.rectangle.X + width, root.rectangle.Y), width, height), null, null, null, null);
                    Node n3 = new Node(drawRectangle(new Point(root.rectangle.X, root.rectangle.Y + height), width, height), null, null, null, null);
                    Node n4 = new Node(drawRectangle(new Point(root.rectangle.X + width, root.rectangle.Y + height), width, height), null, null, null, null);

                    root.n1 = n1;
                    root.n2 = n2;
                    root.n3 = n3;
                    root.n4 = n4;

                    subdivide(n1);
                    subdivide(n2);
                    subdivide(n3);
                    subdivide(n4);
                }
            }
        }

        /// <summary>
        /// Function that creates a rectangle and adds it to the canvas
        /// </summary>
        /// <param name="pointStart">Rectangle starating point</param>
        /// <param name="width">How width the rectangle will be</param>
        /// <param name="height">how high will rectangle be</param>
        /// <returns>Created rectangle</returns>
        Rect drawRectangle(Point pointStart,int width,int height)
        {
            Rect rect = Helpers.createShapes.createRectangle(pointStart ,width ,height);
            Path myPath2 = Helpers.createShapes.createPath(rect);

            Cnva.Children.Add(myPath2);
            Canvas.SetZIndex(myPath2, 2);

            return rect;
        }

        /// <summary>
        /// First function that start QuadTree creation process
        /// </summary>
        void constructQT()
        {
            int width = (int)bitMap.PixelWidth;
            int height = (int)bitMap.PixelHeight;

            Rect myRect = new Rect();
            myRect.Size = new Size(width, height);
            myRect.Location = new Point(0,0);

            Node rootNode = new Node(myRect, null, null, null, null);

            subdivide(rootNode);
        }
    }
}
