#pragma checksum "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc9a41345baecad28aa33251abf39e02b9322238"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Walkers_Index), @"mvc.1.0.view", @"/Views/Walkers/Index.cshtml")]
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
#line 1 "C:\Users\josep\workspace\DogGo\DogGo\Views\_ViewImports.cshtml"
using DogGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josep\workspace\DogGo\DogGo\Views\_ViewImports.cshtml"
using DogGo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc9a41345baecad28aa33251abf39e02b9322238", @"/Views/Walkers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b50fd1f91f777ae09abf39d99992ea9d25da6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Walkers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DogGo.Models.ViewModels.LocalWalkerListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Our Loyal Walkers!</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc9a41345baecad28aa33251abf39e02b93222383620", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Avatars
            </th>
            <th>
                Walker
            </th>
            <th>
                Neighborhoods
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 29 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
 foreach (var item in Model.Walker) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 584, "\"", 616, 2);
            WriteAttributeValue("", 591, "/Walkers/Details/", 591, 17, true);
#nullable restore
#line 32 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
WriteAttributeValue("", 608, item.Id, 608, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 622, "\"", 642, 1);
#nullable restore
#line 32 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
WriteAttributeValue("", 628, item.ImageUrl, 628, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Walker avatar\" /></a>\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 39 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
                 foreach (Neighborhood neighborhood in Model.Neighborhoods)
                {
                    if (neighborhood.Id == item.NeighborhoodId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 43 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
                      Write(neighborhood.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 44 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\josep\workspace\DogGo\DogGo\Views\Walkers\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DogGo.Models.ViewModels.LocalWalkerListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
