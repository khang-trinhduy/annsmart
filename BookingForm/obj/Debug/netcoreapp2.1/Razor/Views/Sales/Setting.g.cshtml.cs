#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cd885d8451b5f3a62f932e44b2c2cfddd0ff7ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sales_Setting), @"mvc.1.0.view", @"/Views/Sales/Setting.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sales/Setting.cshtml", typeof(AspNetCore.Views_Sales_Setting))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cd885d8451b5f3a62f932e44b2c2cfddd0ff7ef", @"/Views/Sales/Setting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Sales_Setting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookingForm.Models.Sale>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
            BeginContext(77, 499, true);
            WriteLiteral(@"<div id=""container""> 
   
</div>
<span style=""display:block; height:50px""></span>
<hr />
<div class=""tab"">
    <button class=""tablinks"" id=""setting"">Cài đặt</button>
    <button class=""tablinks"" onclick=""openCity(event, 'Profile')"" id=""defaultOpen"">Hồ sơ cá nhân</button>
    <button class=""tablinks"" onclick=""openCity(event, 'Account')"">Tài khoản</button>
    <button class=""tablinks"" onclick=""openCity(event, 'Email')"">Email</button>
</div>

<div id=""Profile"" class=""tabcontent"">
    ");
            EndContext();
            BeginContext(577, 41, false);
#line 19 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml"
Write(await Html.PartialAsync("Profile", Model));

#line default
#line hidden
            EndContext();
            BeginContext(618, 55, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div id=\"Account\" class=\"tabcontent\">\r\n    ");
            EndContext();
            BeginContext(674, 41, false);
#line 23 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml"
Write(await Html.PartialAsync("Account", Model));

#line default
#line hidden
            EndContext();
            BeginContext(715, 53, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div id=\"Email\" class=\"tabcontent\">\r\n    ");
            EndContext();
            BeginContext(769, 39, false);
#line 27 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml"
Write(await Html.PartialAsync("Email", Model));

#line default
#line hidden
            EndContext();
            BeginContext(808, 3958, true);
            WriteLiteral(@"
</div>

<style>
    * {
        box-sizing: border-box
    }

    body {
        font-family: ""Lato"", sans-serif;
    }

    /* Style the tab */
    .tab {
        float: left;
        border: none;
        background-color: none;
        width: 30%;
        height: 300px;
    }

        /* Style the buttons inside the tab */
        .tab button {
            text-align: left;
            display: block;
            /*background-color: inherit;
            color: black;
            padding: 22px 16px;*/
            width: 70%;
            /*border: none;
            outline: none;*/
            cursor: pointer;
            /*transition: 0.3s;*/
            font-size: 17px;
        }

            /* Change background color of buttons on hover */
            .tab button:hover {
                background-color: #fff;
            }

            /* Create an active/current ""tab button"" class */
            .tab button.active {
                background-color: #f8d61a;");
            WriteLiteral(@"
            }

    /* Style the tab content */
    .tabcontent {
        text-align: left;
        float: right;
        padding: 0px 10px 0px 10px;
        border: none;
        width: 70%;
        border-left: none;
        height: 300px;
    }

    #setting {
        background-color: aliceblue;
        color: #1d63d7;
    }

        #setting:hover {
            background-color: aliceblue !important;
            color: #1d63d7 !important;
            transition: none none none !important;
        }

    #success {
        position: absolute;
        width: 200px;
        height: 50px;
        z-index: 15;
        left: 50%;
        margin-left: -100px;
    }
</style>

<script type=""text/javascript"" language=""JavaScript"">
    function setInputFilter(obj, inputFilter) {
        obj.on(""input keydown keyup mousedown mouseup select contextmenu drop"", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this");
            WriteLiteral(@".oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty(""oldValue"")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);

            }
        });
    }
    function setPatternFilter(obj, pattern) {
        setInputFilter(obj, function (value) { return pattern.test(value); });
    }

    setPatternFilter($(""#date""), /^-?[\d-]*$/);
    $(document).ready(function () {
        $(""#date"").attr(""placeholder"", ""25-12-1990"");
    })

    $(document).on(""keyup"", ""#date"", function (e) {
        var date = $(this).val();
        if (date.length == 2) {
            $(""#date"").val(date + ""-"");
        }
        else if (date.length == 5) {
            $(""#date"").val(date + ""-"");
        }
        else if (date.length == 10) {
            $(""#date"").focusout().blur();
        }
    });
    $(document).on(""keyup"", ""#phone"", func");
            WriteLiteral(@"tion (e) {
        var phone = $(this).val();
        if (phone.length == 9) {
            $(this).val(phone + "" "");
        }
        if (phone.length == 13) {
            $(this).val(phone + "" "");
        }
        if (phone.length == 18) {
            $(""#phone"").focusout().blur();
        }
    })

    $(function () {
        $(document).on(""click"", ""#save"", function (e) {
            $(""#container"").append('<div class=""alert alert-success"" style=""display:block;width:200px; "" id=""success"">< strong > Lưu thành công!</strong ></div>');
            $('#success').delay(10000).fadeIn(300).delay(10000).fadeOut(300);
        }, 'json');
        return false;
    });

    $(document).on(""submit"", ""#pw"", function (e) {
        alert(""ok"");
        var curr = $(""#cp"").val();
        var np = $(""#np"").val();
        var rcp = $(""#rcp"").val();
        if (");
            EndContext();
            BeginContext(4767, 10, false);
#line 166 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Sales\Setting.cshtml"
       Write(Model.pass);

#line default
#line hidden
            EndContext();
            BeginContext(4777, 1243, true);
            WriteLiteral(@" != curr) {
            $(""#warning"").val() = ""Mật khẩu hiện tại không đúng"";
            $(""#cp"").val() = """";
            event.preventDefault();
        }
        else if (np != rcp) {
            $(""#warning"").val() = ""Mật khẩu xác nhận không đúng"";
            $(""#rcp"").val() = """";
            event.preventDefault();
        }
        else {
            $(""#warning"").val() = ""Thay đổi thành công"";
        }
    });   

    $(document).ready(function () {
        $(""#phone"").val(""(+84) "");
    })
    function openCity(evt, cityName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName(""tabcontent"");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = ""none"";
        }
        tablinks = document.getElementsByClassName(""tablinks"");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace("" active"", """");
        }
        document.getElementById(c");
            WriteLiteral("ityName).style.display = \"block\";\r\n        evt.currentTarget.className += \" active\";\r\n    }\r\n\r\n    // Get the element with id=\"defaultOpen\" and click on it\r\n    document.getElementById(\"defaultOpen\").click();\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookingForm.Models.Sale> Html { get; private set; }
    }
}
#pragma warning restore 1591
