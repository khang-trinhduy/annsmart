#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3728737180949dd88adb1e35d76df19f51b96671"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_List), @"mvc.1.0.view", @"/Views/Admin/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/List.cshtml", typeof(AspNetCore.Views_Admin_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3728737180949dd88adb1e35d76df19f51b96671", @"/Views/Admin/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookingForm.Models.Appoinment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AppDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Confirm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Draft", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 561, true);
            WriteLiteral(@"<table style=""border:solid #ddd 1px;white-space:nowrap; overflow:hidden"" class=""table"">
    <colgroup>
        <col span=""11"">
    </colgroup>
    <thead>
        <tr style=""background-color:#3fa5ea; color:#ffffff"">
            <th rowspan=""2"" style=""vertical-align:middle; text-align:center""> STT </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Họ tên KH
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                TT Sale
            </th>
");
            EndContext();
            BeginContext(684, 1675, true);
            WriteLiteral(@"            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Số HĐ
            </th>
            <th colspan=""5"">
                STT từng loại
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Tiền đặt chỗ
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                TG đặt chỗ
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                HTTT
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Đã nộp
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Thời gian nộp
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Vay
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: ce");
            WriteLiteral(@"nter"">
                Yêu cầu khác
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                Xác nhận
            </th>
            <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">Thao tác</th>
        </tr>
        <tr style=""background-color:#1f96e7; color:#ffffff"">
            <th>CH</th>
            <th>
                BT
            </th>
            <th>
                NP
            </th>
            <th>
                NPTM
            </th>
            <th>
                Kios
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 67 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
           int count = 1;
            double money = 0;

#line default
#line hidden
            BeginContext(2418, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 69 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
         foreach (var item in Model)
        {
            var statusClass = "Yellow";
            if (item.IsActive == false)
            {
                statusClass = "White";
            }
            else if (item.Confirm == true)
            {
                statusClass = "Green";
            }
           

#line default
#line hidden
            BeginContext(2746, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2761, "\"", 2781, 1);
#line 81 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
WriteAttributeValue("", 2769, statusClass, 2769, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2782, 50, true);
            WriteLiteral(">\r\n                <td style=\"white-space:nowrap\">");
            EndContext();
            BeginContext(2833, 5, false);
#line 82 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                          Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(2838, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 83 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                   count++;
                    money += item.Cash;

#line default
#line hidden
            BeginContext(2916, 87, true);
            WriteLiteral("                <td style=\"white-space: nowrap; text-align:left\">\r\n                    ");
            EndContext();
            BeginContext(3004, 43, false);
#line 86 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Customer));

#line default
#line hidden
            EndContext();
            BeginContext(3047, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3115, 39, false);
#line 89 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.sale));

#line default
#line hidden
            EndContext();
            BeginContext(3154, 24, true);
            WriteLiteral(" -\r\n                    ");
            EndContext();
            BeginContext(3179, 46, false);
#line 90 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.SaleDetails));

#line default
#line hidden
            EndContext();
            BeginContext(3225, 69, true);
            WriteLiteral("\r\n\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3295, 43, false);
#line 94 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Contract));

#line default
#line hidden
            EndContext();
            BeginContext(3338, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 99 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                  
                    string fs = "";
                    if (item.NCH1 > 0 || item.NCH2 > 0 || item.NCH3 > 0 || item.NCH21 > 0)
                    {
                        //fs += "<li>Căn hộ: " + Model.appoinment.ph + "</li>";
                        int n = item.NCH1 + item.NCH2 + item.NCH3 + item.NCH21;
                        switch (n)
                        {
                            case 1:
                                fs += "<td>" + item.ph + "</td>";
                                break;
                            case 2:
                                fs += "<td>" + Convert.ToString(item.ph - 1) + " & " + item.ph + "</td>";
                                break;
                            default:
                                fs += "<td>" + Convert.ToString(item.ph - n + 1) + " đến " + item.ph + "</td>";
                                break;

                        }
                    }
                    else
                    {
                        fs += "<td></td>";
                    }
                    if (item.NMS > 0)
                    {
                        //fs += "<li>Biệt thự: " + Model.appoinment.pms + "</li>";
                        switch (item.NMS)
                        {
                            case 1:
                                fs += "<td>" + item.pms + "</td>";
                                break;
                            case 2:
                                fs += "<td>" + Convert.ToString(item.pms - 1) + " & " + item.pms + "</td>";
                                break;
                            default:
                                fs += "<td>" + Convert.ToString(item.pms - item.pms + 1) + " đến " + item.pms + "</td>";
                                break;

                        }
                    }
                    else
                    {
                        fs += "<td></td>";
                    }
                    if (item.NSH > 0)
                    {
                        //fs += "<li>Nhà phố: " + Model.appoinment.psh + "</li>";
                        switch (item.NSH)
                        {
                            case 1:
                                fs += "<td>" + item.psh + "</p>";
                                break;
                            case 2:
                                fs += "<td>" + Convert.ToString(item.psh - 1) + " & " + item.psh + "</p>";
                                break;
                            default:
                                fs += "<td>" + Convert.ToString(item.psh - item.NSH + 1) + " đến " + item.psh + "</td>";
                                break;

                        }
                    }
                    else
                    {
                        fs += "<td></td>";
                    }
                    if (item.NSHH > 0)
                    {
                        //fs += "<li>Shophouse: " + Model.appoinment.pshh + "</li>";
                        switch (item.NSHH)
                        {
                            case 1:
                                fs += "<td>" + item.pshh + "</td>";
                                break;
                            case 2:
                                fs += "<td>" + Convert.ToString(item.pshh - 1) + " & " + item.pshh + "</td>";
                                break;
                            default:
                                fs += "<td>" + Convert.ToString(item.pshh - item.NSHH + 1) + " đến " + item.pshh + "</td>";
                                break;

                        }
                    }
                    else
                    {
                        fs += "<td></td>";
                    }
                    if (item.NS > 0)
                    {
                        //fs += "<li>Shophouse: " + Model.appoinment.pshh + "</li>";
                        switch (item.NS)
                        {
                            case 1:
                                fs += "<td>" + item.pns + "</td>";
                                break;
                            case 2:
                                fs += "<td>" + Convert.ToString(item.pns - 1) + " & " + item.pns + "</td>";
                                break;
                            default:
                                fs += "<td>" + Convert.ToString(item.pns - item.NS + 1) + " đến " + item.pns + "</td>";
                                break;

                        }
                    }
                    else
                    {
                        fs += "<td></td>";
                    }
                

#line default
#line hidden
            BeginContext(8251, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(8268, 12, false);
#line 208 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
           Write(Html.Raw(fs));

#line default
#line hidden
            EndContext();
            BeginContext(8280, 24, true);
            WriteLiteral("\r\n                <td>\r\n");
            EndContext();
            BeginContext(8371, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(8392, 35, false);
#line 211 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(String.Format("{0:N0}", item.Money));

#line default
#line hidden
            EndContext();
            BeginContext(8427, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 213 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                  
                    string day, month, year, hour, minute, second, millisecond = "";
                    try
                    {
                        DateTime d = DateTime.ParseExact(item.cTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                         System.Globalization.CultureInfo.InvariantCulture);
                        day = Convert.ToString(d.Day);
                        month = Convert.ToString(d.Month);
                        year = Convert.ToString(d.Year);
                        hour = Convert.ToString(d.Hour);
                        minute = Convert.ToString(d.Minute);
                        second = Convert.ToString(d.Second);
                        millisecond = Convert.ToString(d.Millisecond);
                    }
                    catch (Exception)
                    {

                        day = "--";
                        month = "--";
                        year = "----";
                        hour = "--";
                        minute = "--";
                        second = "--";
                        millisecond = "-------";

                    }

#line default
#line hidden
            BeginContext(9623, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(9674, 3, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                   Write(day);

#line default
#line hidden
            EndContext();
            BeginContext(9677, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(9679, 5, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                        Write(month);

#line default
#line hidden
            EndContext();
            BeginContext(9684, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(9686, 4, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                               Write(year);

#line default
#line hidden
            EndContext();
            BeginContext(9690, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(9692, 4, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                     Write(hour);

#line default
#line hidden
            EndContext();
            BeginContext(9696, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(9698, 6, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                           Write(minute);

#line default
#line hidden
            EndContext();
            BeginContext(9704, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(9706, 6, false);
#line 240 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                                   Write(second);

#line default
#line hidden
            EndContext();
            BeginContext(9712, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
            BeginContext(9760, 42, true);
            WriteLiteral("                <td>\r\n                    ");
            EndContext();
            BeginContext(9803, 40, false);
#line 244 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.DType));

#line default
#line hidden
            EndContext();
            BeginContext(9843, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(9913, 34, false);
#line 248 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(String.Format("{0:N0}", item.Cash));

#line default
#line hidden
            EndContext();
            BeginContext(9947, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 250 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                  
                    //string day, month, year, hour, minute, second, millisecond = "";
                    try
                    {
                        DateTime d = DateTime.ParseExact(item.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                         System.Globalization.CultureInfo.InvariantCulture);
                        day = Convert.ToString(d.Day);
                        month = Convert.ToString(d.Month);
                        year = Convert.ToString(d.Year);
                        hour = Convert.ToString(d.Hour);
                        minute = Convert.ToString(d.Minute);
                        second = Convert.ToString(d.Second);
                        millisecond = Convert.ToString(d.Millisecond);
                    }
                    catch (Exception)
                    {

                        day = "--";
                        month = "--";
                        year = "----";
                        hour = "--";
                        minute = "--";
                        second = "--";
                        millisecond = "-------";

                    }

#line default
#line hidden
            BeginContext(11145, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(11196, 3, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                   Write(day);

#line default
#line hidden
            EndContext();
            BeginContext(11199, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(11201, 5, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                        Write(month);

#line default
#line hidden
            EndContext();
            BeginContext(11206, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(11208, 4, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                               Write(year);

#line default
#line hidden
            EndContext();
            BeginContext(11212, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(11214, 4, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                     Write(hour);

#line default
#line hidden
            EndContext();
            BeginContext(11218, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(11220, 6, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                           Write(minute);

#line default
#line hidden
            EndContext();
            BeginContext(11226, 1, true);
            WriteLiteral(":");
            EndContext();
            BeginContext(11228, 6, false);
#line 277 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                                   Write(second);

#line default
#line hidden
            EndContext();
            BeginContext(11234, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
            BeginContext(11282, 22, true);
            WriteLiteral("                <td>\r\n");
            EndContext();
#line 281 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                      
                        string tmp = "";
                        if (item.Price > 0)
                        {
                            tmp = "<input type =\"checkbox\" name=\"ph\" value=\"Boat\" checked disabled> " + @String.Format("{0:N0}", item.Price);
                        }
                        else
                        {
                            tmp = "<input type =\"checkbox\" name=\"ph\" value=\"Boat\" disabled>";
                        }
                    

#line default
#line hidden
            BeginContext(11826, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(11847, 13, false);
#line 292 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.Raw(tmp));

#line default
#line hidden
            EndContext();
            BeginContext(11860, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(11928, 43, false);
#line 295 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Requires));

#line default
#line hidden
            EndContext();
            BeginContext(11971, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(12039, 42, false);
#line 298 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Confirm));

#line default
#line hidden
            EndContext();
            BeginContext(12081, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(12148, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6615f383a7104d239a43c7ac3761b78a", async() => {
                BeginContext(12199, 3, true);
                WriteLiteral("XHĐ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 301 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                                 WriteLiteral(item.ID);

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
            BeginContext(12206, 23, true);
            WriteLiteral("|\r\n                    ");
            EndContext();
            BeginContext(12229, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9eff7ea8cb3b4e86b18e4afe5fe297f6", async() => {
                BeginContext(12277, 2, true);
                WriteLiteral("XN");
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
#line 302 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                              WriteLiteral(item.ID);

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
            BeginContext(12283, 23, true);
            WriteLiteral("|\r\n                    ");
            EndContext();
            BeginContext(12306, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "590e27a3b3ff4b45989fe1200c828b45", async() => {
                BeginContext(12352, 5, true);
                WriteLiteral("Draft");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 303 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                            WriteLiteral(item.ID);

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
            BeginContext(12361, 23, true);
            WriteLiteral("|\r\n                    ");
            EndContext();
            BeginContext(12384, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db1f55050d2847c2a4af84b448a69008", async() => {
                BeginContext(12429, 3, true);
                WriteLiteral("Sửa");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 304 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                           WriteLiteral(item.ID);

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
            BeginContext(12436, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12620, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 309 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
        }

#line default
#line hidden
            BeginContext(12673, 26, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
#line 313 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
   
    //string new_money = Convert.ToString(money);
    string new_money = String.Format("{0:N0}", money);
    //for (int i = 3; i < new_money.Length; i += 3)
    //{
    //    new_money = new_money.Insert(i, ",");
    //    i++;
    //}

#line default
#line hidden
            BeginContext(12950, 124, true);
            WriteLiteral("<label style=\"display:block; text-align:right;font-family:\'Times New Roman\'; font-style:italic; font-size:large\">Tổng tiền: ");
            EndContext();
            BeginContext(13075, 9, false);
#line 322 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Admin\List.cshtml"
                                                                                                                       Write(new_money);

#line default
#line hidden
            EndContext();
            BeginContext(13084, 898, true);
            WriteLiteral(@" VNĐ</label>

<style>
    /*tr:hover {
        background-color: #ddd;
    }*/
    .Red {
        color: #ffffff;
        background-color: #f74743
    }

    .Green {
        color: #ffffff;
        background-color: #2ed75d
    }

    .Yellow {
        background-color: #f6f11d
    }

    th, td {
        border-left: 1px solid #ddd;
    }

    table, td, th {
        border: 1px solid #ddd;
        text-align: left;
    }

    table {
        border-collapse: collapse;
        width: 100%;
    }

    th, td {
        padding: 15px;
    }

    th, td {
        text-align: center;
        vertical-align: middle;
    }
    tr:hover {
        background-color: #ffffff;
        color: #1f96e7;
        cursor:pointer;
    }
</style>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js""></script>
<script></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookingForm.Models.Appoinment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
