#pragma checksum "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\HistoryRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c4383d9d12f40dd43e288a3355c1a07684b8f66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HistoryRequest_Index), @"mvc.1.0.view", @"/Views/HistoryRequest/Index.cshtml")]
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
#line 1 "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c4383d9d12f40dd43e288a3355c1a07684b8f66", @"/Views/HistoryRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_HistoryRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formDetail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\HistoryRequest\Index.cshtml"
  
    Layout = "_HistoryRequest";
    ViewData["Email"] = @ViewBag.sessionEmail;
    ViewData["NIK"] = @ViewBag.sessionNIK;
    ViewData["FirstName"] = @ViewBag.sessionFName;
    ViewData["LastName"] = @ViewBag.sessionLName;
    //ViewData["Role"] = @ViewBag.sessionRole;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Begin Page Content -->\r\n<div class=\"container-fluid\">\r\n\r\n    <!-- Page Heading -->\r\n    <div class=\"d-sm-flex align-items-center justify-content-between mb-4\">\r\n        <h1 class=\"h3 mb-0 text-gray-800\">Overtime Requests History</h1>\r\n    </div>\r\n");
            WriteLiteral(@"    <ul class=""nav nav-tabs"">
        <li class=""nav-item"">
            <a class=""nav-link active"" href=""/HistoryRequest"">Current Requests</a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link"" href=""/ApprovedByManager"">Waiting Finance Approval</a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link"" href=""/ApprovedRequest"">Approved Requests</a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link"" href=""/RejectedRequest"">Rejected Requests</a>
        </li>
    </ul>
");
            WriteLiteral("\r\n    <!-- DataTales Example -->\r\n    <div class=\"card shadow mb-4\">\r\n        <!--<div class=\"card-header py-3\">-->\r\n");
            WriteLiteral(@"            <!--<button type=""button"" class=""btn btn-success"" onclick=""exportToExcel();""><i class=""fas fa-file-excel""></i> Excel</button>
            <button type=""button"" class=""btn btn-danger"" onclick=""exportToPdf();""><i class=""fas fa-file-pdf""></i> PDF</button>
        </div>-->
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-hover table-bordered"" id=""historyTable"" width=""100%"" cellspacing=""0"">
                    <thead style=""background-color:#4E73DF; color:white"">
                        <!--<tr>
                        <th rowspan=""2"" style=""text-align:center; vertical-align:middle"">No</th>-->
");
            WriteLiteral(@"                        <!--<th colspan=""2"" style=""text-align:center"">
                                Date
                            </th>
                            <th colspan=""2"" style=""text-align:center"">Time</th>
                            <th rowspan=""2"" style=""text-align:center; vertical-align:middle"">Total Hours</th>
                            <th rowspan=""2"" style=""text-align:center; vertical-align:middle"">Task</th>
                            <th rowspan=""2"" style=""text-align:center; vertical-align:middle"">Approval Status</th>
                            <th rowspan=""2"" style=""text-align:center; vertical-align:middle"">Action</th>
                        </tr>
                        <tr>
                            <th style=""text-align:center"">Start</th>
                            <th style=""text-align:center"">End</th>
                            <th style=""text-align:center"">Start</th>
                            <th style=""text-align:center"">End</th>
                        <");
            WriteLiteral(@"/tr>-->
                        <tr>
                            <th style=""text-align:center"">No</th>
                            <th style=""text-align:center"">Request Date</th>
                            <th style=""text-align:center"">Task</th>
                            <th style=""text-align:center"">Total Hours</th>
                            <th style=""text-align:center"">Approval Status</th>
                            <th style=""text-align:center"">Action</th>
                        </tr>
                    </thead>
                    <tbody id=""tableHistory"">
");
            WriteLiteral("                    </tbody>\r\n                </table>\r\n                <input id=\"nips\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 5092, "\"", 5116, 1);
#nullable restore
#line 95 "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\HistoryRequest\Index.cshtml"
WriteAttributeValue("", 5100, ViewData["NIK"], 5100, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
            WriteLiteral("                <input id=\"emailS\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 5261, "\"", 5287, 1);
#nullable restore
#line 97 "C:\Users\Maulana\Documents\GitHub\Overtime-Request-Project\OvertimeProject\Client\Views\HistoryRequest\Index.cshtml"
WriteAttributeValue("", 5269, ViewData["Email"], 5269, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            </div>
        </div>
    </div>
</div>
<!-- /.container-fluid -->


<!-- Detail Modal -->
<div class=""modal fade bd-example-modal-l"" id=""detailModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-l"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""regist"">Overtime Request Detail</h5>
                <button type=""button"" class=""close"" onclick=""window.location.reload();"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c4383d9d12f40dd43e288a3355c1a07684b8f669517", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""dataNIK"">NIK</label>
                            <input type=""text"" class=""form-control"" id=""dataNIK"" name=""dataNIK"" placeholder=""NIK"" readonly>
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""dataName"">Name</label>
                            <input type=""text"" class=""form-control"" id=""dataName"" name=""dataName"" placeholder=""Name"" readonly>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""dataRequestId"">Request ID</label>
                            <input type=""text"" class=""form-control"" id=""dataRequestId"" name=""dataRequestId"" placeholder=""Request ID"" readonly>
                        </div>
                        <div class=");
                WriteLiteral(@"""form-group col-md-6"">
                            <label for=""dataRequestDate"">Request Date</label>
                            <input type=""date"" class=""form-control"" id=""dataRequestDate"" name=""dataRequestDate"" readonly>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""dataStartTime"">Start Time</label>
                            <input type=""text"" class=""form-control"" id=""dataStartTime"" name=""dataStartTime"" readonly>
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""dataEndTime"">End Time</label>
                            <input type=""text"" class=""form-control"" id=""dataEndTime"" name=""dataEndTime"" readonly>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
 ");
                WriteLiteral(@"                           <label for=""dataTask"">Task</label>
                            <input type=""text"" class=""form-control"" id=""dataTask"" name=""dataTask"" placeholder=""Task"" readonly>
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""dataTotal"">Total Hours</label>
                            <input type=""text"" class=""form-control"" id=""dataTotal"" name=""dataTotal"" placeholder=""Total Hours"" readonly>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""dataStatus"">Status</label>
                            <input type=""text"" class=""form-control"" id=""dataStatus"" name=""dataStatus"" placeholder=""Approval Status"" readonly>
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""dataCommission"">Commission</");
                WriteLiteral("label>\r\n                            <input type=\"text\" class=\"form-control\" id=\"dataCommission\" name=\"dataCommission\" placeholder=\"Commission\" readonly>\r\n                        </div>\r\n                    </div>\r\n");
                WriteLiteral("                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"modal-footer\">\r\n");
            WriteLiteral("                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\" onclick=\"window.location.reload();\">Close</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
