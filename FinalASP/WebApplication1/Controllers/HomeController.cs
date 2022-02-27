using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private PredicateContext db = new PredicateContext();
        public ActionResult Index()
        {
            return View(db.Predicates.ToList());
        }

        public string CheckTheory()
        {
            string status = Predicate.CheckTheory(db.Predicates.ToList()) ? "не имеет противоречий" : "имеет противоречия";
            return $"Теория {status}";
        }
    }
}