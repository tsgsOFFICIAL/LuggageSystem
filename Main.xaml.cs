using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LuggageSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        private AirportManager _AirportManager = new AirportManager();
        public Main()
        {
            InitializeComponent();

            List<string> LuggageList = new List<string>();
            foreach (string file in Directory.GetFiles("assets/luggage/"))
            {
                LuggageList.Add(file.Substring(15));
            }

        }
        #region Event Handlers
        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            // Start
            ButtonStart.Content = "Stop";
            ButtonStart.Click -= Button_Start_Click;
            ButtonStart.Click += Button_Stop_Click;

            //Bitmap bmp = BitmapImage2Bitmap(new BitmapImage(new Uri($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/gate.png")));
            //Gate1.Source = BitmapToImageSource(ChangeColor(bmp, System.Drawing.Color.Red));
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            // Stop
            ButtonStart.Content = "Start";
            ButtonStart.Click -= Button_Stop_Click;
            ButtonStart.Click += Button_Start_Click;

            //Bitmap bmp = BitmapImage2Bitmap(new BitmapImage(new Uri($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/gate.png")));
            //Gate1.Source = BitmapToImageSource(ChangeColor(bmp, System.Drawing.Color.Black));
        }
        #endregion
        ///// <summary>
        ///// Magic
        ///// </summary>
        ///// <param name="bitmapImage"></param>
        ///// <returns></returns>
        //private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        //{
        //    using (MemoryStream outStream = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(bitmapImage));
        //        enc.Save(outStream);
        //        Bitmap bitmap = new Bitmap(outStream);

        //        return new Bitmap(bitmap);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bitmap"></param>
        ///// <returns></returns>
        //private BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap)
        //{
        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        //        memory.Position = 0;
        //        BitmapImage bitmapimage = new BitmapImage();
        //        bitmapimage.BeginInit();
        //        bitmapimage.StreamSource = memory;
        //        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        //        bitmapimage.EndInit();
        //        return bitmapimage;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="scrBitmap"></param>
        ///// <param name="newColor"></param>
        ///// <returns></returns>
        //private Bitmap ChangeColor(Bitmap srcBitmap, System.Drawing.Color newColor)
        //{
        //    System.Drawing.Color actualColor;

        //    // Make an empty bitmap the same size as srcBitmap
        //    Bitmap newBitmap = new Bitmap(srcBitmap.Width, srcBitmap.Height);

        //    for (int i = 0; i < srcBitmap.Width; i++)
        //    {
        //        for (int j = 0; j < srcBitmap.Height; j++)
        //        {
        //            actualColor = srcBitmap.GetPixel(i, j);

        //            System.Drawing.Color newPixelColor = System.Drawing.Color.FromArgb(actualColor.A, actualColor.R, actualColor.G, actualColor.B);

        //            newBitmap.SetPixel(i, j, newPixelColor);
        //        }
        //    }
        //    newBitmap.Save($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\new.png", ImageFormat.Png);
        //    return newBitmap;
        //}
    }
}
