using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;

using ESBClientMVC.Models;
using PayPal.Api;
using System.Collections.Generic;
using System;


namespace ESBClientMVC.Controllers
{
    public class LineItemsController : Controller
    {
        private readonly ESBookshop db = new ESBookshop();
        
        
        // ______________________________________________________________________________________________________________________________________________________


        // ///////////////////////////////////////////////////////////
        // GetCartItems : RETOURNE LES LIGNES D'ARTICLES D'UN PANIER X 
        // //////////////////////////////////////////////////////////
        public async Task<ActionResult> GetCartItems(int? id)
        {
            decimal total = 0; 

            // Récupère la liste des lignes (livres) insérer dans le panier (ID = id)
            var items =
                (from i in db.LINEITEMS
                where i.ID_SHOPPINGCART == id
                select i
                );

            foreach (var item in items)
            {
                total += item.UNITPRICE; 
            }

            // Récupère le numéro (ID) du panier 
            ViewBag.PANIER = id;

            // Récupèrent le montant total des lignes du contenu d'un panier 

            ViewBag.TOTAL = total;


            // Retourne la liste des livres 
            return View(await items.ToListAsync());
        }


        // GET: GetTotal
        public decimal GetTotal(int? id)
        {
            decimal total = 0;

            // Récupère la liste des lignes (livres) insérer dans le panier (ID = id)
            var items =
                (from i in db.LINEITEMS
                 where i.ID_SHOPPINGCART == id
                 select i
                ); 

            // Calcul le montant total des livres mis dans le panier
            foreach (var item in items)
            {
                total += item.UNITPRICE;
            }

            return total; 

            // TODO Si erreur redirection 
            // return RedirectToAction("Index"); // Index -> Todo
        }


        // ///////////////////////////////////////////////////////////
        // Index 
        // //////////////////////////////////////////////////////////

        // GET: LineItems
        public async Task<ActionResult> Index()
        {
            var lINEITEMS = db.LINEITEMS.Include(l => l.BOOK).Include(l => l.SHOPPINGCART);
            return View(await lINEITEMS.ToListAsync());
        }


        // ///////////////////////////////////////////////////////////
        // DETAILS D'UNE LIGNGE DE COMMANDES / PANIER
        // ///////////////////////////////////////////////////////////

        // GET: LineItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEITEM lINEITEM = await db.LINEITEMS.FindAsync(id);
            if (lINEITEM == null)
            {
                return HttpNotFound();
            }
            return View(lINEITEM);
        }

        // ///////////////////////////////////////////////////////////
        // CREATE  
        // //////////////////////////////////////////////////////////

        // GET: LineItems/Create
        public ActionResult Create()
        {
            ViewBag.ID_BOOK = new SelectList(db.BOOKS, "ID", "TITLE");
            ViewBag.ID_SHOPPINGCART = new SelectList(db.SHOPPINGCARTS, "ID", "ID");
            return View();
        }

        // ___________________________________________________________


        // POST: LineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ID_SHOPPINGCART,ID_BOOK,QUANTITY,UNITPRICE,ID_ORDER")] LINEITEM lINEITEM)
        {
            if (ModelState.IsValid)
            {
                db.LINEITEMS.Add(lINEITEM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BOOK = new SelectList(db.BOOKS, "ID", "TITLE", lINEITEM.ID_BOOK);
            ViewBag.ID_SHOPPINGCART = new SelectList(db.SHOPPINGCARTS, "ID", "ID", lINEITEM.ID_SHOPPINGCART);
            return View(lINEITEM);
        }

        // ///////////////////////////////////////////////////////////
        // EDIT 
        // //////////////////////////////////////////////////////////
        // GET: LineItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEITEM lINEITEM = await db.LINEITEMS.FindAsync(id);
            if (lINEITEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BOOK = new SelectList(db.BOOKS, "ID", "TITLE", lINEITEM.ID_BOOK);
            ViewBag.ID_SHOPPINGCART = new SelectList(db.SHOPPINGCARTS, "ID", "ID", lINEITEM.ID_SHOPPINGCART);
            return View(lINEITEM);
        }

        // ___________________________________________________________

        // POST: LineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ID_SHOPPINGCART,ID_BOOK,QUANTITY,UNITPRICE,ID_ORDER")] LINEITEM lINEITEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lINEITEM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BOOK = new SelectList(db.BOOKS, "ID", "TITLE", lINEITEM.ID_BOOK);
            ViewBag.ID_SHOPPINGCART = new SelectList(db.SHOPPINGCARTS, "ID", "ID", lINEITEM.ID_SHOPPINGCART);
            return View(lINEITEM);
        }


        // ///////////////////////////////////////////////////////////
        // DELETE 
        // //////////////////////////////////////////////////////////
        // GET: LineItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEITEM lINEITEM = await db.LINEITEMS.FindAsync(id);
            if (lINEITEM == null)
            {
                return HttpNotFound();
            }
            return View(lINEITEM);
        }

        // ___________________________________________________________

        // POST: LineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LINEITEM lINEITEM = await db.LINEITEMS.FindAsync(id);
            db.LINEITEMS.Remove(lINEITEM);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ///////////////////////////////////////////////////////////
        // DISPOSE 
        // //////////////////////////////////////////////////////////
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }// End class 
}
