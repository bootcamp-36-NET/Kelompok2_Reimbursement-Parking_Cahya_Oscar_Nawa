#pragma checksum "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Chart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf25e1136368674b3691bee771a68cfc6de2da4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chart_Index), @"mvc.1.0.view", @"/Views/Chart/Index.cshtml")]
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
#nullable restore
#line 1 "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\_ViewImports.cshtml"
using ReimbursementParkingClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\_ViewImports.cshtml"
using ReimbursementParkingClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf25e1136368674b3691bee771a68cfc6de2da4f", @"/Views/Chart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"923f2d80cca8fee1e3f70763bf8f58b6e3534296", @"/Views/_ViewImports.cshtml")]
    public class Views_Chart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/ChartScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Chart\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Content Wrapper. Contains page content -->
    <div class=""content-wrapper"">
        <!-- Main content -->
        <section class=""content"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-md-6"">
                        <!-- DONUT CHART -->
                        <div class=""card card-danger"">
                            <div class=""card-header"">
                                <h3 class=""card-title"">Donut Chart</h3>

                                <div class=""card-tools"">
                                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                        <i class=""fas fa-minus""></i>
                                    </button>
                                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                                </div>
                            </div>
                ");
            WriteLiteral(@"            <div class=""card-body"">
                                <div class=""amChart"" id=""pieChart"" style=""height:230px; min-height:230px""></div>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col (LEFT) -->
                    <div class=""col-md-6"">
                        <!-- BAR CHART -->
                        <div class=""card card-success"">
                            <div class=""card-header"">
                                <h3 class=""card-title"">Bar Chart</h3>

                                <div class=""card-tools"">
                                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                        <i class=""fas fa-minus""></i>
                                    </button>
                                    <button type=""button"" class=""btn btn-tool"" data-ca");
            WriteLiteral(@"rd-widget=""remove""><i class=""fas fa-times""></i></button>
                                </div>
                            </div>
                            <div class=""card-body"">
                                <div class=""chart"">
                                    <div class=""amChart"" id=""barChart"" style=""height:230px; min-height:230px""></div>
                                </div>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->

                    </div>
                    <!-- /.col (RIGHT) -->
                    <div class=""col-md-12"">
                        <!-- BAR CHART -->
                        <div class=""card card-success"">
                            <div class=""card-header"">
                                <h3 class=""card-title"">Bar Chart</h3>

                                <div class=""card-tools"">
                                    <button type=""button"" cla");
            WriteLiteral(@"ss=""btn btn-tool"" data-card-widget=""collapse"">
                                        <i class=""fas fa-minus""></i>
                                    </button>
                                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                                </div>
                            </div>
                            <div class=""card-body"">
                                <div class=""chart"">
                                    <canvas id=""myChart"" style=""height:230px; min-height:230px""></canvas>
                                </div>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->

                    </div>
                </div>
                <!-- /.row -->
            </div><!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>

");
            DefineSection("scriptAdminLTE", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf25e1136368674b3691bee771a68cfc6de2da4f8458", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
