using System;
using System.Collections.Generic;
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
using System.IO;

namespace MeshGO.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SimpleMeshView.xaml
    /// </summary>
    public partial class SimpleMeshView : UserControl
    {
        int width;
        int height;
        Point[,] childArray;
        public SimpleMeshView()
        {
            InitializeComponent();

            width = (int)Cnva.Width;
            height = (int)Cnva.Height;

            childArray = new Point[(int)(Cnva.Height/(height / 10.0)) + 1, (int)(Cnva.Width/(width / 10)) + 1];
        }

        private void GENERATE_Click(object sender, RoutedEventArgs e)
        {
            generateStructuredMesh();
            generateStructuredMeshLines();
        }

        private void generateStructuredMesh() 
        {
            int childi, childj;
            childi = childj = 0;

            for (int i = 0; i <= (int)Cnva.Height; i+= height/ 10)
            {
                for (int j = 0; j <= (int)Cnva.Width; j+= width / 10)
                {
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

                    Ellipse ellipse = new Ellipse();

                    ellipse.Height = 8;
                    ellipse.Width = 8;
                    ellipse.StrokeThickness = 5;
                    ellipse.Stroke = Brushes.Black;

                    Cnva.Children.Add(ellipse);
                    Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty,(double) i - 4);
                    Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.LeftProperty, (double)j - 4);

                    childArray[childi, childj] = new Point(i, j);

                    childi++;
                }
                childj++;
                childi = 0;
            }
        }

        void generateStructuredMeshLines()
        {
            int hgh = (int)(Cnva.Height / (height / 10.0)) + 1;
            int wdth =(int)(Cnva.Width / (width / 10.0)) + 1;

            for (int i = 0; i < hgh; i++)
            {
                for (int j = 0; j < wdth; j++)
                {
                    if (i == wdth - 1 && j == hgh - 1)
                    {

                    }
                    else if (i == wdth - 1 && j < hgh)
                    {
                        createLine(childArray[i, j + 1], childArray[i, j]);
                    }
                    else if (i < wdth && j == hgh - 1)
                    {
                        createLine(childArray[i + 1, j], childArray[i, j]);
                    }
                    else
                    {
                        createLine(childArray[i + 1, j], childArray[i, j]);

                        createLine(childArray[i, j + 1], childArray[i, j]);
                    }
                }
            }
        }

        void createLine(Point point1, Point point2)
        {
            Line line = new Line();

            //kolor pędzla
            line.Stroke = System.Windows.Media.Brushes.Black;

            //Pozycja startowa
            line.X1 = point1.Y;
            line.X2 = point2.Y;
            line.Y1 = point1.X;
            line.Y2 = point2.X;

            //grubość linii
            line.StrokeThickness = 1;

            Cnva.Children.Add(line);
        }
    }
}
