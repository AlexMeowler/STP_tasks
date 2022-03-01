using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "admin")]
    public class PredicatesController : Controller
    {
        private PredicateContext db = new PredicateContext();

        // GET: Predicates
        public ActionResult Index()
        {
            return View(db.Predicates.ToList());
        }

        // GET: Predicates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predicates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OpA,OperandA,OpB,OperandB,Op")] Predicate predicate)
        {
            if (ModelState.IsValid)
            {
                db.Predicates.Add(predicate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predicate);
        }

        // GET: Predicates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predicate predicate = db.Predicates.Find(id);
            if (predicate == null)
            {
                return HttpNotFound();
            }
            return View(predicate);
        }

        // POST: Predicates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OpA,OperandA,OpB,OperandB,Op")] Predicate predicate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predicate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predicate);
        }

        // GET: Predicates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predicate predicate = db.Predicates.Find(id);
            if (predicate == null)
            {
                return HttpNotFound();
            }
            return View(predicate);
        }

        // POST: Predicates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predicate predicate = db.Predicates.Find(id);
            db.Predicates.Remove(predicate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
