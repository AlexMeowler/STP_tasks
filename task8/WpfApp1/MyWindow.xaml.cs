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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        public bool _close = false;
        private MainWindow mw;
        public MyWindow()
        {
            InitializeComponent();
            this.Title = "Title #" + new Random().Next();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close) return;
            e.Cancel = true;
            Hide();
        }

        public new void Close()
        {
            _close = true;
            base.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mw = Owner as MainWindow;
            if(mw != null)
            {
                string studentText = listBox1.SelectedItem is Student student ? student.FullStudentData + " " : "";
                mw.txtBlock.Text = studentText + textBox.Text;
                PrintLogFile();
            }
            Close();
        }

        private void PrintLogFile()
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Внесено {0}: {1} ", textBox.Text, DateTime.Now.ToShortDateString() + ", время: " + DateTime.Now.ToShortTimeString());
                writer.Flush();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.myWindow = null;
        }
    }
}
