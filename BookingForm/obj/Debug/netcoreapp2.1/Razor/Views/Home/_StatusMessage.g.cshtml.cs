#pragma checksum "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6354ac17881ba3490ab38505436e000bbde5d0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__StatusMessage), @"mvc.1.0.view", @"/Views/Home/_StatusMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_StatusMessage.cshtml", typeof(AspNetCore.Views_Home__StatusMessage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6354ac17881ba3490ab38505436e000bbde5d0c", @"/Views/Home/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Feedback") ? "danger" : "success";
    if (statusMessageClass != "danger")
    {
        statusMessageClass = Model.StartsWith("Request") ? "danger" : "success";
    }
    if (statusMessageClass != "danger")
    {
        statusMessageClass = Model.StartsWith("Khách") ? "danger" : "success";
    }


#line default
#line hidden
            BeginContext(413, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 421, "\"", 478, 4);
            WriteAttributeValue("", 429, "alert", 429, 5, true);
            WriteAttributeValue(" ", 434, "alert-", 435, 7, true);
#line 15 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\_StatusMessage.cshtml"
WriteAttributeValue("", 441, statusMessageClass, 441, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 460, "alert-dismissible", 461, 18, true);
            EndWriteAttribute();
            BeginContext(479, 158, true);
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n        ");
            EndContext();
            BeginContext(638, 5, false);
#line 17 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\_StatusMessage.cshtml"
   Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(643, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 19 "c:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\_StatusMessage.cshtml"
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
