using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person> people = new List<Person>();
        // GET: Person
        public ActionResult Index()
        {
            return View(people);
        }

        // GET: Person/Details/5
        public ActionResult Details(Person p)
        {
            return View(p);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", p);
                }
                people.Add(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person p = (from person in people where person.Id == id select person).Single();
            return View(p);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            if(!ModelState.IsValid)
            {
                return View("Edit", p);
            }

            Person pn = (from person in people where person.Id == p.Id select person).Single();
            pn.Name = p.Name;
            pn.Age = p.Age;
            pn.Phone = p.Phone;
            pn.Email = p.Email;
            return RedirectToAction("Index");
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            Person p = (from person in people where person.Id == id select person).Single();
            return View(p);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Person p = (from person in people where person.Id == id select person).Single();
                people.Remove(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
