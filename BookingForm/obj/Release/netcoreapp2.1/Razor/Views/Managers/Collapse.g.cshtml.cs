#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "785e2063460a7618fce5e7465a1cd3c51d2dc534"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Managers_Collapse), @"mvc.1.0.view", @"/Views/Managers/Collapse.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Managers/Collapse.cshtml", typeof(AspNetCore.Views_Managers_Collapse))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"785e2063460a7618fce5e7465a1cd3c51d2dc534", @"/Views/Managers/Collapse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Managers_Collapse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookingForm.Models.Appoinment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 226, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-2\">\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Căn hộ</label>\r\n            <div class=\"input-group mb-3\">\r\n                <input style=\"text-align:right\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 278, "\"", 389, 1);
#line 7 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 286, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NCH1 + m.NCH2 + m.NCH21 + m.NCH3), 286, 103, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(390, 436, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-2"">
        <div class=""form-group"">
            <label class=""control-label"">Biệt thự</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 826, "\"", 908, 1);
#line 18 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 834, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NMS), 834, 74, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(909, 444, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-2"">
        <div class=""form-group"">
            <label class=""control-label"">Biệt thự đơn lập</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1353, "\"", 1435, 1);
#line 29 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 1361, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NSH), 1361, 74, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1436, 445, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-2"">
        <div class=""form-group"">
            <label class=""control-label"">Biệt thự song lập</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1881, "\"", 1964, 1);
#line 40 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 1889, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NSH1), 1889, 75, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1965, 437, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-2"">
        <div class=""form-group"">
            <label class=""control-label"">Shophouse</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2402, "\"", 2485, 1);
#line 51 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 2410, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NSHH), 2410, 75, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2486, 447, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-2"">
        <div class=""form-group"">
            <label class=""control-label"">Kios (Shop khối đế)</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2933, "\"", 3014, 1);
#line 62 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 2941, Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.NS), 2941, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3015, 470, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-4"">
        <div class=""form-group"">
            <label class=""control-label"">Số tiền đặt chỗ</label>
            <div class=""input-group mb-3"">
                <input style=""text-align:right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3485, "\"", 3571, 1);
#line 75 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 3493, String.Format("{0:N0}", Model.Where(m => m.Confirm == true).Sum(m => m.Cash)), 3493, 78, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3572, 444, true);
            WriteLiteral(@" class=""form-control"">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">VNĐ</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-4"">
        <div class=""form-group"">
            <label class=""control-label"">Số tiền rút cọc</label>
            <div class=""input-group mb-3"">
                <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4016, "\"", 4125, 1);
#line 86 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 4024, String.Format("{0:N0}", Model.Where(m => m.Confirm == true && m.IsActive == false).Sum(m => m.Cash)), 4024, 101, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4126, 229, true);
            WriteLiteral(" class=\"form-control\" />\r\n                <div class=\"input-group-append\">\r\n                    <span class=\"input-group-text\" id=\"basic-addon2\">VNĐ</span>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 93 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
      double _money = Model.Where(m => m.Confirm == true && m.IsActive == true).Sum(m => m.Cash); 

#line default
#line hidden
            BeginContext(4456, 211, true);
            WriteLiteral("    <div class=\"col-4\">\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Tổng tiền</label>\r\n            <div class=\"input-group mb-3\">\r\n                <input style=\"text-align: right\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4667, "\"", 4707, 1);
#line 98 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 4675, String.Format("{0:N0}", _money), 4675, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4708, 464, true);
            WriteLiteral(@" class=""form-control"" />
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">VNĐ</span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-3"">
        <div class=""form-group"">
            <label>Số lượng booking đã vào tiền</label>
            <div class=""input-group mb-3"">
                <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5172, "\"", 5263, 1);
#line 111 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 5180, String.Format("{0:N0}", Model.Count(m => m.Confirm == true && m.IsActive == true)), 5180, 83, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5264, 439, true);
            WriteLiteral(@" class=""form-control"" />
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-3"">
        <div class=""form-group"">
            <label>Số lượng booking chưa vào tiền</label>
            <div class=""input-group mb-3"">
                <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5703, "\"", 5795, 1);
#line 122 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 5711, String.Format("{0:N0}", Model.Count(m => m.Confirm == false && m.IsActive == true)), 5711, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5796, 429, true);
            WriteLiteral(@" class=""form-control"" />
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-3"">
        <div class=""form-group"">
            <label>Số lượng booking hủy</label>
            <div class=""input-group mb-3"">
                <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6225, "\"", 6296, 1);
#line 133 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 6233, String.Format("{0:N0}", Model.Count(m => m.IsActive == false)), 6233, 63, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6297, 430, true);
            WriteLiteral(@" class=""form-control"" />
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-3"">
        <div class=""form-group"">
            <label>Tổng số lượng booking</label>
            <div class=""input-group mb-3"">
                <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6727, "\"", 6749, 1);
#line 144 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 6735, Model.Count(), 6735, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6750, 410, true);
            WriteLiteral(@" class=""form-control"" />
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2"">Căn</span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-6"">
        <label>Số HĐ có nhu cầu vay</label>
        <div class=""input-group mb-3"">
            <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7160, "\"", 7220, 1);
#line 156 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 7168, Model.Count(m => m.Price > 0 && m.IsActive == true), 7168, 52, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7221, 350, true);
            WriteLiteral(@" class=""form-control"" />
            <div class=""input-group-append"">
                <span class=""input-group-text"" id=""basic-addon2"">HĐ</span>
            </div>
        </div>
    </div>
    <div class=""col-6"">
        <label>Tổng số tiền cần vay</label>
        <div class=""input-group mb-3"">
            <input style=""text-align: right""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7571, "\"", 7674, 1);
#line 165 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Collapse.cshtml"
WriteAttributeValue("", 7579, String.Format("{0:N0}", Model.Where(m => m.Price > 0 && m.IsActive == true).Sum(m => m.Price)), 7579, 95, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7675, 203, true);
            WriteLiteral(" class=\"form-control\" />\r\n            <div class=\"input-group-append\">\r\n                <span class=\"input-group-text\" id=\"basic-addon2\">VNĐ</span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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