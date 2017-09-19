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
    public class LessonsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Days).Include(l => l.Subjects).Include(l => l.Teachers);
            return View(lessons.ToList());
        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.IdDay = new SelectList(db.Days, "Id", "Days");
            ViewBag.IdSubject = new SelectList(db.Subjects, "Id", "NameSubject");
            ViewBag.IdTeatcher = new SelectList(db.Teachers, "Id", "SureName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdDay,IdTeatcher,IdSubject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDay = new SelectList(db.Days, "Id", "Days", lesson.IdDay);
            ViewBag.IdSubject = new SelectList(db.Subjects, "Id", "NameSubject", lesson.IdSubject);
            ViewBag.IdTeatcher = new SelectList(db.Teachers, "Id", "SureName", lesson.IdTeatcher);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDay = new SelectList(db.Days, "Id", "Days", lesson.IdDay);
            ViewBag.IdSubject = new SelectList(db.Subjects, "Id", "NameSubject", lesson.IdSubject);
            ViewBag.IdTeatcher = new SelectList(db.Teachers, "Id", "SureName", lesson.IdTeatcher);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdDay,IdTeatcher,IdSubject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDay = new SelectList(db.Days, "Id", "Days", lesson.IdDay);
            ViewBag.IdSubject = new SelectList(db.Subjects, "Id", "NameSubject", lesson.IdSubject);
            ViewBag.IdTeatcher = new SelectList(db.Teachers, "Id", "SureName", lesson.IdTeatcher);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
