using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            lbl_time.Content = $"{DateTime.Now.ToString("hh:mm tt")}";
            _AirportManager.TimeChanged += ChangeTime;
            _AirportManager.LuggageCreated += CreateLuggage;
            _AirportManager.LuggageMoved += UpdateLuggage;
            _AirportManager.SortedLuggageIn += UpdateLuggageSorterIn;
            _AirportManager.SortedLuggageOut += UpdateLuggageSorterOut;
            _AirportManager.LuggageMovedToTerminal += UpdateTerminals;
        }
        #region Event Handlers
        #region CheckIn
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 0);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 0);
        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 1);
        }
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 1);
        }
        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 2);
        }
        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 2);
        }
        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 3);
        }
        private void CheckBox_Unchecked_3(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 3);
        }
        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 4);
        }
        private void CheckBox_Unchecked_4(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 4);
        }
        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 5);
        }
        private void CheckBox_Unchecked_5(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 5);
        }
        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 6);
        }
        private void CheckBox_Unchecked_6(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 6);
        }
        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Open, 7);
        }
        private void CheckBox_Unchecked_7(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeCheckInState(IOpenClosed.State.Closed, 7);
        }
        #endregion
        #region Terminal
        private void CheckBox_Checked_8(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 0);
        }
        private void CheckBox_Unchecked_8(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 0);
        }
        private void CheckBox_Checked_9(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 1);
        }
        private void CheckBox_Unchecked_9(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 1);
        }
        private void CheckBox_Checked_10(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 2);
        }
        private void CheckBox_Unchecked_10(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 2);
        }
        private void CheckBox_Checked_11(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 3);
        }
        private void CheckBox_Unchecked_11(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 3);
        }
        private void CheckBox_Checked_12(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 4);
        }
        private void CheckBox_Unchecked_12(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 4);
        }
        private void CheckBox_Checked_13(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 5);
        }
        private void CheckBox_Unchecked_13(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 5);
        }
        private void CheckBox_Checked_14(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Open, 6);
        }
        private void CheckBox_Unchecked_14(object sender, RoutedEventArgs e)
        {
            _AirportManager.ChangeTerminalState(IOpenClosed.State.Closed, 6);
        }
        private void UpdateTerminals(object sender, TerminalEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                switch (e.Terminal.Id)
                {
                    case 0:
                        GateLabel1.Content = e.Terminal.Buffer.Count;
                        break;
                    case 1:
                        GateLabel2.Content = e.Terminal.Buffer.Count;
                        break;
                    case 2:
                        GateLabel3.Content = e.Terminal.Buffer.Count;
                        break;
                    case 3:
                        GateLabel4.Content = e.Terminal.Buffer.Count;
                        break;
                    case 4:
                        GateLabel5.Content = e.Terminal.Buffer.Count;
                        break;
                    case 5:
                        GateLabel6.Content = e.Terminal.Buffer.Count;
                        break;
                    case 6:
                        GateLabel7.Content = e.Terminal.Buffer.Count;
                        break;
                }
                SorterLabelOut.Content = e.LuggageList.Count;
            });
        }
        #endregion
        #region Producer
        private void CheckBox_Checked_15(object sender, RoutedEventArgs e)
        {
            ProducerLabel.Content = "Produce";
            _AirportManager.OpenLuggageProducer();
        }
        private void CheckBox_Unchecked_15(object sender, RoutedEventArgs e)
        {
            ProducerLabel.Content = "Wait";
            _AirportManager.CloseLuggageProducer();
        }
        #endregion
        #region Sorter
        private void CheckBox_Checked_16(object sender, RoutedEventArgs e)
        {
            _AirportManager.StartSorting();
        }
        private void CheckBox_Unchecked_16(object sender, RoutedEventArgs e)
        {
            _AirportManager.StopSorting();
        }
        private void UpdateLuggageSorterIn(object sender, List<Luggage> e)
        {
            Dispatcher.Invoke(() =>
            {
                SorterLabelIn.Content = e.Count;
            });
        }
        private void UpdateLuggageSorterOut(object sender, List<Luggage> e)
        {
            Dispatcher.Invoke(() =>
            {
                SorterLabelOut.Content = e.Count;
            });
        }
        #endregion
        #region Clock
        private void ChangeTime(object sender, DateTime e)
        {
            Dispatcher.Invoke(() =>
            {
                lbl_time.Content = $"{e.ToString("hh:mm tt")}";
            });
        }
        #endregion
        #region Luggage
        private void UpdateLuggage(object sender, CheckInBooth e)
        {
            Dispatcher.Invoke(() =>
            {
                switch (e.Id)
                {
                    case 0:
                        CheckInBoothLabel1.Content = e.Buffer.Count;
                        break;
                    case 1:
                        CheckInBoothLabel2.Content = e.Buffer.Count;
                        break;
                    case 2:
                        CheckInBoothLabel3.Content = e.Buffer.Count;
                        break;
                    case 3:
                        CheckInBoothLabel4.Content = e.Buffer.Count;
                        break;
                    case 4:
                        CheckInBoothLabel5.Content = e.Buffer.Count;
                        break;
                    case 5:
                        CheckInBoothLabel6.Content = e.Buffer.Count;
                        break;
                    case 6:
                        CheckInBoothLabel7.Content = e.Buffer.Count;
                        break;
                    case 7:
                        CheckInBoothLabel8.Content = e.Buffer.Count;
                        break;
                }
            });
        }
        private void CreateLuggage(object sender, List<Luggage> e)
        {
            Dispatcher.Invoke(() =>
            {
                ProducerCountLabel.Content = e.Count;
            });
        }
        #endregion
        #endregion
    }
}