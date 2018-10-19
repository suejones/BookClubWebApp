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
    public class BookClubMemberController : Controller
    {
        private BookClubContext db = new BookClubContext();

        // GET: BookClubMember
        public ActionResult Index()
        {
            return View(db.BookClubMembers.ToList());
        }

        // GET: BookClubMember/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMember bookClubMember = db.BookClubMembers.Find(id);
            if (bookClubMember == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMember);
        }

        // GET: BookClubMember/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookClubMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,MemberFirstName,MemberLastName,MemberEmail")] BookClubMember bookClubMember)
        {
            if (ModelState.IsValid)
            {
                db.BookClubMembers.Add(bookClubMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookClubMember);
        }

        // GET: BookClubMember/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMember bookClubMember = db.BookClubMembers.Find(id);
            if (bookClubMember == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMember);
        }

        // POST: BookClubMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,MemberFirstName,MemberLastName,MemberEmail")] BookClubMember bookClubMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookClubMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookClubMember);
        }

        // GET: BookClubMember/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMember bookClubMember = db.BookClubMembers.Find(id);
            if (bookClubMember == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMember);
        }

        // POST: BookClubMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookClubMember bookClubMember = db.BookClubMembers.Find(id);
            db.BookClubMembers.Remove(bookClubMember);
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
