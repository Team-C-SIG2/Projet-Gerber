using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESBClientMVC.Models;

namespace ESBClientMVC.Controllers
{
    public class OrdersController : Controller
    {
        private ESBookshop db = new ESBookshop();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            var oRDERS = db.ORDERS.Include(o => o.ACCOUNT);
            return View(await oRDERS.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = await db.ORDERS.FindAsync(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ORDEREDDATE,SHIPPEDDATE,SHIPPINGADDRESS,STATUS,TOTALPRICE,ID_ACCOUNT")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDERS.Add(oRDER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", oRDER.ID_ACCOUNT);
            return View(oRDER);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = await db.ORDERS.FindAsync(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", oRDER.ID_ACCOUNT);
            return View(oRDER);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ORDEREDDATE,SHIPPEDDATE,SHIPPINGADDRESS,STATUS,TOTALPRICE,ID_ACCOUNT")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", oRDER.ID_ACCOUNT);
            return View(oRDER);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = await db.ORDERS.FindAsync(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ORDER oRDER = await db.ORDERS.FindAsync(id);
            db.ORDERS.Remove(oRDER);
            await db.SaveChangesAsync();
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
