using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ESBClientMVC
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*

             // Tutoriel :   https://openclassrooms.com/fr/courses/1730206-apprenez-asp-net-mvc/1828206-les-routes

                routes.MapRoute(
                    name: "Ajouter",
                    url: "Ajouter/{valeur1}/{valeur2}",
                    defaults: new { controller = "Calculateur", action = "Ajouter" });


                // CONTROLEUR 
                public class CalculateurController : Controller
                {
                    public string Ajouter(int valeur1, int valeur2)
                    {
                        int resultat = valeur1 + valeur2;
                        return resultat.ToString();
                    }

                    public string Soustraire(int valeur1, int valeur2)
                    {
                        return (valeur1 - valeur2).ToString();
                    }
                }

            // Ainsi, la route /Soustraire/10/4 renverra sans surprise 6.
            // La route  /Calculatrice-Ajouter/2-4 donnera 6 (2+4)


            */

            routes.MapRoute(
                name: "LineItems",
                url: "LineItems/Items/{cart}",
                defaults: new { controller = "LineItems", action = "GetCartItems"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); // /Home/Index/123

            // Ainsi, une requête /Home/Index/123 permettra d’appeler la méthode suivante :

            /* 

                public class HomeController : Controller
                {
                    public string Index(string id)
                    {
                        return "HomeController.Index " + id;
                    }
                }
            
            */

            // Ce qui affichera la chaîne HomeController.Index 123.

        }
    }
}
