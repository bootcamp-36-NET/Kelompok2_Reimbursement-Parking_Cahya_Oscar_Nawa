#pragma checksum "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Main\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a77075d4e2d3aa66a1858344145a64539ad56f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Index), @"mvc.1.0.view", @"/Views/Main/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a77075d4e2d3aa66a1858344145a64539ad56f2", @"/Views/Main/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"923f2d80cca8fee1e3f70763bf8f58b6e3534296", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\1 File Kanawa\Bootcamp MII\GitHub\Kelompok2_Reimbursement-Parking_Cahya_Oscar_Nawa\ReimbursementParking\ReimbursementParkingClient\Views\Main\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <!-- Small boxes (Stat box) -->
    <div class=""row"">
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-info"">
                <div class=""inner"">
                    <h3>150</h3>

                    <p>New Orders</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-success"">
                <div class=""inner"">
                    <h3>53<sup style=""font-size: 20px"">%</sup></h3>

                    <p>Bounce Rate</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </d");
            WriteLiteral(@"iv>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-warning"">
                <div class=""inner"">
                    <h3>44</h3>

                    <p>User Registrations</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-person-add""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-danger"">
                <div class=""inner"">
                    <h3>65</h3>

                    <p>Unique Visitors</p>
                </div>
                <div class=""icon"">
         ");
            WriteLiteral(@"           <i class=""ion ion-pie-graph""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
    </div>
    <!-- /.row -->
    <!-- Main row -->
    <div class=""row"">
        <!-- Left col -->
        <section class=""col-lg-7 connectedSortable"">
            <!-- Custom tabs (Charts with tabs)-->
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">
                        <i class=""fas fa-chart-pie mr-1""></i>
                        Sales
                    </h3>
                    <div class=""card-tools"">
                        <ul class=""nav nav-pills ml-auto"">
                            <li class=""nav-item"">
                                <a class=""nav-link active"" href=""#revenue-chart"" data-toggle=""tab"">Area</a>
                            </li>
                            <li");
            WriteLiteral(@" class=""nav-item"">
                                <a class=""nav-link"" href=""#sales-chart"" data-toggle=""tab"">Donut</a>
                            </li>
                        </ul>
                    </div>
                </div><!-- /.card-header -->
                <div class=""card-body"">
                    <div class=""tab-content p-0"">
                        <!-- Morris chart - Sales -->
                        <div class=""chart tab-pane active"" id=""revenue-chart""
                             style=""position: relative; height: 300px;"">
                            <canvas id=""revenue-chart-canvas"" height=""300"" style=""height: 300px;""></canvas>
                        </div>
                        <div class=""chart tab-pane"" id=""sales-chart"" style=""position: relative; height: 300px;"">
                            <canvas id=""sales-chart-canvas"" height=""300"" style=""height: 300px;""></canvas>
                        </div>
                    </div>
                </div><!-- /.card-body --");
            WriteLiteral(@">
            </div>
            <!-- /.card -->
            <!-- DIRECT CHAT -->
            <div class=""card direct-chat direct-chat-primary"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Direct Chat</h3>

                    <div class=""card-tools"">
                        <span data-toggle=""tooltip"" title=""3 New Messages"" class=""badge badge-primary"">3</span>
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                        <button type=""button"" class=""btn btn-tool"" data-toggle=""tooltip"" title=""Contacts""
                                data-widget=""chat-pane-toggle"">
                            <i class=""fas fa-comments""></i>
                        </button>
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"">
                            <i class=""fas fa-times""></i>");
            WriteLiteral(@"
                        </button>
                    </div>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <!-- Conversations are loaded here -->
                    <div class=""direct-chat-messages"">
                        <!-- Message. Default to the left -->
                        <div class=""direct-chat-msg"">
                            <div class=""direct-chat-infos clearfix"">
                                <span class=""direct-chat-name float-left"">Alexander Pierce</span>
                                <span class=""direct-chat-timestamp float-right"">23 Jan 2:00 pm</span>
                            </div>
                            <!-- /.direct-chat-infos -->
                            <img class=""direct-chat-img"" src=""dist/img/user1-128x128.jpg"" alt=""message user image"">
                            <!-- /.direct-chat-img -->
                            <div class=""direct-chat-text"">
                     ");
            WriteLiteral(@"           Is this template really for free? That's unbelievable!
                            </div>
                            <!-- /.direct-chat-text -->
                        </div>
                        <!-- /.direct-chat-msg -->
                        <!-- Message to the right -->
                        <div class=""direct-chat-msg right"">
                            <div class=""direct-chat-infos clearfix"">
                                <span class=""direct-chat-name float-right"">Sarah Bullock</span>
                                <span class=""direct-chat-timestamp float-left"">23 Jan 2:05 pm</span>
                            </div>
                            <!-- /.direct-chat-infos -->
                            <img class=""direct-chat-img"" src=""dist/img/user3-128x128.jpg"" alt=""message user image"">
                            <!-- /.direct-chat-img -->
                            <div class=""direct-chat-text"">
                                You better believe it!
            ");
            WriteLiteral(@"                </div>
                            <!-- /.direct-chat-text -->
                        </div>
                        <!-- /.direct-chat-msg -->
                        <!-- Message. Default to the left -->
                        <div class=""direct-chat-msg"">
                            <div class=""direct-chat-infos clearfix"">
                                <span class=""direct-chat-name float-left"">Alexander Pierce</span>
                                <span class=""direct-chat-timestamp float-right"">23 Jan 5:37 pm</span>
                            </div>
                            <!-- /.direct-chat-infos -->
                            <img class=""direct-chat-img"" src=""dist/img/user1-128x128.jpg"" alt=""message user image"">
                            <!-- /.direct-chat-img -->
                            <div class=""direct-chat-text"">
                                Working with AdminLTE on a great new app! Wanna join?
                            </div>
                   ");
            WriteLiteral(@"         <!-- /.direct-chat-text -->
                        </div>
                        <!-- /.direct-chat-msg -->
                        <!-- Message to the right -->
                        <div class=""direct-chat-msg right"">
                            <div class=""direct-chat-infos clearfix"">
                                <span class=""direct-chat-name float-right"">Sarah Bullock</span>
                                <span class=""direct-chat-timestamp float-left"">23 Jan 6:10 pm</span>
                            </div>
                            <!-- /.direct-chat-infos -->
                            <img class=""direct-chat-img"" src=""dist/img/user3-128x128.jpg"" alt=""message user image"">
                            <!-- /.direct-chat-img -->
                            <div class=""direct-chat-text"">
                                I would love to.
                            </div>
                            <!-- /.direct-chat-text -->
                        </div>
               ");
            WriteLiteral(@"         <!-- /.direct-chat-msg -->

                    </div>
                    <!--/.direct-chat-messages-->
                    <!-- Contacts are loaded here -->
                    <div class=""direct-chat-contacts"">
                        <ul class=""contacts-list"">
                            <li>
                                <a href=""#"">
                                    <img class=""contacts-list-img"" src=""dist/img/user1-128x128.jpg"">

                                    <div class=""contacts-list-info"">
                                        <span class=""contacts-list-name"">
                                            Count Dracula
                                            <small class=""contacts-list-date float-right"">2/28/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">How have you been? I was...</span>
                                    </div>
                                    <!-- /.co");
            WriteLiteral(@"ntacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contact Item -->
                            <li>
                                <a href=""#"">
                                    <img class=""contacts-list-img"" src=""dist/img/user7-128x128.jpg"">

                                    <div class=""contacts-list-info"">
                                        <span class=""contacts-list-name"">
                                            Sarah Doe
                                            <small class=""contacts-list-date float-right"">2/23/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">I will be waiting for...</span>
                                    </div>
                                    <!-- /.contacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contac");
            WriteLiteral(@"t Item -->
                            <li>
                                <a href=""#"">
                                    <img class=""contacts-list-img"" src=""dist/img/user3-128x128.jpg"">

                                    <div class=""contacts-list-info"">
                                        <span class=""contacts-list-name"">
                                            Nadia Jolie
                                            <small class=""contacts-list-date float-right"">2/20/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">I'll call you back at...</span>
                                    </div>
                                    <!-- /.contacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contact Item -->
                            <li>
                                <a href=""#"">
                                    <img cla");
            WriteLiteral(@"ss=""contacts-list-img"" src=""dist/img/user5-128x128.jpg"">

                                    <div class=""contacts-list-info"">
                                        <span class=""contacts-list-name"">
                                            Nora S. Vans
                                            <small class=""contacts-list-date float-right"">2/10/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">Where is your new...</span>
                                    </div>
                                    <!-- /.contacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contact Item -->
                            <li>
                                <a href=""#"">
                                    <img class=""contacts-list-img"" src=""dist/img/user6-128x128.jpg"">

                                    <div class=""contacts-list-info"">
         ");
            WriteLiteral(@"                               <span class=""contacts-list-name"">
                                            John K.
                                            <small class=""contacts-list-date float-right"">1/27/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">Can I take a look at...</span>
                                    </div>
                                    <!-- /.contacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contact Item -->
                            <li>
                                <a href=""#"">
                                    <img class=""contacts-list-img"" src=""dist/img/user8-128x128.jpg"">

                                    <div class=""contacts-list-info"">
                                        <span class=""contacts-list-name"">
                                            Kenneth M.
                   ");
            WriteLiteral(@"                         <small class=""contacts-list-date float-right"">1/4/2015</small>
                                        </span>
                                        <span class=""contacts-list-msg"">Never mind I found...</span>
                                    </div>
                                    <!-- /.contacts-list-info -->
                                </a>
                            </li>
                            <!-- End Contact Item -->
                        </ul>
                        <!-- /.contacts-list -->
                    </div>
                    <!-- /.direct-chat-pane -->
                </div>
                <!-- /.card-body -->
                <div class=""card-footer"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a77075d4e2d3aa66a1858344145a64539ad56f220351", async() => {
                WriteLiteral(@"
                        <div class=""input-group"">
                            <input type=""text"" name=""message"" placeholder=""Type Message ..."" class=""form-control"">
                            <span class=""input-group-append"">
                                <button type=""button"" class=""btn btn-primary"">Send</button>
                            </span>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <!-- /.card-footer-->
            </div>
            <!--/.direct-chat -->
            <!-- TO DO List -->
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">
                        <i class=""ion ion-clipboard mr-1""></i>
                        To Do List
                    </h3>

                    <div class=""card-tools"">
                        <ul class=""pagination pagination-sm"">
                            <li class=""page-item""><a href=""#"" class=""page-link"">&laquo;</a></li>
                            <li class=""page-item""><a href=""#"" class=""page-link"">1</a></li>
                            <li class=""page-item""><a href=""#"" class=""page-link"">2</a></li>
                            <li class=""page-item""><a href=""#"" class=""page-link"">3</a></li>
                            <li class=""page-item""><a href=""#"" class=""page-link"">&raquo;</a></li>
                        </ul>
          ");
            WriteLiteral(@"          </div>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <ul class=""todo-list"" data-widget=""todo-list"">
                        <li>
                            <!-- drag handle -->
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <!-- checkbox -->
                            <div class=""icheck-primary d-inline ml-2"">
                                <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 17330, "\"", 17338, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo1"" id=""todoCheck1"">
                                <label for=""todoCheck1""></label>
                            </div>
                            <!-- todo text -->
                            <span class=""text"">Design a nice theme</span>
                            <!-- Emphasis label -->
                            <small class=""badge badge-danger""><i class=""far fa-clock""></i> 2 mins</small>
                            <!-- General tools such as edit or delete-->
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                        <li>
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <div class=""");
            WriteLiteral("icheck-primary d-inline ml-2\">\r\n                                <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 18449, "\"", 18457, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo2"" id=""todoCheck2"" checked>
                                <label for=""todoCheck2""></label>
                            </div>
                            <span class=""text"">Make the theme responsive</span>
                            <small class=""badge badge-info""><i class=""far fa-clock""></i> 4 hours</small>
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                        <li>
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <div class=""icheck-primary d-inline ml-2"">
                                <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 19406, "\"", 19414, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo3"" id=""todoCheck3"">
                                <label for=""todoCheck3""></label>
                            </div>
                            <span class=""text"">Let theme shine like a star</span>
                            <small class=""badge badge-warning""><i class=""far fa-clock""></i> 1 day</small>
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                        <li>
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <div class=""icheck-primary d-inline ml-2"">
                                <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 20358, "\"", 20366, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo4"" id=""todoCheck4"">
                                <label for=""todoCheck4""></label>
                            </div>
                            <span class=""text"">Let theme shine like a star</span>
                            <small class=""badge badge-success""><i class=""far fa-clock""></i> 3 days</small>
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                        <li>
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <div class=""icheck-primary d-inline ml-2"">
                                <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 21311, "\"", 21319, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo5"" id=""todoCheck5"">
                                <label for=""todoCheck5""></label>
                            </div>
                            <span class=""text"">Check your messages and notifications</span>
                            <small class=""badge badge-primary""><i class=""far fa-clock""></i> 1 week</small>
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                        <li>
                            <span class=""handle"">
                                <i class=""fas fa-ellipsis-v""></i>
                                <i class=""fas fa-ellipsis-v""></i>
                            </span>
                            <div class=""icheck-primary d-inline ml-2"">
                                <input type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 22274, "\"", 22282, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""todo6"" id=""todoCheck6"">
                                <label for=""todoCheck6""></label>
                            </div>
                            <span class=""text"">Let theme shine like a star</span>
                            <small class=""badge badge-secondary""><i class=""far fa-clock""></i> 1 month</small>
                            <div class=""tools"">
                                <i class=""fas fa-edit""></i>
                                <i class=""fas fa-trash-o""></i>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- /.card-body -->
                <div class=""card-footer clearfix"">
                    <button type=""button"" class=""btn btn-info float-right""><i class=""fas fa-plus""></i> Add item</button>
                </div>
            </div>
            <!-- /.card -->
        </section>
        <!-- /.Left col -->
        <!-- right col (We are only adding the ID to make the widgets ");
            WriteLiteral(@"sortable)-->
        <section class=""col-lg-5 connectedSortable"">

            <!-- Map card -->
            <div class=""card bg-gradient-primary"">
                <div class=""card-header border-0"">
                    <h3 class=""card-title"">
                        <i class=""fas fa-map-marker-alt mr-1""></i>
                        Visitors
                    </h3>
                    <!-- card tools -->
                    <div class=""card-tools"">
                        <button type=""button""
                                class=""btn btn-primary btn-sm daterange""
                                data-toggle=""tooltip""
                                title=""Date range"">
                            <i class=""far fa-calendar-alt""></i>
                        </button>
                        <button type=""button""
                                class=""btn btn-primary btn-sm""
                                data-card-widget=""collapse""
                                data-toggle=""tooltip""
  ");
            WriteLiteral(@"                              title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                    <!-- /.card-tools -->
                </div>
                <div class=""card-body"">
                    <div id=""world-map"" style=""height: 250px; width: 100%;""></div>
                </div>
                <!-- /.card-body-->
                <div class=""card-footer bg-transparent"">
                    <div class=""row"">
                        <div class=""col-4 text-center"">
                            <div id=""sparkline-1""></div>
                            <div class=""text-white"">Visitors</div>
                        </div>
                        <!-- ./col -->
                        <div class=""col-4 text-center"">
                            <div id=""sparkline-2""></div>
                            <div class=""text-white"">Online</div>
                        </div>
                        <!-- ./col -");
            WriteLiteral(@"->
                        <div class=""col-4 text-center"">
                            <div id=""sparkline-3""></div>
                            <div class=""text-white"">Sales</div>
                        </div>
                        <!-- ./col -->
                    </div>
                    <!-- /.row -->
                </div>
            </div>
            <!-- /.card -->
            <!-- solid sales graph -->
            <div class=""card bg-gradient-info"">
                <div class=""card-header border-0"">
                    <h3 class=""card-title"">
                        <i class=""fas fa-th mr-1""></i>
                        Sales Graph
                    </h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn bg-info btn-sm"" data-card-widget=""collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                        <button type=""button"" class=""btn bg-info btn-sm"" data-car");
            WriteLiteral(@"d-widget=""remove"">
                            <i class=""fas fa-times""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    <canvas class=""chart"" id=""line-chart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                </div>
                <!-- /.card-body -->
                <div class=""card-footer bg-transparent"">
                    <div class=""row"">
                        <div class=""col-4 text-center"">
                            <input type=""text"" class=""knob"" data-readonly=""true"" value=""20"" data-width=""60"" data-height=""60""
                                   data-fgColor=""#39CCCC"">

                            <div class=""text-white"">Mail-Orders</div>
                        </div>
                        <!-- ./col -->
                        <div class=""col-4 text-center"">
                            <input type=""text"" class=""knob"" data-re");
            WriteLiteral(@"adonly=""true"" value=""50"" data-width=""60"" data-height=""60""
                                   data-fgColor=""#39CCCC"">

                            <div class=""text-white"">Online</div>
                        </div>
                        <!-- ./col -->
                        <div class=""col-4 text-center"">
                            <input type=""text"" class=""knob"" data-readonly=""true"" value=""30"" data-width=""60"" data-height=""60""
                                   data-fgColor=""#39CCCC"">

                            <div class=""text-white"">In-Store</div>
                        </div>
                        <!-- ./col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.card-footer -->
            </div>
            <!-- /.card -->
            <!-- Calendar -->
            <div class=""card bg-gradient-success"">
                <div class=""card-header border-0"">

                    <h3 class=""card-title"">
                     ");
            WriteLiteral(@"   <i class=""far fa-calendar-alt""></i>
                        Calendar
                    </h3>
                    <!-- tools card -->
                    <div class=""card-tools"">
                        <!-- button with a dropdown -->
                        <div class=""btn-group"">
                            <button type=""button"" class=""btn btn-success btn-sm dropdown-toggle"" data-toggle=""dropdown"" data-offset=""-52"">
                                <i class=""fas fa-bars""></i>
                            </button>
                            <div class=""dropdown-menu"" role=""menu"">
                                <a href=""#"" class=""dropdown-item"">Add new event</a>
                                <a href=""#"" class=""dropdown-item"">Clear events</a>
                                <div class=""dropdown-divider""></div>
                                <a href=""#"" class=""dropdown-item"">View calendar</a>
                            </div>
                        </div>
                        <butt");
            WriteLiteral(@"on type=""button"" class=""btn btn-success btn-sm"" data-card-widget=""collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                        <button type=""button"" class=""btn btn-success btn-sm"" data-card-widget=""remove"">
                            <i class=""fas fa-times""></i>
                        </button>
                    </div>
                    <!-- /. tools -->
                </div>
                <!-- /.card-header -->
                <div class=""card-body pt-0"">
                    <!--The calendar -->
                    <div id=""calendar"" style=""width: 100%""></div>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </section>
        <!-- right col -->
    </div>
    <!-- /.row (main row) -->
</div><!-- /.container-fluid -->
");
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
