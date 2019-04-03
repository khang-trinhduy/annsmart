#pragma checksum "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Monthly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d798d4696d2d885d2d96dda0a6a28b175a684f08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Managers_Monthly), @"mvc.1.0.view", @"/Views/Managers/Monthly.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Managers/Monthly.cshtml", typeof(AspNetCore.Views_Managers_Monthly))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d798d4696d2d885d2d96dda0a6a28b175a684f08", @"/Views/Managers/Monthly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a961fb0ce4f853b3e2c4fa2992c1d9302b2824bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Managers_Monthly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(140, 543, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""row my-3"">
        <div class=""col"">
            Comparison of active contracts and canceled contracts
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
            BeginContext(684, 31, false);
#line 29 "C:\Users\trinh\source\repos\annhome-booking-master\BookingForm\Views\Managers\Monthly.cshtml"
          Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(715, 1925, true);
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
        labels: [month[data[11] - 1], month[data[12] - 1], month[data[13] - 1], month[data[14] - 1], month[data[10] - 1]],
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
            data: [d");
            WriteLiteral(@"ata[6], data[7], data[8], data[9], data[5]],
            backgroundColor: ""#f5bfae"",
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
                            labelString: 'Number of contracts'
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
