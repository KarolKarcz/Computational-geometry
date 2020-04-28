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
        string imgSrc;
        List<Point> nodes;
        List<Point> points;
        BitmapImage bitMap;
        int tolerance = 5;
        byte[] pixels;
        Node rootNode;
        PixelColor[,] result;
        public PictureView()
        {
            InitializeComponent();

            nodes = new List<Point>();
            points = new List<Point>();
            bitMap = new BitmapImage();
        }

        //----------------------------------------------------------------------Click methods----------------------------------------------------------------------//

        private void GENERATE_Click(object sender, RoutedEventArgs e)
        {
            constructQT();
        }

        private void fileLoad_Click(object sender, RoutedEventArgs e)
        {
            Image image = new Image();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            if (ofd.ShowDialog() == true)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(ofd.FileName);
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.UriSource = new Uri(fileInfo.FullName, UriKind.Relative);
                imgSrc = fileInfo.FullName;
                src.EndInit();
                image.Source = src;
                image.Height = src.PixelHeight;
                image.Width = src.PixelWidth;
                Cnva.Children.Add(image);
                int zindex = Cnva.Children.Count;
                Canvas.SetZIndex(image, zindex);
                Canvas.SetLeft(image, 0);
                Canvas.SetTop(image, 0);

            }

            analyze();

            GENERATE.IsEnabled = true;
     
        }

        //----------------------------------------------------------------------Validation----------------------------------------------------------------------//

        //----------------------------------------------------------------------Bitmap Operations----------------------------------------------------------------------//

        private void analyze()
        {
            pixels = getBitmap();
            write();
        }

        private byte[] getBitmap()
        {
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(imgSrc, UriKind.Relative);
            bitMap.EndInit();

            result = new PixelColor[bitMap.PixelWidth, bitMap.PixelHeight];

            int stride = (int)bitMap.PixelWidth * (bitMap.Format.BitsPerPixel / 8);
            byte[] pixels = new byte[(int)bitMap.PixelHeight * stride * 4];

            bitMap.CopyPixels(pixels, stride * 4, 0);
            CopyPixels(bitMap, result, stride, 0);

            write(result);

            return pixels;
        }

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

        private void readImage()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        void write()
        {
            int row = 0;
            int inc = 0;
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, $"out.txt")))
            {

                for (int i = 0; i < pixels.Length; i+=4)
                {
                    outputFile.WriteLine($"i:{i/4} || row:{row} ||column:{inc} ||R {pixels[i]}||G {pixels[i+1]}||B {pixels[i+2]}||A {pixels[i + 3]}");
                    inc++;

                    if (inc == bitMap.PixelHeight)
                    {
                        row++;
                        inc = 0;
                    }
                }
            }
        }

        void write(PixelColor[,] result)
        {
            int row = 0;
            int inc = 0;
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, $"zxc.txt")))
            {

                for (int i = 0; i < bitMap.PixelWidth; i++)
                {
                    for (int j = 0; j < bitMap.PixelHeight; j++)
                    {
                        outputFile.WriteLine($"i:{i} || j:{j} ||RGBA {result[i,j].Red} ||{result[i, j].Green} ||{result[i, j].Blue} ||{result[i, j].Alpha} ||");
                    }
                }
            }
        }
        //----------------------------------------------------------------------QuadTree----------------------------------------------------------------------//

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

        Rect drawRectangle(Point pointStart,int width,int height)
        {
            Path myPath2 = new Path();
            myPath2.Stroke = Brushes.Red;
            myPath2.StrokeThickness = 1;

            Rect myRect = new Rect();
            myRect.Size = new Size(width, height);
            myRect.Location = pointStart;
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = myRect;

            GeometryGroup myGeometryGroup2 = new GeometryGroup();
            myGeometryGroup2.Children.Add(myRectangleGeometry);

            myPath2.Data = myGeometryGroup2;

            Cnva.Children.Add(myPath2);
            Canvas.SetZIndex(myPath2, 2);
            //Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, pointStart.X + 10);
            //Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, pointStart.Y + 10);

            return myRect;
        }

        void constructQT()
        {
            int width = (int)bitMap.PixelWidth;
            int height = (int)bitMap.PixelHeight;

            Rect myRect = new Rect();
            myRect.Size = new Size(width, height);
            myRect.Location = new Point(0,0);

            rootNode = new Node(myRect, null, null, null, null);

            subdivide(rootNode);
        }
    }
}
