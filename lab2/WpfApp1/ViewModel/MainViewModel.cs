using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class MainViewModel
    {
        public HumanModel Human { get; set; }
        public ICommand ClickCommand { get; set; }
        public MainViewModel()
        {
            Human = new HumanModel
            {
                FirstName = "First name",
                LastName = "Last name"
            };
            ClickCommand = new ClickCommand(arg => ClickMethod());
        }

        private void ClickMethod()
        {
            MessageBox.Show("Person - " + Human.FirstName + " " + Human.LastName);
        }
    }
}
