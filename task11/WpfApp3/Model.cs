using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Model
    {
        public IList<Data> Data
        {
            get
            {
                return new List<Data>
                {
                    new Data("Иванов", 10),
                    new Data("Петров", 30),
                    new Data("Сиборов", 10),
                    new Data("Кузнецов", 20),
                    new Data("Павлов", 40)
                };
            }
        }
    }
    public class Data
    {
        public String Name { get; set; }
        public int Value { get; set; }
        public Data(String name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
