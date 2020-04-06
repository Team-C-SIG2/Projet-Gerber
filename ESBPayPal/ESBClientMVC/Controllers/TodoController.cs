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


using PayPal.Api;
namespace ESBClientMVC.Controllers
{
    // [Route("api/YOURCONTROLLER/{paramOne}/{paramTwo}")]
    public class TodoController : Controller
    {
        private readonly ESBookshop db = new ESBookshop();

        //public int Total; 


        // //////////////////////////////////////////////////////////////////
        // METHODES POUR INSERER ET SUPPRIMER UN ARTICLE DU PANIER D'ACHAT 
        // /////////////////////////////////////////////////////////////////


        // GET: Shoppingcarts/AddToCart/{paramOne}/{paramTwo}
        [Route("Shoppingcarts/AddToCart/{cart}/{book}/{quantity}")]
        public async Task<ActionResult> AddToCart(int cart, int book, int quantity)
        {
            var lineItem = new LINEITEM
            {
                ID_BOOK = book,
                QUANTITY = quantity,
                ID_SHOPPINGCART = cart,
                UNITPRICE = db.BOOKS.SingleOrDefault(l => l.ID == book).PRICE
            };

            db.LINEITEMS.Add(lineItem);

            // db.SaveChanges();
            await db.SaveChangesAsync();

            // return View(lineItem.SHOPPINGCART);
            return RedirectToAction("Index"); // Index -> Todo
        }

        // GET: Shoppingcarts/GetCartItems/{paramOne}
        [Route("Shoppingcarts/GetCartItems/{cart}")]
        public async Task<ActionResult> GetCartItems(int cart)
        {
            // Rechercher les éléments (lignes de commandes / livres) d'un panier 
            var items = db.LINEITEMS.Where(l => l.ID_SHOPPINGCART == cart).Include(l => l.BOOK);
            return View(await items.ToListAsync());
        }


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


        // GET: GetTotal
        public ActionResult GetTotal(int? cart)
        {
            ViewBag.TOTAL = db.LINEITEMS.Where(l => l.ID_SHOPPINGCART == cart).Select(s => s.UNITPRICE * s.QUANTITY).Sum();
            return RedirectToAction("Index"); // Index -> Todo
        }

        

    }// End class 
}
