#pragma checksum "D:\FileKerja\MII\ProjectNetCore\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Main\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c40602c05eb37dbe311b59ac52c99ffcceacf82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Login), @"mvc.1.0.view", @"/Views/Main/Login.cshtml")]
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
#line 1 "D:\FileKerja\MII\ProjectNetCore\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\_ViewImports.cshtml"
using ReimbursementParkingClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FileKerja\MII\ProjectNetCore\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\_ViewImports.cshtml"
using ReimbursementParkingClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c40602c05eb37dbe311b59ac52c99ffcceacf82", @"/Views/Main/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"923f2d80cca8fee1e3f70763bf8f58b6e3534296", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Login.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\FileKerja\MII\ProjectNetCore\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Main\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Layout/_Login.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-login100"">
    <div class=""wrap-login100"">
        <div class=""login100-form validate-form"">
            <span class=""login100-form-title p-b-43"">
                Login to continue
            </span>


            <div class=""wrap-input100 validate-input"" data-validate=""Valid email is required: ex@abc.xyz"">
                <input class=""input100"" type=""text"" id=""email"" name=""email"">
                <span class=""focus-input100""></span>
                <span class=""label-input100"">Email</span>
            </div>


            <div class=""wrap-input100 validate-input"" data-validate=""Password is required"">
                <input class=""input100"" type=""password"" id=""password"" name=""pass"">
                <span class=""focus-input100""></span>
                <span class=""label-input100"">Password</span>
            </div>

            <div class=""flex-sb-m w-full p-t-3 p-b-32"">
                <div class=""contact100-form-checkbox"">
                    <input class=""inpu");
            WriteLiteral(@"t-checkbox100"" id=""ckb1"" type=""checkbox"" name=""showPassword"" onclick=""myFunction()"">
                    <label class=""label-checkbox100"" for=""ckb1"">
                        Show Password
                    </label>
                </div>

                <div>
                    <a href=""#"" class=""txt1"">
                        Forgot Password?
                    </a>
                </div>
            </div>


            <div class=""container-login100-form-btn"">
                <button type=""button"" class=""login100-form-btn"" onclick=""return myLogin()"">
                    Login
                </button>
            </div>

            <div class=""text-center p-t-46 p-b-20"">
                <span class=""txt2"">
                    or sign up using
                </span>
            </div>

            <div class=""login100-form-social flex-c-m"">
                <a href=""#"" class=""login100-form-social-item flex-c-m bg1 m-r-5"">
                    <i class=""fa fa-facebook-f"" aria");
            WriteLiteral(@"-hidden=""true""></i>
                </a>

                <a href=""#"" class=""login100-form-social-item flex-c-m bg2 m-r-5"">
                    <i class=""fa fa-twitter"" aria-hidden=""true""></i>
                </a>
            </div>
        </div>

        <div class=""login100-more"" style=""background-image: url(images/background.png)"">
        </div>
    </div>
</div>

");
            DefineSection("scriptLogin", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c40602c05eb37dbe311b59ac52c99ffcceacf826740", async() => {
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
                WriteLiteral(@"
    <script>
        function myFunction() {
            var x = document.getElementById(""password"");
            if (x.type === ""password"") {
                x.type = ""text"";
            } else {
                x.type = ""password"";
            }
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
