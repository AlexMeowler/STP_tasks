using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private PredicateContext db = new PredicateContext();
        public ActionResult Index()
        {
            return View(db.Predicates.ToList());
        }

        public ActionResult CheckTheory()
        {
            bool isOkay = Predicate.CheckTheory(db.Predicates.ToList());
            string status = isOkay ? "не имеет противоречий" : "имеет противоречия";
            status = $"Теория {status}";
            if (isOkay)
            {
                return Content($"<h4>{status}</h4>");
            }
            else
            {
                ViewBag.Status = status;
                List<List<Predicate>> predicates = Predicate.FindConflictingPredicates(db.Predicates.ToList());
                return PartialView(predicates);
            }
        }
    }
}