#pragma checksum "C:\Users\ivanl\source\repos\UserManager\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b619846e8ca77381dac07276bb19585eaae86a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\ivanl\source\repos\UserManager\Views\_ViewImports.cshtml"
using UserManager;

#line default
#line hidden
#line 2 "C:\Users\ivanl\source\repos\UserManager\Views\_ViewImports.cshtml"
using UserManager.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b619846e8ca77381dac07276bb19585eaae86a5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4463a27c45958bd045a6d0ed9eb8036f8364f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 460, true);
            WriteLiteral(@"

<div class=""wrapper"">
    <div class=""sidebar"">
        <ul class=""list-unstyled"">
            <li><a class=""active"" href=""/"">Home</a></li>
            <li><a href=""/Users/ChangePassword"">Change Password</a></li>
            <li><a href=""/Users/Log Out"">Log Out</a></li>
        </ul>
    </div>
    <div class=""content"">
        <div class=""container-fluid"">
            <div class=""text-center"">
                <h1 class=""display-4"">Welcome, ");
            EndContext();
            BeginContext(468, 16, false);
#line 16 "C:\Users\ivanl\source\repos\UserManager\Views\Home\Index.cshtml"
                                          Write(ViewBag.userName);

#line default
#line hidden
            EndContext();
            BeginContext(484, 63, true);
            WriteLiteral("</h1>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
