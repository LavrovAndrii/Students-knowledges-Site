using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROZKLAD.Models.DbEntities;

namespace ROZKLAD.Controllers
{
    public class AdministratorViewController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: AdministratorView
        public ActionResult Index()
        {
            var ocinkas = db.Ocinkas.Include(o => o.Lessons).Include(o => o.Students);
            return View(ocinkas.ToList());
        }

        // GET: AdministratorView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocinka ocinka = db.Ocinkas.Find(id);
            if (ocinka == null)
            {
                return HttpNotFound();
            }
            return View(ocinka);
        }

        // GET: AdministratorView/Create
        public ActionResult Create()
        {
            ViewBag.IdLesson = new SelectList(db.Lessons, "Id", "Id");
            ViewBag.IdStudent = new SelectList(db.Students, "Id", "SureName");
            return View();
        }

        // POST: AdministratorView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdStudent,IdLesson,Mark")] Ocinka ocinka)
        {
            if (ModelState.IsValid)
            {
                db.Ocinkas.Add(ocinka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLesson = new SelectList(db.Lessons, "Id", "Id", ocinka.IdLesson);
            ViewBag.IdStudent = new SelectList(db.Students, "Id", "SureName", ocinka.IdStudent);
            return View(ocinka);
        }

        // GET: AdministratorView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocinka ocinka = db.Ocinkas.Find(id);
            if (ocinka == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLesson = new SelectList(db.Lessons, "Id", "Id", ocinka.IdLesson);
            ViewBag.IdStudent = new SelectList(db.Students, "Id", "SureName", ocinka.IdStudent);
            return View(ocinka);
        }

        // POST: AdministratorView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdStudent,IdLesson,Mark")] Ocinka ocinka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocinka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLesson = new SelectList(db.Lessons, "Id", "Id", ocinka.IdLesson);
            ViewBag.IdStudent = new SelectList(db.Students, "Id", "SureName", ocinka.IdStudent);
            return View(ocinka);
        }

        // GET: AdministratorView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocinka ocinka = db.Ocinkas.Find(id);
            if (ocinka == null)
            {
                return HttpNotFound();
            }
            return View(ocinka);
        }

        // POST: AdministratorView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocinka ocinka = db.Ocinkas.Find(id);
            db.Ocinkas.Remove(ocinka);
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
