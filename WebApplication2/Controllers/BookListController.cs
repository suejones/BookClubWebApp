using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Abstract;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BookListController : Controller
    {
        private IBookClubContext db = new BookClubContext();

        public BookListController() { }
        public BookListController(IBookClubContext context)
        {
            db = context;
        }

        // GET: BookList
        public ActionResult Index()
        {
            return View(db.BookLists.ToList());
        }

        // GET: BookList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // GET: BookList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookListID,BookListName,BookListType,BookListContent,GenreType")] BookList bookList)
        {
            if (ModelState.IsValid)
            {
                db.BookLists.Add(bookList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookList);
        }

        // GET: BookList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // POST: BookList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookListID,BookListName,BookListType,BookListContent,GenreType")] BookList bookList)
        {
            if (ModelState.IsValid)
            {
                db.MarkAsModified(bookList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookList);
        }

        // GET: BookList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookList bookList = db.BookLists.Find(id);
            if (bookList == null)
            {
                return HttpNotFound();
            }
            return View(bookList);
        }

        // POST: BookList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookList bookList = db.BookLists.Find(id);
            db.BookLists.Remove(bookList);
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
