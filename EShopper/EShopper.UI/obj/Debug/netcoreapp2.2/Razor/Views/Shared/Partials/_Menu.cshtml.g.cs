#pragma checksum "C:\Users\Lenovo\Desktop\Kurs - Yazılım Uzmanlığı\E-Ticaret Proje\29-Localization\EShopper\EShopper.UI\Views\Shared\Partials\_Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c0b4a8d353c8db2578889f346cbe51958916cc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EShopper.Shared.Partials.Views_Shared_Partials__Menu), @"mvc.1.0.view", @"/Views/Shared/Partials/_Menu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Partials/_Menu.cshtml", typeof(EShopper.Shared.Partials.Views_Shared_Partials__Menu))]
namespace EShopper.Shared.Partials
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c0b4a8d353c8db2578889f346cbe51958916cc3", @"/Views/Shared/Partials/_Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe4b808bcd2b234e946b591cd46638e9c8bd2242", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partials__Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 64, true);
            WriteLiteral("<ul class=\"nav navbar-nav collapse navbar-collapse\">\r\n    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 64, "\"", 98, 1);
#line 2 "C:\Users\Lenovo\Desktop\Kurs - Yazılım Uzmanlığı\E-Ticaret Proje\29-Localization\EShopper\EShopper.UI\Views\Shared\Partials\_Menu.cshtml"
WriteAttributeValue("", 71, Url.Action("Index","Home"), 71, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(99, 1003, true);
            WriteLiteral(@" class=""active"">Home</a></li>
    <li class=""dropdown"">
        <a href=""#"">Shop<i class=""fa fa-angle-down""></i></a>
        <ul role=""menu"" class=""sub-menu"">
            <li><a href=""shop.html"">Products</a></li>
            <li><a href=""product-details.html"">Product Details</a></li>
            <li><a href=""checkout.html"">Checkout</a></li>
            <li><a href=""cart.html"">Cart</a></li>
            <li><a href=""login.html"">Login</a></li>
        </ul>
    </li>
    <li class=""dropdown"">
        <a href=""#"">Blog<i class=""fa fa-angle-down""></i></a>
        <ul role=""menu"" class=""sub-menu"">
            <li><a href=""blog.html"">Blog List</a></li>
            <li><a href=""blog-single.html"">Blog Single</a></li>
        </ul>
    </li>
    <li><a href=""404.html"">404</a></li>
    <li><a href=""contact-us.html"">Contact</a></li>
    <li class=""dropdown"">
        <a href=""#"">Admin<i class=""fa fa-angle-down""></i></a>
        <ul role=""menu"" class=""sub-menu"">
            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1102, "\"", 1144, 1);
#line 25 "C:\Users\Lenovo\Desktop\Kurs - Yazılım Uzmanlığı\E-Ticaret Proje\29-Localization\EShopper\EShopper.UI\Views\Shared\Partials\_Menu.cshtml"
WriteAttributeValue("", 1109, Url.Action("Index","AdminProduct"), 1109, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1145, 44, true);
            WriteLiteral(">Ürün İşlemleri</a></li>\r\n            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1189, "\"", 1232, 1);
#line 26 "C:\Users\Lenovo\Desktop\Kurs - Yazılım Uzmanlığı\E-Ticaret Proje\29-Localization\EShopper\EShopper.UI\Views\Shared\Partials\_Menu.cshtml"
WriteAttributeValue("", 1196, Url.Action("Index","AdminCategory"), 1196, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1233, 131, true);
            WriteLiteral(">Kategori İşlemleri</a></li>\r\n            <li><a href=\"blog-single.html\">Slider İşlemleri</a></li>\r\n        </ul>\r\n    </li>\r\n</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
