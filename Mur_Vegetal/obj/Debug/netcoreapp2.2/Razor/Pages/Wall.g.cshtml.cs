#pragma checksum "C:\Users\vande\OneDrive\Documents\PROJET\ProjDevLogi_WEB\Mur_Vegetal\Pages\Wall.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3ff29a7ddcc5aabd07e34f0f0b99276c2e7d8df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Mur_Vegetal.Pages.Pages_Wall), @"mvc.1.0.razor-page", @"/Pages/Wall.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Wall.cshtml", typeof(Mur_Vegetal.Pages.Pages_Wall), null)]
namespace Mur_Vegetal.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\vande\OneDrive\Documents\PROJET\ProjDevLogi_WEB\Mur_Vegetal\Pages\_ViewImports.cshtml"
using Mur_Vegetal;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3ff29a7ddcc5aabd07e34f0f0b99276c2e7d8df", @"/Pages/Wall.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74745f6a76c8f16ee2f524e02d1ab5f2603e4244", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Wall : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\vande\OneDrive\Documents\PROJET\ProjDevLogi_WEB\Mur_Vegetal\Pages\Wall.cshtml"
  
    ViewData["Title"] = "Mur Vegetal";

#line default
#line hidden
            DefineSection("heads", async() => {
                BeginContext(88, 9, true);
                WriteLiteral("\r\n  <link");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 97, "\"", 138, 1);
#line 7 "C:\Users\vande\OneDrive\Documents\PROJET\ProjDevLogi_WEB\Mur_Vegetal\Pages\Wall.cshtml"
WriteAttributeValue("", 104, Url.Content("~/css/wallpage.css"), 104, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(139, 38, true);
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
                EndContext();
            }
            );
            BeginContext(180, 63, true);
            WriteLiteral("\r\n\r\n<div class=\"wallpage-body\">\r\n    WALL\r\n</div>\r\n\r\n\r\n    \r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
