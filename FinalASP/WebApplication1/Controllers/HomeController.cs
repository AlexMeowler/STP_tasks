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
                return Content(status);
            }
            else
            {
                ViewBag.Status = status;
                List<Predicate> predicates = db.Predicates.ToList();
                predicates = predicates.Except(Predicate.FindNotConflictingPredicates(predicates)).ToList();
                return PartialView(predicates);
            }
        }
    }
}