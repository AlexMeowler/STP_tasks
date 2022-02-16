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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        //private int currentNumber = 0;
        public ShowNumberControl()
        {
            InitializeComponent();
        }

        /*public int CurrentNumber
        {
            get { return currentNumber; }
            set 
            {
                currentNumber = value;
                numberDisplay.Content = currentNumber;
            }
        }*/

        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        public static bool ValidateCurrentNumber(object value)
        {
            int x = Convert.ToInt32(value);
            return x >= 0 && x <= 500;
        }

        private static void CurrentNumberChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ShowNumberControl s = depObj as ShowNumberControl;
            s.numberDisplay.Content = args.NewValue.ToString();
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(int), typeof(ShowNumberControl), 
                new PropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)), 
                new ValidateValueCallback(ValidateCurrentNumber));


    }
}
