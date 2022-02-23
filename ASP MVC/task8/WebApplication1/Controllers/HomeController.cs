using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private CreditContext db = new CreditContext();
        public ActionResult Index()
        {
            GiveCredits();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                roles = userManager.GetRoles(user.Id);
            }
            ViewBag.rol = roles;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateBid()
        {
            GiveCredits();
            List<Bid> allBids = db.Bids.ToList();
            ViewBag.Bids = allBids;

            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.BidDate = DateTime.Now;
            // Добавляем новую заявку в БД
            db.Bids.Add(newBid);
            // Сохраняем в БД все изменения
            db.SaveChanges();
            return "Спасибо, <b>" + newBid.Name + "</b>, за выбор нашего банка. Ваша заявка будет рассмотрена в течении 10 дней.";
        }

        private void GiveCredits()
        {
            List<Credit> allCredits = db.Credits.ToList();
            ViewBag.Credits = allCredits;
        }

        public ActionResult BidSearch(string name)
        {
            List<Bid> allBids = db.Bids.Where(a => a.CreditHead.Contains(name)).ToList();
            if (allBids.Count == 0)
            {
                return Content("Указанный кредит " + name + " не найден");
                //return HttpNotFound();
            }
            return PartialView(allBids);
        }
    }
}