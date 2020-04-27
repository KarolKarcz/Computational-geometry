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

namespace MeshGO.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MeshView.xaml
    /// </summary>
    public partial class MeshView : UserControl
    {
        int podzial;
        int width;
        int height;
        Point[,] childArray;
        bool generated;
        public MeshView()
        {
            InitializeComponent();

            width = (int)Cnva.Width;
            height = (int)Cnva.Height;

            generated = false;
        }

        //----------------------------------------------------------------------Mesh generation----------------------------------------------------------------------//

        private void generateStructuredMesh()
        {
            int childi, childj;
            childi = childj = 0;

            for (int i = 0; i <= (int)Cnva.Height; i += height / podzial)
            {
                for (int j = 0; j <= (int)Cnva.Width; j += width / podzial)
                {
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

                    Ellipse ellipse = new Ellipse();

                    ellipse.Height = 8;
                    ellipse.Width = 8;
                    ellipse.StrokeThickness = 5;
                    ellipse.Stroke = Brushes.Black;

                    Cnva.Children.Add(ellipse);
                    Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, (double)i - 4);
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
            int hgh = (int)(Cnva.Height / (height / podzial)) + 1;
            int wdth = (int)(Cnva.Width / (width / podzial)) + 1;

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

        void generateStructuredMeshTriangleLines()
        {
            int hgh = (int)(Cnva.Height / (height / podzial)) + 1;
            int wdth = (int)(Cnva.Width / (width / podzial)) + 1;

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

                        createLine(childArray[i + 1, j + 1], childArray[i, j]);
                    }
                }
            }
        }

        int[] divideLine()
        {
            int wdth = (int)(Cnva.Width / (width / podzial)) + 1;
            int[] output = new int[wdth];
            
            Random rnd = new Random();

            output[0] = 0;
            output[1] = width;

            for (int i = 0; i < wdth - 2; i++)
            {
                output[i] = rnd.Next(0, width);
            }

            Array.Sort(output);

            return output;
            
        }

        void generateRandomMesh()
        {
            int childi, childj;
            childi = childj = 0;

            int[] vs = divideLine();

            for (int i = 0; i <= (int)Cnva.Height; i += height / podzial)
            {
                for (int j = 0; j <= (int)Cnva.Width; j += width / podzial)
                {
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

                    Ellipse ellipse = new Ellipse();

                    ellipse.Height = 8;
                    ellipse.Width = 8;
                    ellipse.StrokeThickness = 5;
                    ellipse.Stroke = Brushes.Black;

                    Cnva.Children.Add(ellipse);
                    Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.TopProperty, (double)i - 4);
                    Cnva.Children[Cnva.Children.Count - 1].SetValue(Canvas.LeftProperty, (double)vs[childi] - 4);

                    childArray[childi, childj] = new Point(i, (double)vs[childi]);

                    childi++;
                }
                childj++;
                childi = 0;
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

        //----------------------------------------------------------------------Click methods----------------------------------------------------------------------//

        private void GENERATE_Click(object sender, RoutedEventArgs e)
        {
            generated = true;
            Cnva.Children.Clear();
            podzial = int.Parse(TextBox1.Text);
            childArray = new Point[(int)(Cnva.Height / (height / podzial)) + 1, (int)(Cnva.Width / (width / podzial)) + 1];
            
            generateStructuredMesh();
            generateStructuredMeshLines();
        }

        private void generateTriangle_Click(object sender, RoutedEventArgs e)
        {
            generated = true;
            Cnva.Children.Clear();
            podzial = int.Parse(TextBox1.Text);
            childArray = new Point[(int)(Cnva.Height / (height / podzial)) + 1, (int)(Cnva.Width / (width / podzial)) + 1];
            
            generateStructuredMesh();
            generateStructuredMeshTriangleLines();

        }

        private void fileLoad_Click(object sender, RoutedEventArgs e)
        {
            Cnva.Children.Clear();
            load();

            if (Triangle.IsChecked == true)
            {
                generateStructuredMeshTriangleLines();
            }
            else
            {
                generateStructuredMeshLines();
            }

        }

        private void fileGenerate_Click(object sender, RoutedEventArgs e)
        {
            write();
        }

        private void generateRandomSquare_Click(object sender, RoutedEventArgs e)
        {
            generated = true;
            Cnva.Children.Clear();
            podzial = int.Parse(TextBox1.Text);
            childArray = new Point[(int)(Cnva.Height / (height / podzial)) + 1, (int)(Cnva.Width / (width / podzial)) + 1];

            generateRandomMesh();
            generateStructuredMeshLines();
        }

        private void generateRandomTriangle_Click(object sender, RoutedEventArgs e)
        {
            generated = true;
            Cnva.Children.Clear();
            podzial = int.Parse(TextBox1.Text);
            childArray = new Point[(int)(Cnva.Height / (height / podzial)) + 1, (int)(Cnva.Width / (width / podzial)) + 1];

            generateRandomMesh();
            generateStructuredMeshTriangleLines();
        }

        //----------------------------------------------------------------------Validation----------------------------------------------------------------------//

        private void fileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            valid();
        }

        private void Triangle_Checked(object sender, RoutedEventArgs e)
        {
            if (Square.IsChecked == true)
            {
                Square.IsChecked = false;
            }

            valid();
        }

        private void Square_Checked(object sender, RoutedEventArgs e)
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
                generateTriangle.IsEnabled = true;
                generateRandomSquare.IsEnabled = true;
                generateRandomTriangle.IsEnabled = true;
            }
            else
            {
                GENERATE.IsEnabled = false;
                generateTriangle.IsEnabled = false;
                generateRandomSquare.IsEnabled = false;
                generateRandomTriangle.IsEnabled = false;
            }
        }


        //----------------------------------------------------------------------File operations----------------------------------------------------------------------//

        void load()
        {
            string line;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.IO.StreamReader file = new System.IO.StreamReader(@$"{docPath}\{fileTextBox.Text}.txt");

            line = file.ReadLine();
            podzial = int.Parse(line);

            childArray = new Point[(int)(Cnva.Height / (height / podzial)) + 1, (int)(Cnva.Width / (width / podzial)) + 1];

            int hgh = (int)(Cnva.Height / (height / podzial)) + 1;
            int wdth = (int)(Cnva.Width / (width / podzial)) + 1;

            double x,y;

            for (int i = 0; i < hgh; i++)
            {
                for (int j = 0; j < wdth; j++)
                {
                    line = file.ReadLine();

                    int index1, index2;
                    index1 = line.IndexOf(';') + 1;
                    index2 = line.Length - 1;

                    x = double.Parse(line.Substring(0, line.IndexOf(';')));
                    try 
                    {
                        if (line.Substring(index1,line.Length - index1).Length == 0)
                        {
                            y = line[line.Length - 1] - 48;
                        }
                        else
                        {
                            y = double.Parse(line.Substring(line.IndexOf(';') + 1, line.Length - index1));
                        }
                    }
                    catch(Exception E)
                    {
                        y = line[line.Length - 1] - 48;
                    };

                    childArray[i, j].X = x;
                    childArray[i, j].Y = y;
                }
            }

            file.Close();
        }

        void write()
        {
            int hgh = (int)(Cnva.Height / (height / podzial)) + 1;
            int wdth = (int)(Cnva.Width / (width / podzial)) + 1;

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, $"{fileTextBox.Text}.txt")))
            {
                outputFile.WriteLine(podzial);
                for (int i = 0; i < hgh; i++)
                {
                    for (int j = 0; j < wdth; j++)
                    {
                        outputFile.WriteLine(childArray[i, j]);
                    }
                }
            }
        }
    }
}
