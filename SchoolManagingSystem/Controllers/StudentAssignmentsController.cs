using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagingSystem.Models;

namespace SchoolManagingSystem.Controllers
{
    public class StudentAssignmentsController : Controller
    {
        private SchoolDatabaseEntities db = new SchoolDatabaseEntities();

        // GET: StudentAssignments
        public ActionResult Index()
        {
            var studentAssignments = db.StudentAssignments.Include(s => s.Assignment).Include(s => s.Student);
            return View(studentAssignments.ToList());
        }

        // GET: StudentAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignment studentAssignment = db.StudentAssignments.Find(id);
            if (studentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(studentAssignment);
        }

        // GET: StudentAssignments/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: StudentAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,AssignmentId")] StudentAssignment studentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.StudentAssignments.Add(studentAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Name", studentAssignment.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentAssignment.StudentId);
            return View(studentAssignment);
        }

        // GET: StudentAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignment studentAssignment = db.StudentAssignments.Find(id);
            if (studentAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Name", studentAssignment.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentAssignment.StudentId);
            return View(studentAssignment);
        }

        // POST: StudentAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,AssignmentId")] StudentAssignment studentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Name", studentAssignment.AssignmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentAssignment.StudentId);
            return View(studentAssignment);
        }

        // GET: StudentAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAssignment studentAssignment = db.StudentAssignments.Find(id);
            if (studentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(studentAssignment);
        }

        // POST: StudentAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAssignment studentAssignment = db.StudentAssignments.Find(id);
            db.StudentAssignments.Remove(studentAssignment);
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
