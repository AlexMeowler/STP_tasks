using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        private List<string> numbers = new List<string>();
        private SaveFileDialog dialog;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            dialog = new SaveFileDialog();
            dialog.Filter = "Text Files | *.txt";
            dialog.ShowDialog();
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(dialog.FileName, true);
            foreach(string s in numbers)
            {
                myWriter.WriteLine(s);
            }
            myWriter.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MaskedTextBox box = widnowsFormHost1.Child as MaskedTextBox;
            numbers.Add(box.Text);
            box.Clear();
        }
    }
}
