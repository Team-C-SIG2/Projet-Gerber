using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using ESBClientMVC.PayPalService;
using ESBClientMVC.Models; 

namespace ESBClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private Payment payment = new Payment();
        private readonly ESBookshop db = new ESBookshop();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentWithPaypal(int? id, string Cancel = null)
        {
            //getting the apiContext
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal
                //Payer Id will be returned when payment proceeds or click to pay
                string payerId = Request.Params["PayerID"];

                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist
                    //it is returned by the create function call of the payment class

                    // Creating a payment
                    // baseURL is the url on which paypal sendsback the data.
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                "/Home/PaymentWithPayPal?";

                    //here we are generating guid for storing the paymentID received in session
                    //which will be used in the payment execution

                    var guid = Convert.ToString((new Random()).Next(100000));

                    //CreatePayment function gives us the payment approval url
                    //on which payer is redirected for paypal account payment

                    var createdPayment = this.CreatePayment(id, apiContext, baseURI + "guid=" + guid);

                    //get links returned from paypal in response to Create function call

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = null;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    // saving the paymentID in the key guid
                    Session.Add(guid, createdPayment.id);

                    return Redirect(paypalRedirectUrl);
                }
                else
                {

                    // This function exectues after receving all parameters for the payment

                    var guid = Request.Params["guid"];

                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                    //If executed payment failed then we will show payment failure message to user
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }

            //on successful payment, show success page to user.
            return View("SuccessView");
        }


        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private Payment CreatePayment(int? id, APIContext apiContext, string redirectUrl)
        {
            // Récupère la liste des lignes (livres) insérer dans le panier (ID = id)
            var items =
                (from i in db.LINEITEMS
                 where i.ID_SHOPPINGCART == id
                 select i
                );

            // Calcul du prix Total du panier (id)
            decimal prixTotal = 0;
            foreach (var item in items)
            {
                prixTotal += item.UNITPRICE;
            }



            // Convertir en entier 
            int n = Convert.ToInt32(prixTotal);

            // Convertir en string 
            // n.ToString(); 



            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };

            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = "ESBookshop item",
                currency = "USD",
                price = n.ToString(), // PRIX LIGNes
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };



            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = n.ToString() // PRIX BRUT
        };



            // Calcul of total amount 
            decimal totalAmount = decimal.Parse(details.tax) + decimal.Parse(details.shipping) + decimal.Parse(details.subtotal);

            // Convertir en entier 
            int n2 = Convert.ToInt32(totalAmount);

            // Convertir en string 
            // n.ToString(); 

            //Final amount with details
            var amount = new Amount()
            {
                currency = "USD",
                total = n2.ToString(), // PRIX NET 
                details = details
            };



            // INVOICE MUMBER
            Random rand = new Random();
            int numIterations = 0;
            numIterations = rand.Next(1, 10000000);



            // CREATE TRANSACTION DESCRIPTION          
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Transaction ESBOOKSHOP",
                invoice_number = numIterations.ToString(), // GENERATED AN INVOICE NUMBER 
                amount = amount,
                item_list = itemList
            });


            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
        }



    }
}