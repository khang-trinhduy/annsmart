#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90240d12af9502ae10ea862694a896bc9516f021"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90240d12af9502ae10ea862694a896bc9516f021", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddDOB", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Views", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Passport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(241, 6, true);
            WriteLiteral("    \r\n");
            EndContext();
            BeginContext(413, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
  
    var curUser = await UserManager.GetUserAsync(User);
    TempData["sale"] = curUser.Email;
    if (curUser.Info != null)
    {
        

#line default
#line hidden
#line 17 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
               
    }



#line default
#line hidden
            BeginContext(827, 129, true);
            WriteLiteral("<span style=\"display:inline-block; height: 15px;\"></span>\r\n<h6 style=\"font-style:italic; text-align:right\">TP. Hồ Chí Minh, ngày ");
            EndContext();
            BeginContext(957, 16, false);
#line 23 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                                                 Write(DateTime.Now.Day);

#line default
#line hidden
            EndContext();
            BeginContext(973, 8, true);
            WriteLiteral("  tháng ");
            EndContext();
            BeginContext(982, 18, false);
#line 23 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                                                                          Write(DateTime.Now.Month);

#line default
#line hidden
            EndContext();
            BeginContext(1000, 5, true);
            WriteLiteral(" năm ");
            EndContext();
            BeginContext(1006, 17, false);
#line 23 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                                                                                                  Write(DateTime.Now.Year);

#line default
#line hidden
            EndContext();
            BeginContext(1023, 7, true);
            WriteLiteral("</h6>\r\n");
            EndContext();
            BeginContext(2005, 2224, true);
            WriteLiteral(@"
<p style=""font-style: italic; color: #ee1818"">Lưu ý: Những hợp đồng có tình trạng ""số chưa chính thức"" vui lòng liên hệ admin để xác nhận tiền vào (nếu đã nộp tiền) trước 19h00' cùng ngày. Quá thời gian trên, hệ thống sẽ tự động loại bỏ những hợp đồng chưa chính thức.</p>
<hr />
<span style=""display:inline-block; height: 15px;""></span>
<h4 style=""text-align:center;font-family:Calibri"">Hợp đồng xếp chỗ</h4>
<div class=""container"">
    <table style=""text-align:center"" class=""table"">
        <thead>
            <tr>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    STT
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Tên khách
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Ngày sinh
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
   ");
            WriteLiteral(@"                 Số HĐ
                </th>
                <th colspan=""6"">
                    Số TT
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Số tiền
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Ngày thanh toán
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Tình trạng
                </th>
                <th rowspan=""2"" style=""vertical-align:middle; text-align: center"">
                    Thao tác
                </th>
            </tr>
            <tr>
                <th>
                    CH
                </th>
                <th>
                    DT
                </th>
                <th>
                    BTĐL
                </th>
                <th>
                    BTSL
                </th>
                <th>");
            WriteLiteral("\r\n                    NPTM\r\n                </th>\r\n                <th>\r\n                    Kios\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 110 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
              
                int count = 1;
                if (curUser.Meetings != null)
                {
                    foreach (var item in curUser.Meetings)
                    {

#line default
#line hidden
            BeginContext(4426, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4523, 5, false);
#line 118 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                           Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(4528, 138, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td style=\"text-align:left !important\">\r\n                                ");
            EndContext();
            BeginContext(4667, 13, false);
#line 121 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                           Write(item.Customer);

#line default
#line hidden
            EndContext();
            BeginContext(4680, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 123 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                             if (item.DOB.Year == 1)
	                        {

#line default
#line hidden
            BeginContext(4799, 37, true);
            WriteLiteral("                            <td>Thiếu");
            EndContext();
            BeginContext(4836, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "489c4c22952a40a6ad8bdf56e135bf8c", async() => {
                BeginContext(4883, 22, true);
                WriteLiteral("(click vào để bổ sung)");
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
#line 125 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
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
            BeginContext(4909, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 126 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(5012, 40, true);
            WriteLiteral("                                    <td>");
            EndContext();
            BeginContext(5053, 36, false);
#line 129 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                   Write(item.DOB.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(5089, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 130 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                            }

#line default
#line hidden
            BeginContext(5127, 66, true);
            WriteLiteral("                            <td>\r\n                                ");
            EndContext();
            BeginContext(5194, 13, false);
#line 132 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                           Write(item.Contract);

#line default
#line hidden
            EndContext();
            BeginContext(5207, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 134 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                              
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
                                            fs += "<td>" + Convert.ToString(item.ph - n + 1) + " - " + item.ph + "</td>";
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
                                            fs += "<td>" + Convert.ToString(item.pms - item.pms + 1) + " - " + item.pms + "</td>";
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
                                            fs += "<td>" + Convert.ToString(item.psh - item.NSH + 1) + " - " + item.psh + "</td>";
                                            break;

                                    }
                                }
                                else
                                {
                                    fs += "<td></td>";
                                }
                                if (item.NSH1 > 0)
                                {
                                    //fs += "<li>Nhà phố: " + Model.appoinment.psh + "</li>";
                                    switch (item.NSH1)
                                    {
                                        case 1:
                                            fs += "<td>" + item.psh1 + "</p>";
                                            break;
                                        case 2:
                                            fs += "<td>" + Convert.ToString(item.psh1 - 1) + " & " + item.psh1 + "</p>";
                                            break;
                                        default:
                                            fs += "<td>" + Convert.ToString(item.psh1 - item.NSH1 + 1) + " - " + item.psh1 + "</td>";
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
                                            fs += "<td>" + Convert.ToString(item.pshh - item.NSHH + 1) + " - " + item.pshh + "</td>";
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
                                            fs += "<td>" + Convert.ToString(item.pns - item.NS + 1) + " - " + item.pns + "</td>";
                                            break;

                                    }
                                }
                                else
                                {
                                    fs += "<td></td>";
                                }
                            

#line default
#line hidden
            BeginContext(12409, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(12438, 12, false);
#line 264 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                       Write(Html.Raw(fs));

#line default
#line hidden
            EndContext();
            BeginContext(12450, 68, true);
            WriteLiteral("\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(12519, 35, false);
#line 266 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                           Write(String.Format("{0:N0}", item.Money));

#line default
#line hidden
            EndContext();
            BeginContext(12554, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 268 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                              
                                string date = "";
                                try
                                {
                                    DateTime d = DateTime.ParseExact(item.dTime, "ddMMyyyy HH:mm:ss.FFFFFFF",
                                             System.Globalization.CultureInfo.InvariantCulture);
                                    date += "<td>" +
                                @d.Day + "/" + @d.Month + "/" + @d.Year +
                        "</td>";
                                }
                                catch (Exception)
                                {
                                    date += "<td></td>";

                                }

                            

#line default
#line hidden
            BeginContext(13367, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(13396, 14, false);
#line 285 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                       Write(Html.Raw(date));

#line default
#line hidden
            EndContext();
            BeginContext(13410, 36, true);
            WriteLiteral("\r\n                            <td>\r\n");
            EndContext();
#line 287 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                  
                                    string confirm = "";
                                    

#line default
#line hidden
#line 289 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                     if (item.Confirm != true)
                                    {
                                        confirm = "Số chưa chính thức";
                                    }
                                    else
                                    {
                                        confirm = "Số chính thức";
                                    }

#line default
#line hidden
            BeginContext(13978, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(14011, 17, false);
#line 298 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                           Write(Html.Raw(confirm));

#line default
#line hidden
            EndContext();
            BeginContext(14028, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(14131, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51d09cc3a68746de8101e8c79d121a1c", async() => {
                BeginContext(14177, 2, true);
                WriteLiteral("HĐ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 301 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                     WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(14183, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(14186, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "336bfa6e6f5448c1915917b95da6b653", async() => {
                BeginContext(14235, 13, true);
                WriteLiteral("Cập nhật CMND");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 301 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                                                                                            WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(14252, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 304 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Home\Dashboard.cshtml"
                        count += 1;
                    }
                }
            

#line default
#line hidden
            BeginContext(14414, 1794, true);
            WriteLiteral(@"
        </tbody>
    </table>
</div>
<style>
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

    table {
        color: #333;
        font-family: Helvetica, Arial, sans-serif;
        width: 640px;
        border-collapse: collapse;
        border-spacing: 0;
    }

    td, th {
        border: 1px solid transparent; /* No more visible border */
        height: 30px;
        transition: all 0.3s; /* Simple transition for hover effect */
    }

    th {
        border: 1px solid #1fce98;
        background: #1fce98;
        font-weight: bold;
        color: white;
    }

    td {
        background: #FAFAFA;
        text-align: center;
    }

    /* Cells in even rows (2,4,6...) are one color */
    tr:nth-child(even) td {
   ");
            WriteLiteral(@"     background: #F1F1F1;
    }

    /* Cells in odd rows (1,3,5...) are another (excludes header cells)  */
    tr:nth-child(odd) td {
        background: #FEFEFE;
    }

    /*tr td:hover {
        background: #666;
        color: #FFF;
    }*/

    /*table {
        overflow: hidden;
        display: inline-block;
    }*/

    /*tr:hover {
        background-color: #faf2de;
    }*/


    td, th {
        position: relative;
    }

        /*td:hover::after,
        th:hover::after {
            content: """";
            position: absolute;
            background-color: #1fce98;
            left: 0;
            top: -5000px;
            height: 1000px;
            width: 100%;
            z-index: -1;
        }*/
</style>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Sale> UserManager { get; private set; }
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
