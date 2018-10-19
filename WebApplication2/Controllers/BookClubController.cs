using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BookClubController : Controller
    {
        private BookClubContext db = new BookClubContext();

        // GET: BookClub
        public ActionResult Index()
        {
            return View(db.BookClubs.ToList());
        }

        // GET: BookClubs
        public ActionResult ViewAllBookClubs()
        {
            var bookclubs = db.BookClubs.Include(b => b.BookClubName);
            return View(bookclubs.ToList());
        }

            // GET: BookClub/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // GET: BookClub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookClub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookClubID,BookClubName,AdminEmail,Profile,Status,Province,County,Area,LibraryName,NextMeeting,CurrentRead")] BookClub bookClub)
        {
            if (ModelState.IsValid)
            {
                db.BookClubs.Add(bookClub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookClub);
        }

        // GET: BookClub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // POST: BookClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookClubID,BookClubName,AdminEmail,Profile,Status,Province,County,Area,LibraryName,NextMeeting,CurrentRead")] BookClub bookClub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookClub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookClub);
        }

        // GET: BookClub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // POST: BookClub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookClub bookClub = db.BookClubs.Find(id);
            db.BookClubs.Remove(bookClub);
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
