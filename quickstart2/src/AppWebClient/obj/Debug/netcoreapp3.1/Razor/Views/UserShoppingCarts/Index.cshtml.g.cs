#pragma checksum "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ff4cf60881e99d785407801709adc1e55679172"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserShoppingCarts_Index), @"mvc.1.0.view", @"/Views/UserShoppingCarts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ff4cf60881e99d785407801709adc1e55679172", @"/Views/UserShoppingCarts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a234f37d89bd743ee694131d35bbefb66ba5a", @"/Views/_ViewImports.cshtml")]
    public class Views_UserShoppingCarts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppWebClient.Models.ShoppingCart>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                     
    var USER = ViewData["USER"] as AppWebClient.Models.AspNetUser;



    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Bienvenue ");
#nullable restore
#line 17 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
             Write(USER.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\r\n");
#nullable restore
#line 19 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
Write(USER.Email);

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
               ;

    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n\r\n        <h4>Panier d\'achat </h4>\r\n        <hr />\r\n        <dl class=\"row\">\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                ");
#nullable restore
#line 31 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n                ");
#nullable restore
#line 34 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
           Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                ");
#nullable restore
#line 40 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 43 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                 if (@Model.User.PhoneNumber != null)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                  Write(Model.User.PhoneNumber);

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                     }
                else{

#line default
#line hidden
#nullable disable
            WriteLiteral("Inconnu");
#nullable restore
#line 45 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                Email\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 54 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                 if (@USER.Email != null)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                  Write(USER.Email);

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                         }
                else{

#line default
#line hidden
#nullable disable
            WriteLiteral("Inconnu");
#nullable restore
#line 56 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                Nom\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 65 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                 if (@USER.IdCustomerNavigation.Lastname != null)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                  Write(USER.IdCustomerNavigation.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 66 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                       Write(USER.IdCustomerNavigation.Lastname);

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                                                                      }
                else{

#line default
#line hidden
#nullable disable
            WriteLiteral("Indisponible");
#nullable restore
#line 67 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                Adresse\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 76 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                 if (@USER.IdCustomerNavigation.Address != null)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                  Write(USER.IdCustomerNavigation.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 77 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                       Write(USER.IdCustomerNavigation.Zip);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 77 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                                                      Write(USER.IdCustomerNavigation.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 77 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                                                                                                  }
                else {

#line default
#line hidden
#nullable disable
            WriteLiteral("Indisponible");
#nullable restore
#line 78 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-4\">\r\n                Adresse de facturation\r\n            </dt>\r\n            <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 87 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                 if (@USER.IdCustomerNavigation.BillingAddress != null)
                {

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                  Write(USER.IdCustomerNavigation.BillingAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 88 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                                                        }
                else{

#line default
#line hidden
#nullable disable
            WriteLiteral("Indisponible");
#nullable restore
#line 89 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n\r\n        </dl>\r\n    </div>\r\n");
            WriteLiteral("    <div>\r\n\r\n        <br />\r\n        <hr />\r\n        ");
#nullable restore
#line 103 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
   Write(Html.ActionLink("Retour à accueil", "Index", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 104 "C:\DEV\hb\ESB_SPRINT1_HB_V1\quickstart2\src\AppWebClient\Views\UserShoppingCarts\Index.cshtml"
   Write(Html.ActionLink("Contenu du panier", "Index", new { Controller = "Lineitems", action = "Index", id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        <br />\r\n        <hr />\r\n\r\n\r\n\r\n\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppWebClient.Models.ShoppingCart> Html { get; private set; }
    }
}
#pragma warning restore 1591
