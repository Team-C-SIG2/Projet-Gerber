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
    // [Route("api/YOURCONTROLLER/{paramOne}/{paramTwo}")]
    public class ShoppingcartsController : Controller
    {
        private ESBookshop db = new ESBookshop();

        //public int Total; 

        // //////////////////////////////////////////////////////////////////
        // METHODES POUR INSERER ET SUPPRIMER UN ARTICLE DU PANIER D'ACHAT 
        // /////////////////////////////////////////////////////////////////


        // ___________________________________________________________

        // GET: Shoppingcarts/AddToCart/{paramOne}/{paramTwo}
        [Route("Shoppingcarts/AddToCart/{cart}/{book}/{quantity}")]
        public async Task<ActionResult> AddToCart(int cart, int book, int quantity)
        {
            var lineItem = new LINEITEM();
            lineItem.ID_BOOK = book; 
            lineItem.QUANTITY = quantity;
            lineItem.ID_SHOPPINGCART = cart;
            lineItem.UNITPRICE = db.BOOKS.SingleOrDefault(l => l.ID == book).PRICE;

            db.LINEITEMS.Add(lineItem);
            
            // db.SaveChanges();
            await db.SaveChangesAsync();

            // return View(lineItem.SHOPPINGCART); 
            return RedirectToAction("Index"); // Index -> Todo
        }

        // ___________________________________________________________

        // GET: Shoppingcarts/GetCartItems/{paramOne}
        [Route("Shoppingcarts/GetCartItems/{cart}")]
        public async Task<ActionResult> GetCartItems(int? cart)
        {
            // Rechercher les éléments (lignes de commandes / livres) d'un panier 
            var items = db.LINEITEMS.Where(l => l.ID_SHOPPINGCART == cart).Include(l => l.BOOK);
            return View(await items.ToListAsync());
        }

        // ___________________________________________________________

        // POST: Shoppingcarts/GetCartItems/{paramOne}/{paramTwo}
        [Route("Shoppingcarts/Remove/{book}")]
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveBookConfirmed(int? book)
        {
            var line = db.LINEITEMS.SingleOrDefault(l => l.ID_BOOK == book);
            var retour = line;
            var localQuantity = 0;


            if (book == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Si plusieurs livres 
            if (line != null)
            {
                if (line.QUANTITY > 1)
                {
                    line.QUANTITY--;
                    localQuantity = line.QUANTITY;
                }
                else
                {
                    db.LINEITEMS.Remove(line);
                    
                    // Si un seul livre 
                    
                    line = null;
                }
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction("Index"); // Index -> Todo


        }

        // ___________________________________________________________
        // GET: Shoppingcarts/RemoveBook/5
        public async Task<ActionResult> RemoveBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LINEITEM line = await db.LINEITEMS.FindAsync(id);

            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // ___________________________________________________________
        // GET: GetTotal
        public ActionResult GetTotal(int cart)
        {
            ViewBag.TOTAL = db.LINEITEMS.Where(l => l.ID_SHOPPINGCART == cart).Select(s => s.UNITPRICE * s.QUANTITY).Sum();
            return RedirectToAction("Index"); // Index -> Todo
        }

        // ///////////////////////////////////////////////////////////
        // LIST - INDEX 
        // //////////////////////////////////////////////////////////

        // GET: Shoppingcarts
        public async Task<ActionResult> Index()
        {
            var sHOPPINGCARTS = db.SHOPPINGCARTS.Include(s => s.ACCOUNT).Include(l => l.LINEITEMS);
            var Accounts = db.ACCOUNTS;
            var LineItems = db.LINEITEMS;


            //  db.LINEITEMS.Where(l => l.ID_SHOPPINGCART == cart).Select(s => s.UNITPRICE * s.QUANTITY).Sum();
            //  ViewData["LineItems"] = db.LINEITEMS; 



            return View(await sHOPPINGCARTS.ToListAsync());
        }


        // ///////////////////////////////////////////////////////////
        // DETAIL  
        // //////////////////////////////////////////////////////////

        // GET: Shoppingcarts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            SHOPPINGCART shoppcart; 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                shoppcart = await db.SHOPPINGCARTS.FindAsync(id);
            }

            if (shoppcart == null)
            {
                return HttpNotFound();
            }
      
            return View(shoppcart);
        }


        // ///////////////////////////////////////////////////////////
        // CREATE 
        // //////////////////////////////////////////////////////////
        // GET: Shoppingcarts/Create
        public ActionResult Create()
        {
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD");
            return View();
        }

        // ___________________________________________________________

        // POST: Shoppingcarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CREATEDDATE,ID_ACCOUNT")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.SHOPPINGCARTS.Add(sHOPPINGCART);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", sHOPPINGCART.ID_ACCOUNT);
            return View(sHOPPINGCART);
        }

        // ///////////////////////////////////////////////////////////
        // EDIT 
        // //////////////////////////////////////////////////////////

        // GET: Shoppingcarts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = await db.SHOPPINGCARTS.FindAsync(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", sHOPPINGCART.ID_ACCOUNT);
            return View(sHOPPINGCART);
        }


        // ///////////////////////////////////////////////////////////

        // POST: Shoppingcarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CREATEDDATE,ID_ACCOUNT")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPPINGCART).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ACCOUNT = new SelectList(db.ACCOUNTS, "ID", "PASSWORD", sHOPPINGCART.ID_ACCOUNT);
            return View(sHOPPINGCART);
        }


        // ///////////////////////////////////////////////////////////
        // DELETE 
        // //////////////////////////////////////////////////////////
        // GET: Shoppingcarts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = await db.SHOPPINGCARTS.FindAsync(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPPINGCART);
        }

        // ___________________________________________________________

        // POST: Shoppingcarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SHOPPINGCART sHOPPINGCART = await db.SHOPPINGCARTS.FindAsync(id);
            db.SHOPPINGCARTS.Remove(sHOPPINGCART);
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
