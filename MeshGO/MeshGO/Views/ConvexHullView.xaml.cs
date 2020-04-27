using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

namespace MeshGO.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ConvexHullView.xaml
    /// </summary>
    public partial class ConvexHullView : UserControl
    {
        int count;
        int width;
        int height;
        Point[] childArray;
        bool generated;
        Point[] hullPointArray;

        public ConvexHullView()
        {
            InitializeComponent();

            width = (int)Cnva.Width;
            height = (int)Cnva.Height;

            generated = false;
        }

        //----------------------------------------------------------------------Generate methods----------------------------------------------------------------------//

        /// <summary>
        /// Function that generates set of random points
        /// </summary>
        void generateStructure()
        {
            Random rnd = new Random();

            double x, y;

            for (int i = 0; i < count; i++)
            {
                x = rnd.Next(0, width);
                y = rnd.Next(0, height);

                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

                Ellipse ellipse = new Ellipse();

                ellipse.Height = 8;
                ellipse.Width = 8;
                ellipse.StrokeThickness = 5;
                ellipse.Stroke = Brushes.Black;

                Cnva.Children.Add(ellipse);
                Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, y);
                Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.LeftProperty, x);

                childArray[i] = new Point(x, y);
            }
        }

        /// <summary>
        /// Function that draw points read from file
        /// </summary>
        void generateFileStructure()
        {
            foreach (Point item in childArray)
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

                Ellipse ellipse = new Ellipse();

                ellipse.Height = 8;
                ellipse.Width = 8;
                ellipse.StrokeThickness = 5;
                ellipse.Stroke = Brushes.Black;

                Cnva.Children.Add(ellipse);
                Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, item.Y);
                Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.LeftProperty, item.X);
            }
        }

        /// <summary>
        /// Function that draws Convex Hull lines
        /// </summary>
        /// <param name="points">set of Convex Hull points</param>
        void generateConvexHull(IList<Point> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                createLine(points[i], points[i + 1]);
            }

            createLine(points[0], points[points.Count - 1]);
        }

        /// <summary>
        /// Function used to draw line between 2 points
        /// </summary>
        void createLine(Point point1, Point point2)
        {
            Line line = new Line();

            //Brush color
            line.Stroke = System.Windows.Media.Brushes.Black;

            //Point positions
            line.X1 = point1.X + 4;
            line.X2 = point2.X + 4;
            line.Y1 = point1.Y + 4;
            line.Y2 = point2.Y + 4;

            //Line thickness
            line.StrokeThickness = 1;

            Cnva.Children.Add(line);
        }

        //----------------------------------------------------------------------Click methods----------------------------------------------------------------------//

        /// <summary>
        /// Function called after clicking CONVEX HULL button
        /// </summary>
        void GENERATE_Click(object sender, RoutedEventArgs e)
        {
            generated = true;
            Cnva.Children.Clear();
            count = int.Parse(TextBox1.Text);
            childArray = new Point[count];

            generateStructure();

            List<Point> IchildArray = new List<Point>();

            foreach (Point item in childArray)
            {
                IchildArray.Add(item);
            }

            IList<Point> IhullPointArray = hullPointArray;

            IhullPointArray = GetConvexHull(IchildArray);

            generateConvexHull(IhullPointArray);
        }

        /// <summary>
        /// Function called after clicking LOAD FILE button
        /// </summary>
        void fileLoad_Click(object sender, RoutedEventArgs e)
        {
            Cnva.Children.Clear();
            load();

        }

        /// <summary>
        /// Function called after clicking CREATE FILE button
        /// </summary>
        void fileGenerate_Click(object sender, RoutedEventArgs e)
        {
            write();
        }

        //----------------------------------------------------------------------Validation----------------------------------------------------------------------//

        void fileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            valid();
        }

        void Triangle_Checked(object sender, RoutedEventArgs e)
        {
            if (Square.IsChecked == true)
            {
                Square.IsChecked = false;
            }

            valid();
        }

        void Square_Checked(object sender, RoutedEventArgs e)
        {
            if (Triangle.IsChecked == true)
            {
                Triangle.IsChecked = false;
            }

            valid();

        }

        void valid()
        {
            if (fileTextBox.Text != "" && Square.IsChecked == true || Triangle.IsChecked == true)
            {
                fileLoad.IsEnabled = true;
            }
            else
            {
                fileLoad.IsEnabled = false;
            }

            if (fileTextBox.Text != "" && generated)
            {
                fileGenerate.IsEnabled = true;
            }
            else
            {
                fileGenerate.IsEnabled = false;
            }
        }

        void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox1.Text != "")
            {
                GENERATE.IsEnabled = true;
            }
            else
            {
                GENERATE.IsEnabled = false;
            }
        }

        //----------------------------------------------------------------------File operations----------------------------------------------------------------------//

        /// <summary>
        /// Function used to load data from file
        /// </summary>
        void load()
        {
            //reads file path and open file
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.IO.StreamReader file = new System.IO.StreamReader(@$"{docPath}\{fileTextBox.Text}.txt");

            //read count from file
            string line = file.ReadLine();
            count = int.Parse(line);

            childArray = new Point[count];

            double x, y;

            for (int i = 0; i < count; i++)
            {
                line = file.ReadLine();

                x = double.Parse(line.Substring(0, line.IndexOf(';')));
                y = double.Parse(line.Substring(line.IndexOf(';') + 1, line.Length - line.IndexOf(';') - 1));

                childArray[i].X = x;
                childArray[i].Y = y;
            }

            file.Close();

            generateFileStructure();
        }

        /// <summary>
        /// Function used to save data from file
        /// </summary>
        void write()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, $"{fileTextBox.Text}.txt")))
            {
                outputFile.WriteLine(count);
                for (int i = 0; i < count; i++)
                {
                    outputFile.WriteLine(childArray[i]);
                }
            }
        }

        //----------------------------------------------------------------------Hull Algorithm----------------------------------------------------------------------//

        public static double cross(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        /// <summary>
        /// Convex Hull algorithm
        /// </summary>
        /// <param name="points"></param>
        /// <returns>returns points that belong to Convex Hull</returns>
        public static List<Point> GetConvexHull(List<Point> points)
        {
            if (points == null)
                return null;

            if (points.Count() <= 1)
                return points;

            int n = points.Count(), k = 0;
            List<Point> H = new List<Point>(new Point[2 * n]);

            points.Sort((a, b) =>
                 a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            // Build lower hull
            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && cross(H[k - 2], H[k - 1], points[i]) <= 0)
                    k--;
                H[k++] = points[i];
            }

            // Build upper hull
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && cross(H[k - 2], H[k - 1], points[i]) <= 0)
                    k--;
                H[k++] = points[i];
            }

            return H.Take(k - 1).ToList();
        }
    }
}