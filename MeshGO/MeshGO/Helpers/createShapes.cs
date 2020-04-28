using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MeshGO.Helpers
{
    class createShapes
    {
        public static Path createPath(Rect rect)
        {
            Path path = new Path();
            path.Stroke = Brushes.Red;
            path.StrokeThickness = 1;

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = rect;

            GeometryGroup myGeometryGroup2 = new GeometryGroup();
            myGeometryGroup2.Children.Add(myRectangleGeometry);

            path.Data = myGeometryGroup2;

            return path;
        }

        public static Rect createRectangle(Point pointStart, int width, int height)
        {
            Rect rect = new Rect();
            rect.Size = new Size(width, height);
            rect.Location = pointStart;

            return rect;
        }
    }
}
