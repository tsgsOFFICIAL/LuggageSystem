using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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
        Brush _CustomColor;
        Random _Random = new Random();

        public Main()
        {
            InitializeComponent();
            List<string> Files = new List<string>();
            foreach (string file in Directory.GetFiles("assets/luggage/"))
            {
                Files.Add(file.Substring(15));
            }

        }
        #region Event handling
        /// <summary>
        /// Event for lost focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            // Code to execute when the window loses focus
        }
        #endregion

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRect = (Rectangle)e.OriginalSource;

                myCanvas.Children.Remove(activeRect);
            }
            else
            {
                _CustomColor = new SolidColorBrush(Color.FromRgb((byte)_Random.Next(0, 255 + 1), (byte)_Random.Next(0, 255 + 1), (byte)_Random.Next(0, 255 + 1)));

                Rectangle newRectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = _CustomColor,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(newRectangle, Mouse.GetPosition(myCanvas).X);
                Canvas.SetTop(newRectangle, Mouse.GetPosition(myCanvas).Y);

                myCanvas.Children.Add(newRectangle);
            }
        }
    }
}
