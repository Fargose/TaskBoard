#pragma checksum "D:\TaskBoard\TaskBoard.WEB\Views\Home\Contacts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dd0aca3a995b5f4eeeb72ac29005b421ecd37b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contacts), @"mvc.1.0.view", @"/Views/Home/Contacts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contacts.cshtml", typeof(AspNetCore.Views_Home_Contacts))]
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
#line 1 "D:\TaskBoard\TaskBoard.WEB\Views\_ViewImports.cshtml"
using TaskBoard.WEB;

#line default
#line hidden
#line 2 "D:\TaskBoard\TaskBoard.WEB\Views\_ViewImports.cshtml"
using TaskBoard.WEB.Models;

#line default
#line hidden
#line 1 "D:\TaskBoard\TaskBoard.WEB\Views\Home\Contacts.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dd0aca3a995b5f4eeeb72ac29005b421ecd37b0", @"/Views/Home/Contacts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0b7096f1fc510f80ca551a137c01aeeebfff986", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contacts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(82, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(89, 21, false);
#line 5 "D:\TaskBoard\TaskBoard.WEB\Views\Home\Contacts.cshtml"
Write(Localizer["Contacts"]);

#line default
#line hidden
            EndContext();
            BeginContext(110, 47, true);
            WriteLiteral("</h1>\r\n<h2>email: oleksii.roik@gmail.com</h2>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
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
