#pragma checksum "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "798693c2f44297e6abac2021c628292892fd1a2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__StatusMessage), @"mvc.1.0.view", @"/Views/Admin/_StatusMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/_StatusMessage.cshtml", typeof(AspNetCore.Views_Admin__StatusMessage))]
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
#line 1 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\_ViewImports.cshtml"
using BookingForm;

#line default
#line hidden
#line 2 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\_ViewImports.cshtml"
using BookingForm.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"798693c2f44297e6abac2021c628292892fd1a2d", @"/Views/Admin/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Request") ? "success" : "danger";
    if (statusMessageClass == "danger")
    {
        statusMessageClass = Model.StartsWith("Your") ? "success" : "danger";
    }

#line default
#line hidden
            BeginContext(272, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 280, "\"", 337, 4);
            WriteAttributeValue("", 288, "alert", 288, 5, true);
            WriteAttributeValue(" ", 293, "alert-", 294, 7, true);
#line 10 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\_StatusMessage.cshtml"
WriteAttributeValue("", 300, statusMessageClass, 300, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 319, "alert-dismissible", 320, 18, true);
            EndWriteAttribute();
            BeginContext(338, 158, true);
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n        ");
            EndContext();
            BeginContext(497, 5, false);
#line 12 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\_StatusMessage.cshtml"
   Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(502, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 14 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\_StatusMessage.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
