#pragma checksum "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f489854d6850ace025914712031472d5a9b8abc3"
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
#line 1 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\_ViewImports.cshtml"
using AppWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f489854d6850ace025914712031472d5a9b8abc3", @"/Views/StripePay/Charge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a234f37d89bd743ee694131d35bbefb66ba5a", @"/Views/_ViewImports.cshtml")]
    public class Views_StripePay_Charge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
  
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
#line 26 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
        Write(ViewBag.PUBLICKEY);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n\r\n\r\n    <tr>\r\n        <th>Clé privée</th>\r\n        <td>Pas publicée, pour des raisons de sécurité.</td>\r\n    </tr>\r\n\r\n\r\n");
            WriteLiteral("\r\n    <tr>\r\n        <th>Clé API</th>\r\n        <td>Pas publicée, pour des raisons de sécurité.</td>\r\n    </tr>\r\n\r\n\r\n    <tr>\r\n        <th>Paiement en faveur de ES-Bookshop/th>\r\n        <td>");
#nullable restore
#line 48 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
       Write(ViewBag.MONTANT);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n\r\n\r\n</table>\r\n\r\n\r\n<div>\r\n    <br />\r\n    <hr />\r\n    ");
#nullable restore
#line 58 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
Write(Html.ActionLink("Accueil", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 59 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\StripePay\Charge.cshtml"
Write(Html.ActionLink("Panier", "Index", new { Controller = "UserShoppingCarts", action = "Index", id = @ViewBag.USERID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <br />\r\n    <hr />\r\n</div>\r\n\r\n\r\n");
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
