using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESBClientMVC.Models;

namespace ESBClientMVC.Controllers
{
    // [Route("api/YOURCONTROLLER/{paramOne}/{paramTwo}")]
    public class BooksController : Controller
    {
        private ESBookshop db = new ESBookshop();

        // GET: Books
        public ActionResult Index()
        {
            var bOOKS = db.BOOKS.Include(b => b.EDITEUR);
            return View(bOOKS.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.ID_EDITEUR = new SelectList(db.EDITEURS, "ID", "NAME");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_EDITEUR,TITLE,SUBTITLE,PRICE,DATEPUBLICATION,SUMMARY,ISBN")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKS.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EDITEUR = new SelectList(db.EDITEURS, "ID", "NAME", bOOK.ID_EDITEUR);
            return View(bOOK);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EDITEUR = new SelectList(db.EDITEURS, "ID", "NAME", bOOK.ID_EDITEUR);
            return View(bOOK);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_EDITEUR,TITLE,SUBTITLE,PRICE,DATEPUBLICATION,SUMMARY,ISBN")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EDITEUR = new SelectList(db.EDITEURS, "ID", "NAME", bOOK.ID_EDITEUR);
            return View(bOOK);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK bOOK = db.BOOKS.Find(id);
            db.BOOKS.Remove(bOOK);
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
