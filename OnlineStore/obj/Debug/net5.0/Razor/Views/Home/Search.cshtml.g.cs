#pragma checksum "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09fb3f1d8ededbf2ce630b1569563a1c4af3b105"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
#line 1 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09fb3f1d8ededbf2ce630b1569563a1c4af3b105", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11493c7ecec087e3ee6552288a205f3b54d5a8af", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Collections.Generic.List<OnlineStore.Models.LocalizedProduct>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
  
    ViewBag.Title = Localizer["Search"];
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 10 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
Write(Localizer["SearchResults"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"main-container\">\r\n    <aside>\r\n        ");
#nullable restore
#line 14 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
   Write(await Html.PartialAsync("_Sidebar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </aside>\r\n    \r\n    <div class=\"main-page\">\r\n");
#nullable restore
#line 18 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 20 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
          Write(Localizer["NoSearchResults"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
             for (int i = 0; i <= Model.Count / 3; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"goods-row\">\r\n");
#nullable restore
#line 27 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
                     for (int j = i * 3; j < i * 3 + 3; j++)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
                   Write(await Html.PartialAsync("_GoodsPost", Model[j]));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
                                                                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 32 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Home\Search.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.List<OnlineStore.Models.LocalizedProduct>> Html { get; private set; }
    }
}
#pragma warning restore 1591
