using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace XmlSimpleParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CarDatabase dummyDatabase;

        public MainWindow()
        {
            InitializeComponent();

            dummyDatabase = new CarDatabase()
            {
                Cars = new List<Car>()
                {
                    new Car("1b1 111", "RR", "nevim"),
                    new Car("3z4 6151", "Skoda", "Rabia FS"),
                    new Car("1b1 1511", "Honda", "Civic Tourerr")
                }
            };
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = false;
            dialog.Multiselect = false;
            var result = dialog.ShowDialog();

            if(result.HasValue && result.Value)
            {
                CarDatabaseXmlParser.SerializeToFile(dialog.FileName.Trim(), dummyDatabase);
            }
        }

        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var database = CarDatabaseXmlParser.DeserializeFromFile(dialog.FileName.Trim());

            }
        }
    }
}
