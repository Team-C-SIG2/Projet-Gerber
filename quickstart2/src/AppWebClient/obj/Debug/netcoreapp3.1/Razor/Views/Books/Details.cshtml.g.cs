#pragma checksum "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31a760772eeb13d9abf03696c87b9e51ffb81df9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Details), @"mvc.1.0.view", @"/Views/Books/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31a760772eeb13d9abf03696c87b9e51ffb81df9", @"/Views/Books/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084a234f37d89bd743ee694131d35bbefb66ba5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppWebClient.Models.Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Book</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Subtitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 28 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
             if (@Model.Subtitle != null)
            {

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
              Write(Model.Subtitle);

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                                         }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 31 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DatePublication));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 49 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
             if (@Model.DatePublication != null)
            {

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
        Write(Html.DisplayFor(model => model.DatePublication));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                                                             }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 52 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 61 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
             if (@Model.Summary != null)
            {

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
              Write(Model.Summary);

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                                        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 64 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Isbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayFor(model => model.Isbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 79 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdEditorNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 82 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdEditorNavigation.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31a760772eeb13d9abf03696c87b9e51ffb81df910877", async() => {
                WriteLiteral("Editer");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31a760772eeb13d9abf03696c87b9e51ffb81df913026", async() => {
                WriteLiteral("Retour à la liste");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31a760772eeb13d9abf03696c87b9e51ffb81df914199", async() => {
                WriteLiteral("Ajouter au panier");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\DEV\projet\Projet-Gerber\quickstart2\src\AppWebClient\Views\Books\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppWebClient.Models.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
