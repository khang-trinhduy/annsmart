#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Profit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8184ee887ebc75e6c922ddec77680bc39dd2e6f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Managers_Profit), @"mvc.1.0.view", @"/Views/Managers/Profit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Managers/Profit.cshtml", typeof(AspNetCore.Views_Managers_Profit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8184ee887ebc75e6c922ddec77680bc39dd2e6f3", @"/Views/Managers/Profit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Managers_Profit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<double>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(143, 505, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""row my-3"">
        <div class=""col"">
            Monthly revenue
        </div>
    </div>
    <div class=""row my-2"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <canvas id=""chLine"" height=""100""></canvas>
                </div>
            </div>
        </div>
    </div>
</div>

<style>
    #id {
        color: #cefbfa
    }
</style>

<script>
    var data = ");
            EndContext();
            BeginContext(649, 31, false);
#line 29 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Profit.cshtml"
          Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(680, 1866, true);
            WriteLiteral(@";

    var colors = ['#007bff', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];

    /* large line chart */
    var chLine = document.getElementById(""chLine"");

    var month = new Array();
    month[0] = ""January"";
    month[1] = ""February"";
    month[2] = ""March"";
    month[3] = ""April"";
    month[4] = ""May"";
    month[5] = ""June"";
    month[6] = ""July"";
    month[7] = ""August"";
    month[8] = ""September"";
    month[9] = ""October"";
    month[10] = ""November"";
    month[11] = ""December"";

    var chartData = {
        labels: [month[8], month[9], month[10], month[11], month[0]],
        datasets: [{
            label: ['Active'],
            data: [data[1], data[2], data[3], data[4], data[0]],
            backgroundColor: 'transparent',
            borderColor: '#26da69',
            borderWidth: 4,
            pointBackgroundColor: '#26da69'
        },
        {
            label: ['Canceled'],
            data: [data[6], data[7], data[8], data[9], data[5]],
       ");
            WriteLiteral(@"     backgroundColor: ""#f5bfae"",
            borderColor: ""#ff0000"",
            borderWidth: 4,
            pointBackgroundColor: ""#ff0000""
        }]
    };

    if (chLine) {
        new Chart(chLine, {
            type: 'line',
            data: chartData,
            options: {
                scales: {
                    yAxes: [{
                        scaleLabel: {
                            display: true,
                            labelString: 'Revenue (vnđ)'
                        },
                        ticks: {
                            beginAtZero: false
                        }
                    }]
                },
                legend: {
                    display: true,
                    position: 'bottom'
                }
            }
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<double>> Html { get; private set; }
    }
}
#pragma warning restore 1591