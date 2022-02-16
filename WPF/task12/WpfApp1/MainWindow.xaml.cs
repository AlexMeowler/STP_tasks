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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = Properties.Settings.Default.ApplicationName;
            Background = new SolidColorBrush(Properties.Settings.Default.BackgroundColor);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                String str = (listBox1.SelectedItem as ListBoxItem).Content.ToString();
                switch(str)
                {
                    case "Red":
                        Properties.Settings.Default.BackgroundColor = Colors.Red;
                        break;
                    case "Blue":
                        Properties.Settings.Default.BackgroundColor = Colors.Blue;
                        break;
                    case "Green":
                        Properties.Settings.Default.BackgroundColor = Colors.Green;
                        break;
                    case "Tomato":
                        Properties.Settings.Default.BackgroundColor = Colors.Tomato;
                        break;
                }
                Background = new System.Windows.Media.SolidColorBrush(Properties.Settings.Default.BackgroundColor);
                Properties.Settings.Default.Save();
            }
        }
    }
}
