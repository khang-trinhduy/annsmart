#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1c08be1bfd84bcd7ea562fca020c2abdce6322d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appoinments_Delete), @"mvc.1.0.view", @"/Views/Appoinments/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Appoinments/Delete.cshtml", typeof(AspNetCore.Views_Appoinments_Delete))]
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
#line 1 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\_ViewImports.cshtml"
using BookingForm;

#line default
#line hidden
#line 2 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\_ViewImports.cshtml"
using BookingForm.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1c08be1bfd84bcd7ea562fca020c2abdce6322d", @"/Views/Appoinments/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Appoinments_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookingForm.Models.Appoinment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
  
    ViewData["Title"] = "Xóa -";

#line default
#line hidden
            BeginContext(76, 162, true);
            WriteLiteral("\n<h2>Delete</h2>\n\n<h3>Are you sure you want to delete this?</h3>\n<div>\n    <h4>Appoinment</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
            EndContext();
            BeginContext(239, 44, false);
#line 15 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer));

#line default
#line hidden
            EndContext();
            BeginContext(283, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(324, 40, false);
#line 18 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Customer));

#line default
#line hidden
            EndContext();
            BeginContext(364, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(405, 42, false);
#line 21 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(447, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(488, 38, false);
#line 24 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(526, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(567, 43, false);
#line 27 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(610, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(651, 39, false);
#line 30 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(690, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(731, 41, false);
#line 33 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(772, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(813, 37, false);
#line 36 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(850, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(891, 41, false);
#line 39 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(932, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(973, 37, false);
#line 42 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1051, 39, false);
#line 45 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Job));

#line default
#line hidden
            EndContext();
            BeginContext(1090, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1131, 35, false);
#line 48 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Job));

#line default
#line hidden
            EndContext();
            BeginContext(1166, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1207, 45, false);
#line 51 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.WorkPlace));

#line default
#line hidden
            EndContext();
            BeginContext(1252, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1293, 41, false);
#line 54 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.WorkPlace));

#line default
#line hidden
            EndContext();
            BeginContext(1334, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1375, 40, false);
#line 57 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cmnd));

#line default
#line hidden
            EndContext();
            BeginContext(1415, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1456, 36, false);
#line 60 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cmnd));

#line default
#line hidden
            EndContext();
            BeginContext(1492, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1533, 39, false);
#line 63 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Day));

#line default
#line hidden
            EndContext();
            BeginContext(1572, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1613, 35, false);
#line 66 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Day));

#line default
#line hidden
            EndContext();
            BeginContext(1648, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1689, 41, false);
#line 69 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Place));

#line default
#line hidden
            EndContext();
            BeginContext(1730, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1771, 37, false);
#line 72 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Place));

#line default
#line hidden
            EndContext();
            BeginContext(1808, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1849, 43, false);
#line 75 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Purpose));

#line default
#line hidden
            EndContext();
            BeginContext(1892, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1933, 39, false);
#line 78 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Purpose));

#line default
#line hidden
            EndContext();
            BeginContext(1972, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2013, 44, false);
#line 81 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Requires));

#line default
#line hidden
            EndContext();
            BeginContext(2057, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2098, 40, false);
#line 84 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Requires));

#line default
#line hidden
            EndContext();
            BeginContext(2138, 49, true);
            WriteLiteral("\n        </dd>\n        \n        <dt>\n            ");
            EndContext();
            BeginContext(2188, 41, false);
#line 88 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2229, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2270, 37, false);
#line 91 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2307, 49, true);
            WriteLiteral("\n        </dd>\n        \n        <dt>\n            ");
            EndContext();
            BeginContext(2357, 43, false);
#line 95 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Details));

#line default
#line hidden
            EndContext();
            BeginContext(2400, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2441, 39, false);
#line 98 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Details));

#line default
#line hidden
            EndContext();
            BeginContext(2480, 34, true);
            WriteLiteral("\n        </dd>\n    </dl>\n    \n    ");
            EndContext();
            BeginContext(2514, 203, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96f7338921ed459aba4d847c81412d26", async() => {
                BeginContext(2540, 9, true);
                WriteLiteral("\n        ");
                EndContext();
                BeginContext(2549, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7fc7cb553d434649b74471b00958140e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 103 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Appoinments\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2585, 82, true);
                WriteLiteral("\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\n        ");
                EndContext();
                BeginContext(2667, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f53f25a652bb43379d1518701fbc872e", async() => {
                    BeginContext(2689, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2705, 5, true);
                WriteLiteral("\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2717, 8, true);
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookingForm.Models.Appoinment> Html { get; private set; }
    }
}
#pragma warning restore 1591
