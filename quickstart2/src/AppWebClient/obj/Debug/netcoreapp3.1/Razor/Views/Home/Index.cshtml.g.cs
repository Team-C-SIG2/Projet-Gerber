<<<<<<< HEAD
#pragma checksum "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f4785f78881937cbed0b0db459aa8f1e125f37"
=======
#pragma checksum "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ccc4920ef5ba0a7b44bcbda47225688cf6c6ae8"
>>>>>>> Marc
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient.Models;

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f4785f78881937cbed0b0db459aa8f1e125f37", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a234f37d89bd743ee694131d35bbefb66ba5a", @"/Views/_ViewImports.cshtml")]
=======
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ccc4920ef5ba0a7b44bcbda47225688cf6c6ae8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695ee9e8cc6c987ba2b3c8fd5de334e346c2eca4", @"/Views/_ViewImports.cshtml")]
>>>>>>> Marc
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script type=\"text/javascript\" src=\"https://js.stripe.com/v2/\"></script>\r\n\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 4 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 4 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
  
    ViewBag.Title = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n\r\n<h1>Bienvenue sur ES-Bookshop</h1>\r\n<h4>Utilisateur : ");
#nullable restore
#line 19 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
             Write(ViewBag.USERID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<br />\r\n<div>\r\n    ");
#nullable restore
#line 22 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Connexion", "Index", "Connexion"));

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("<br />\r\n    <br />\r\n    <hr />\r\n    ");
#nullable restore
#line 25 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("About us", "About", "Home"));
=======
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 23 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Mon profil", "Index", "UserProfile"));
>>>>>>> Marc

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 26 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Contact", "Contact", "Home"));
=======
            WriteLiteral("<br />\r\n    <br />\r\n    <hr />\r\n    ");
#nullable restore
#line 26 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("About us", "About", "Home"));
>>>>>>> Marc

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 27 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 27 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Contact", "Contact", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 28 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Aide Stripe (service de paiement)", "About", "StripePay"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <br />\r\n    <hr />\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 30 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 31 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Liste des Appreciations", "Index", "Appreciations"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 31 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 32 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Liste des Categories", "Index", "Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n    <br />\r\n    <hr />\r\n\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 36 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 37 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Panier d'achat (Utilisateur)", "Index", new { Controller = "UserShoppingCarts", action = "Index", id = @ViewBag.USERID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 37 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 38 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Liste des paniers d'achat (Administration) ", "Index", "AdminShoppingCarts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <br />\r\n    <hr />\r\n    ");
#nullable restore
<<<<<<< HEAD
#line 40 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
=======
#line 41 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
>>>>>>> Marc
Write(Html.ActionLink("Liste des ouvrages", "Index", "Books"));

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
=======
            WriteLiteral("<br />\r\n    <hr />\r\n    ");
#nullable restore
#line 43 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Test call Api", "CallApi", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <hr />\r\n    ");
#nullable restore
#line 45 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\Home\Index.cshtml"
Write(Html.ActionLink("Logout", "Logout", "Home"));

#line default
#line hidden
#nullable disable
>>>>>>> Marc
            WriteLiteral("<br />\r\n    <hr />\r\n</div>\r\n\r\n\r\n<br/>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
