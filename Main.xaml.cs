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
            _AirportManager.CheckInBoothStateChanged += AirportManagerCheckInStateChanged;
        }
        #region Event Handlers
        #region CheckIn
        private void AirportManagerCheckInStateChanged(object sender, EventArgs e)
        {
            //Tjek at EventArgs er af type TemperatureEventArgs
            if (e.GetType().Equals(typeof(CheckInBoothEventArgs)))
            {
                //((CheckInBoothEventArgs)e).;
                
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_3(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_4(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_5(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_6(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {

        }
        private void CheckBox_Unchecked_7(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #endregion
    }
}
