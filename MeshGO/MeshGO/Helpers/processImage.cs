using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MeshGO.Helpers
{
    class processImage
    {
        public static Image image(System.IO.FileInfo fileInfo)
        {
            Image image = new Image();

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.UriSource = new Uri(fileInfo.FullName, UriKind.Relative);
            src.EndInit();
            image.Source = src;
            image.Height = src.PixelHeight;
            image.Width = src.PixelWidth;

            return image;
        }
    }
}
