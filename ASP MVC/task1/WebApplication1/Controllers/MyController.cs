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
            return ModelClass.ModelHello() + ", " + hel;
        }
    }
}