using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models
{
    public enum AccountType
    {
        Checking,
        Deposit
    }

    public struct BankAccount
    {
        public long accNo;
        public decimal accBal;
        public AccountType accType;

        public override string ToString()
        {
            return $"Номер счета {accNo}, баланс {accBal}, тип {accType}";
        }
    }
    public class StudyCsharp
    {
        public static string SetStatus(int age)
        {
            string status = "Junior Developer";
            if(age > 2 && age < 7)
            {
                status = "Middle Developer";
            } else if(age >= 7 && age < 15)
            {
                status = "Senior Developer";
            } else if(age >= 15)
            {
                status = "Sensei";
            }
            return status;
        }

        public static string ExeSwitch(string status)
        {
            string res;
            switch(status)
            {
                case "Junior Developer":
                    res = "Набирайся знаний";
                    break;
                case "Middle Developer":
                    res = "Набирайся опыта";
                    break;
                case "Senior Developer":
                    res = "Руководи другими";
                    break;
                case "Sensei":
                    res = "Учи других";
                    break;
                default:
                    res = "Не знаю, что делать";
                    break;
            }

            return res;
        }

        public static string GetFunction(double x1, double x2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            double x = x1;
            do
            {
                stringBuilder.AppendFormat("x = {0:0.##} : y = {1:0.##}; <br>", x, Math.Pow(x, 3));
                x += 0.5;
            }
            while (x <= x2);

            return stringBuilder.ToString();
        }

        public static bool Factorial(int n, out int answer)
        {
            int k;
            int f = 1;
            bool ok = true;

            try
            {
                checked
                {
                    for (k = 2; k <= n; k++)
                    {
                        f *= k;
                    }
                }
            }
            catch (Exception e)
            {
                f = 0;
                ok = false;
            }

            answer = f;
            return ok;
        }
    }

    public class Triangle : Shape, IComparable<Triangle>
    {
        public double SideB { get; set; }
        public double SideC { get; set; }

        public override string Name => $"\"Треугольник со сторонами {Side}, {SideB}, {SideC}\"";
        public double Perimeter => Side + SideB + SideC;
        public double Area => Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - Side) * (Perimeter / 2 - SideB) * (Perimeter / 2 - SideC));

        public Triangle(double a, double b, double c)
        {
            Side = a;
            SideB = b;
            SideC = c;
        }

        public int CompareTo(Triangle other)
        {
            return (int)(this.Perimeter - other.Perimeter);
        }
    }

    public class Circle : Shape, IComparable<Circle>
    {
        public override string Name => $"\"Окружность с радиусом {Side}\"";
        public double Length => Math.PI * 2 * Side;
        public double Area => Math.PI * Math.Pow(Side, 2);

        public Circle(double a)
        {
            Side = a;
        }

        public int CompareTo(Circle other)
        {
            return (int)(this.Area - other.Area);
        }
    }

    public class Shape
    {
        public double Side { get; set; }
        virtual public string Name => "\"Фигура\"";
    }
}