#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d6c088102db8a27f226c53dd33231b6d968143b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RequestsControl), @"mvc.1.0.view", @"/Views/Home/RequestsControl.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/RequestsControl.cshtml", typeof(AspNetCore.Views_Home_RequestsControl))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d6c088102db8a27f226c53dd33231b6d968143b", @"/Views/Home/RequestsControl.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RequestsControl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookingForm.Models.Request>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RequestDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#ConfirmModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Confirm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Complete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#CompleteModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CompleteRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Cancel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#CancelModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CancelRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Template", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
   int count = 1;

#line default
#line hidden
            BeginContext(68, 63, true);
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(131, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "658bef23e48946afad0d9f45dbe35eab", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 5 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = TempData["StatusMessage"];

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(198, 349, true);
            WriteLiteral(@"
        <span></span>
    </div>
    <table class=""table"">
        <thead>
            <tr>
                <td>STT</td>
                <td>Trạng thái yêu cầu</td>
                <td>Người cung cấp</td>
                <td>Thời gian cung cấp</td>
                <td>Thao tác</td>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 19 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
             foreach (Request item in Model)
            {

#line default
#line hidden
            BeginContext(608, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(647, 5, false);
#line 22 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
               Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(652, 29, true);
            WriteLiteral("</td>\r\n                <td>\r\n");
            EndContext();
#line 24 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                     if (item.LoanStatus == LoanStatus.Canceled)
                    {

#line default
#line hidden
            BeginContext(770, 95, true);
            WriteLiteral("                        <p>\r\n                            Đã hủy\r\n                        </p>\r\n");
            EndContext();
#line 29 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                    }
                    else if (item.LoanStatus == LoanStatus.Completed)
                    {

#line default
#line hidden
            BeginContext(982, 41, true);
            WriteLiteral("                        <p>Hoàn tất</p>\r\n");
            EndContext();
#line 33 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                    }
                    else if (item.LoanStatus == LoanStatus.Contacting)
                    {

#line default
#line hidden
            BeginContext(1141, 44, true);
            WriteLiteral("                        <p>Đang tư vấn</p>\r\n");
            EndContext();
#line 37 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                    }
                    else if (item.LoanStatus == LoanStatus.Processing)
                    {

#line default
#line hidden
            BeginContext(1303, 50, true);
            WriteLiteral("                        <p>Đang chờ xác nhận</p>\r\n");
            EndContext();
#line 41 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                    }
                    

#line default
#line hidden
            BeginContext(1418, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
#line 45 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                     if (item.OwnerId != null)
                    {
                        

#line default
#line hidden
            BeginContext(1559, 15, false);
#line 47 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                   Write(item.Owner.Name);

#line default
#line hidden
            EndContext();
#line 47 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                        
                    }

#line default
#line hidden
            BeginContext(1599, 30, true);
            WriteLiteral("                    <p hidden>");
            EndContext();
            BeginContext(1630, 7, false);
#line 49 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                         Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1637, 71, true);
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1709, 15, false);
#line 52 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
               Write(item.SubmitTime);

#line default
#line hidden
            EndContext();
            BeginContext(1724, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1791, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad11741650174a8b96a069d05674e915", async() => {
                BeginContext(1846, 8, true);
                WriteLiteral("Chi tiết");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                                     WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1858, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1861, 123, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54a4b4b0708940bfa5871c70785d893e", async() => {
                BeginContext(1972, 8, true);
                WriteLiteral("Xác nhận");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                                                                                                                                                             Write(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1984, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1987, 126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c980fb0b82ca4f8885c203a7aaaf50f7", async() => {
                BeginContext(2101, 8, true);
                WriteLiteral("Hoàn tất");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                                                                                                                                                                                                                                                                                                           Write(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2113, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(2116, 118, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22fb2767c58148138a5f0b9ae5ddf287", async() => {
                BeginContext(2224, 6, true);
                WriteLiteral("Hủy bỏ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                      Write(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2234, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 56 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                     if (item.LoanStatus == LoanStatus.Completed)
                    {

#line default
#line hidden
            BeginContext(2326, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2350, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44b7cc29b9084372b198d59e3467946b", async() => {
                BeginContext(2407, 11, true);
                WriteLiteral(" - Biểu mẫu");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 58 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                                                   WriteLiteral(item.ContractId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2422, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 59 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
                    }

#line default
#line hidden
            BeginContext(2447, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 62 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
            count++;
            }

#line default
#line hidden
            BeginContext(2526, 3467, true);
            WriteLiteral(@"        </tbody>
    </table>
</div>
                        
<!-- Modal -->
<div class=""modal fade"" id=""ConfirmModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">Xác nhận yêu cầu</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                Bạn có muốn nhận yêu cầu này?
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                <button type=""button"" class=""btn btn-light"" data-dismiss=""modal"" id=""confirm-btn"">Xác nhận</button>
         ");
            WriteLiteral(@"   </div>
        </div>
    </div>
</div>
<div class=""modal fade"" id=""CompleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">Hoàn tất yêu cầu</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                Bạn có muốn chuyển trạng thái của yêu cầu sang hoàn tất?
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                <button type=""button"" class=""btn btn-light"" id=""complete-btn"" data-dismiss=""modal"">Xác nhận</button>
            </d");
            WriteLiteral(@"iv>
        </div>
    </div>
</div>
<div class=""modal fade"" id=""CancelModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">Hủy yêu cầu</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                Bạn có muốn hủy bỏ yêu cầu này?
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                <button type=""button"" class=""btn btn-caution"" id=""cancel-btn"" data-dismiss=""modal"">Xác nhận</button>
            </div>
        </div>
    </div>
</div");
            WriteLiteral(@">
<script>
    $(document).on(""click"", ""#Confirm"", function () {
        var editId = $(this).data('id'); //get the id with this
        var success = false; //open modal only if success=true
        //url should match your server function so I will assign url as below:
        //var url = ""/ConfirmRequest?id="" + editId; //this is the server function you are calling
        var url = '");
            EndContext();
            BeginContext(5994, 36, false);
#line 132 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
              Write(Url.Action("ConfirmRequest", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(6030, 1144, true);
            WriteLiteral(@"' + ""?id="" + editId;       
        var data = JSON.stringify({ ""id"": editId });
        $(""#confirm-btn"").on(""click"", function myfunction() {
            $.ajax({ //To execute some other functionality once ajax call is done
                type: 'post',
                url: url,
                data: data, //better to pass it with data
                dataType: 'json',//type of data you are returning from server
                success: function (data) {
                    window.location.href = window.location.href;
                },
                error: function () {
                    //handle error
                    window.location.href = window.location.href;
                },
            });
        });         
    });
    $(document).on(""click"", ""#Cancel"", function () {
        var editId = $(this).data('id'); //get the id with this
        var success = false; //open modal only if success=true
        //url should match your server function so I will assign url as below:");
            WriteLiteral("\r\n        //var url = \"/ConfirmRequest?id=\" + editId; //this is the server function you are calling\r\n        var url = \'");
            EndContext();
            BeginContext(7175, 35, false);
#line 155 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
              Write(Url.Action("CancelRequest", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(7210, 1144, true);
            WriteLiteral(@"' + ""?id="" + editId;       
        var data = JSON.stringify({ ""id"": editId });
        $(""#cancel-btn"").on(""click"", function myfunction() {
            $.ajax({ //To execute some other functionality once ajax call is done
                type: 'post',
                url: url,
                data: data, //better to pass it with data
                dataType: 'json',//type of data you are returning from server
                success: function (data) {
                    window.location.href = window.location.href;
                },
                error: function () {
                    //handle erro
                    window.location.href = window.location.href;
                },
            });
        });         
    });
    $(document).on(""click"", ""#Complete"", function () {
        var editId = $(this).data('id'); //get the id with this
        var success = false; //open modal only if success=true
        //url should match your server function so I will assign url as below:");
            WriteLiteral("\r\n        //var url = \"/ConfirmRequest?id=\" + editId; //this is the server function you are calling\r\n        var url = \'");
            EndContext();
            BeginContext(8355, 37, false);
#line 178 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\RequestsControl.cshtml"
              Write(Url.Action("CompleteRequest", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(8392, 775, true);
            WriteLiteral(@"' + ""?id="" + editId;       
        var data = JSON.stringify({ ""id"": editId });
        $(""#complete-btn"").on(""click"", function myfunction() {
            $.ajax({ //To execute some other functionality once ajax call is done
                type: 'post',
                url: url,
                data: data, //better to pass it with data
                dataType: 'json',//type of data you are returning from server
                success: function (data) {
                    window.location.href = window.location.href;
                },
                error: function () {
                    window.location.href = window.location.href;
                    //handle error
                },
            });
        });         
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookingForm.Models.Request>> Html { get; private set; }
    }
}
#pragma warning restore 1591
