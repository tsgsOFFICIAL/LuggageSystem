using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LuggageSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Display.Content = new Main(); // Show "Main" page in the frame "Display"
        }
        #region Window Buttons & Functionality
        /// <summary>
        /// Minimize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// Maximize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Maximize(object sender, RoutedEventArgs e)
        {
            if (Maximize_Button.Cursor == Cursors.Hand)
            {
                if (this.WindowState.Equals(WindowState.Maximized))
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }
        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            #region Kill all processes with the same name
            foreach (Process pro in Process.GetProcessesByName(Assembly.GetExecutingAssembly().FullName.Split(',')[0]))
            {
                pro.Kill();
            } 
            #endregion
            this.Close();
        }
        /// <summary>
        /// Drag the window around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WindowHeader_Mousedown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}
