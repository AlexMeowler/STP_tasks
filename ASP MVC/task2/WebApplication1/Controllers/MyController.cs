using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        // GET: Home
        public string Index(string hel)
        {
            return ExeEnum();
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
    }
}