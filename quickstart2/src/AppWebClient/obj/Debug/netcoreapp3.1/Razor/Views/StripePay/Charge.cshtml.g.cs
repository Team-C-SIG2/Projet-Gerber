#pragma checksum "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff2f3482a53e6eff676f89a860f88c435f2458b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StripePay_Charge), @"mvc.1.0.view", @"/Views/StripePay/Charge.cshtml")]
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
#line 1 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff2f3482a53e6eff676f89a860f88c435f2458b", @"/Views/StripePay/Charge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695ee9e8cc6c987ba2b3c8fd5de334e346c2eca4", @"/Views/_ViewImports.cshtml")]
    public class Views_StripePay_Charge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
  
    ViewData["Title"] = "Charge";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h1>Résultat de la transaction Stripe</h1>
<p>Vous venez d'effectuer un paiement en ligne avec Stripe. Ci-dessous les valeurs retournées par le serveur API ES-Bookshop.</p>


<h3>Clés du compte Stripe</h3>

<br />

<table class=""table"">


    <tr>
        <th>Type </th>
        <th>Valeur </th>
    </tr>


    <tr>
        <th>Clé publique</th>
        <td> ");
#nullable restore
#line 26 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
        Write(ViewBag.PUBLICKEY);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n\n\n    <tr>\n        <th>Clé privée</th>\n        <td>Pas publicée, pour des raisons de sécurité.</td>\n    </tr>\n\n\n");
            WriteLiteral("\n    <tr>\n        <th>Clé API</th>\n        <td>Pas publicée, pour des raisons de sécurité.</td>\n    </tr>\n\n\n    <tr>\n        <th>Paiement en faveur de ES-Bookshop/th>\n        <td>");
#nullable restore
#line 48 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
       Write(ViewBag.MONTANT);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n\n\n</table>\n\n\n<div>\n    <br />\n    <hr />\n    ");
#nullable restore
#line 58 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
Write(Html.ActionLink("Accueil", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n    ");
#nullable restore
#line 59 "D:\Cours ETML-ES\Developpement C# et projet informatique\Projet-Gerber\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
Write(Html.ActionLink("Panier", "Index", new { Controller = "UserShoppingCarts", action = "Index", id = @ViewBag.USERID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n    <br />\n    <hr />\n</div>\n\n\n");
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
