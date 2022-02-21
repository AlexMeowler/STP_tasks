using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        private static PersonRepository db = new PersonRepository();
        // GET: Home
        [HttpGet]
        public ViewResult Index(string hel)
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро" :
            "Добрый день";
            ViewData["Mes"] = "хорошего настроения";
            return View();
            //return ExeStruct();
            //return StudyCsharp.ExeSwitch(StudyCsharp.SetStatus(3));
            //return StudyCsharp.GetFunction(0, 9);
            //return ExeFactorial(5);
            //return ExeTriangle();
            //return ExeCircle();
            //return ExePolim();
            //return ExeCollection() + "<br><br>" + ExeCollectionTriangles();
        }

        [HttpGet]
        public ViewResult InputData()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InputData(Person p)
        {
            db.AddResponse(p);
            return View("Hello", p);
        }

        public ViewResult OutputData()
        {
            ViewBag.Pers = db.GetPeople;
            ViewBag.Count = db.NumberOfPeople;
            return View("ListPerson");
        }

        public string ExeEnum()
        {
            AccountType goldAccount;
            AccountType platimunAccount;
            goldAccount = AccountType.Checking;
            platimunAccount = AccountType.Deposit;
            string template = "Тип банковского счета {0}";
            return String.Format(template, goldAccount) + "<p>" + String.Format(template, platimunAccount);
        }

        public string ExeStruct()
        {
            BankAccount goldBankAccount;
            goldBankAccount.accType = AccountType.Checking;
            goldBankAccount.accBal = (decimal)3200.00;
            goldBankAccount.accNo = 123;
            return String.Format("Информация о банковском счете: {0}", goldBankAccount);
        }

        public string ExeFactorial(int x)
        {
            bool ok = StudyCsharp.Factorial(x, out int f);
            return ok ? $"Факториал числа {x} равен {f}" : "Невозможно вычислить факториал";
        }

        public string ExeTriangle()
        {
            Triangle triangle = new Triangle(3, 5, 6);
            return $"Площадь фигуры {triangle.Name} равна {triangle.Area : 0.##}";
        }

        public string ExeCircle()
        {
            Circle circle = new Circle(3);
            return $"Площадь фигуры {circle.Name} равна {circle.Area: 0.##}";
        }

        public string ExePolim()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Shape[] shapes =
            {
                new Triangle(1, 2, 3),
                new Circle(5),
                new Triangle(5, 6, 8)
            };

            foreach(Shape shape in shapes)
            {
                stringBuilder.Append($"Это фигура {shape.Name}" + "<p>");
            }

            return stringBuilder.ToString();
        }

        public string ExeCollection()
        {
            List<Circle> circles = new List<Circle>
            {
                new Circle(12),
                new Circle(5),
                new Circle(15),
                new Circle(6)
            };

            circles.Add(new Circle(7));
            circles.Sort();

            StringBuilder str = new StringBuilder();
            foreach (Shape shape in circles)
            {
                str.AppendFormat($"Это фигура {shape.Name}" + "<p>");
            }
            return str.ToString();
        }

        public string ExeCollectionTriangles()
        {
            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle(100, 100, 100),
                new Triangle(2, 4, 8),
                new Triangle(15, 10, 11),
                new Triangle(2, 1, 1)
            };

            triangles.Add(new Triangle(7, 8, 8));
            triangles.Sort();

            StringBuilder str = new StringBuilder();
            foreach (Shape shape in triangles)
            {
                str.AppendFormat($"Это фигура {shape.Name}" + "<p>");
            }
            return str.ToString();
        }
    }

}