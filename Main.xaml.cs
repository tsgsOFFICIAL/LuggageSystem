using Npgsql;
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
    }
}
