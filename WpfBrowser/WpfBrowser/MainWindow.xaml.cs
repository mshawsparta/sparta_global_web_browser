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
using System.IO;

namespace WpfBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> comboBoxDataStorage = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            populateCombo();
            foreach (var item in comboBoxDataStorage)
            {
                cBox.Items.Add(item);
            }
            browserControl.Navigate("http://www.spartaglobal.com");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = cBox.SelectedItem.ToString();
            browserControl.Navigate(item);
            WritetoFile(item);
        }
        
        public void WritetoFile(string item)
        {
            string path = "History.txt";
            
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(item );
                }
        }

        public void populateCombo()
        {
            string path = "History.txt";
            comboBoxDataStorage.Add("https://www.bbc.co.uk/news");
            comboBoxDataStorage.Add("http://www.bing.com");
            comboBoxDataStorage.Add("http://www.yahoo.com");
            comboBoxDataStorage.Add("http://www.whatsmyip.com");
            comboBoxDataStorage.Add("http://www.wikipedia.com");

           using (StreamReader sr = new StreamReader(path))
           {
               foreach (var item in path)
               {
                   comboBoxDataStorage.Add(sr.ReadLine());
               } 
            }

        }

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                browserControl.Navigate(cBox.Text);
                WritetoFile(cBox.Text);
            }
        }
    }
}
