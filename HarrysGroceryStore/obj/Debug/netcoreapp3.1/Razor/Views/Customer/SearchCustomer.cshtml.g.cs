#pragma checksum "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5e650ed5f92348074f7005bd12c76917c009149"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_SearchCustomer), @"mvc.1.0.view", @"/Views/Customer/SearchCustomer.cshtml")]
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
#nullable restore
#line 3 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\_ViewImports.cshtml"
using HarrysGroceryStore.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5e650ed5f92348074f7005bd12c76917c009149", @"/Views/Customer/SearchCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a05761d455cbf7c0c0f121e153c8af2860c215b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_SearchCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Customer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<hr />\r\n");
#nullable restore
#line 5 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
 foreach (Customer c in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label class=\"font-weight-bold\"> Customer Id: </label> ");
#nullable restore
#line 7 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                      Write(c.CustomerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> First Name: </label> ");
#nullable restore
#line 9 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                     Write(c.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Last Name: </label> ");
#nullable restore
#line 11 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                    Write(c.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Phone Number: </label> ");
#nullable restore
#line 13 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                       Write(c.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> Address: </label> ");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                  Write(c.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> City: </label> ");
#nullable restore
#line 17 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                               Write(c.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> State: </label> ");
#nullable restore
#line 19 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                Write(c.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <label class=\"font-weight-bold\"> ZipCode: </label> ");
#nullable restore
#line 21 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
                                                  Write(c.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <hr />\r\n");
#nullable restore
#line 24 "C:\Users\Admin\source\repos\HarrysGroceryStore\HarrysGroceryStore\Views\Customer\SearchCustomer.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
