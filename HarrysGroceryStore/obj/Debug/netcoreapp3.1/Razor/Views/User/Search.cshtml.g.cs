#pragma checksum "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39178f41dd97ba531a0c93df9dae7fd86f33d24a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Search), @"mvc.1.0.view", @"/Views/User/Search.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\_ViewImports.cshtml"
using HarrysGroceryStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\_ViewImports.cshtml"
using HarrysGroceryStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39178f41dd97ba531a0c93df9dae7fd86f33d24a", @"/Views/User/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0d342fce2a7274806d2884211301ef86e3e8185", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<hr />\r\n");
#nullable restore
#line 5 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
 foreach (User u in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label class=\"font-weight-bold\"> First Name: </label> ");
#nullable restore
#line 7 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
                                                     Write(u.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Last Name: </label> ");
#nullable restore
#line 9 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
                                                    Write(u.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Phone Number: </label> ");
#nullable restore
#line 11 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
                                                       Write(u.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Email: </label> ");
#nullable restore
#line 13 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
                                                Write(u.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Choose a password: </label> ");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
                                                            Write(u.PassWord);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <hr />\r\n");
#nullable restore
#line 18 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\User\Search.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591