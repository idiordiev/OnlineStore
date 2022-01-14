#pragma checksum "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b992b706359b278ad5abba045f6a7e06e2329320"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ShoppingCart), @"mvc.1.0.view", @"/Views/Account/ShoppingCart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b992b706359b278ad5abba045f6a7e06e2329320", @"/Views/Account/ShoppingCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11493c7ecec087e3ee6552288a205f3b54d5a8af", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ShoppingCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineStore.Models.ViewModels.ShoppingCartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 9 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
Write(Localizer["Cart"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
 if (Model.Products.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 13 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
  Write(Localizer["NoGoods"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 14 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 20 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
           Write(Localizer["Image"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 21 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
           Write(Localizer["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 22 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
           Write(Localizer["Price"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th></th>\r\n        </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
         foreach (var product in Model.Products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><img");
            BeginWriteAttribute("src", " src=\"", 639, "\"", 663, 1);
#nullable restore
#line 30 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
WriteAttributeValue("", 645, product.ImageLink, 645, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/></td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n            </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 38 "C:\Users\Ivan\RiderProjects\OnlineStore\OnlineStore\Views\Account\ShoppingCart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineStore.Models.ViewModels.ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
