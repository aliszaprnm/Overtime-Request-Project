#pragma checksum "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26ba5b6073c02c67336dc8599368dc1f056e91e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApprovalHistoryFinance_Index), @"mvc.1.0.view", @"/Views/ApprovalHistoryFinance/Index.cshtml")]
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
#line 1 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26ba5b6073c02c67336dc8599368dc1f056e91e1", @"/Views/ApprovalHistoryFinance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_ApprovalHistoryFinance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml"
  
    Layout = "_ApprovalHistoryFinance";
    ViewData["Role"] = @ViewBag.sessionRole;
    ViewData["Email"] = @ViewBag.sessionEmail;
    ViewData["NIK"] = @ViewBag.sessionNIK;
    ViewData["FirstName"] = @ViewBag.sessionFName;
    ViewData["LastName"] = @ViewBag.sessionLName;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Begin Page Content -->\r\n<div class=\"container-fluid\">\r\n\r\n    <input id=\"role\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 392, "\"", 417, 1);
#nullable restore
#line 12 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml"
WriteAttributeValue("", 400, ViewData["Role"], 400, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <input id=\"emailS\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 464, "\"", 490, 1);
#nullable restore
#line 13 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml"
WriteAttributeValue("", 472, ViewData["Email"], 472, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <input id=\"managerId\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 540, "\"", 564, 1);
#nullable restore
#line 14 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml"
WriteAttributeValue("", 548, ViewData["NIK"], 548, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n    <!-- Page Heading -->\r\n    <div class=\"d-sm-flex align-items-center justify-content-between mb-4\">\r\n        <h1 class=\"h3 mb-0 text-gray-800\">Approved Overtime Request by ");
#nullable restore
#line 18 "C:\Users\nkhal\Desktop\Overtime-Request-Project\OvertimeProject\Client\Views\ApprovalHistoryFinance\Index.cshtml"
                                                                  Write(ViewData["Role"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n");
            WriteLiteral(@"
    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <button type=""button"" class=""btn btn-success"" onclick=""exportToExcel();""><i class=""fas fa-file-excel""></i> Excel</button>
            <button type=""button"" class=""btn btn-danger"" onclick=""exportToPdf();""><i class=""fas fa-file-pdf""></i> PDF</button>
        </div>

        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-hover table-bordered"" id=""requestTable"" width=""100%"" cellspacing=""0"">
                    <thead style=""background-color:#4E73DF; color:white"">
");
            WriteLiteral(@"                        <tr>
                            <th style=""text-align:center; vertical-align:middle"">No</th>
                            <th style=""text-align:center; vertical-align:middle"">Request Date</th>
                            <th style=""text-align:center; vertical-align:middle"">NIK</th>
                            <th style=""text-align:center; vertical-align:middle"">Employee Name</th>
                            <th style=""text-align:center; vertical-align:middle"">Overtime Name</th>
                            <th style=""text-align:center; vertical-align:middle"">Approval Status</th>
                            <th style=""text-align:center; vertical-align:middle"">Action</th>
                        </tr>
                    </thead>
                    <tbody id=""tableHistory"">
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<!-- /.container-fluid -->
<!-- Detail Modal -->
<div class=""modal fade bd-example-modal-l"" ");
            WriteLiteral(@"id=""detailModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26ba5b6073c02c67336dc8599368dc1f056e91e18574", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"                    <div>
                        <input type=""text"" class=""form-control"" style=""display:none"" id=""reqId"">
                        <input type=""text"" class=""form-control"" style=""display:none"" id=""email"">
                        <input type=""text"" class=""form-control"" style=""display:none"" id=""nik"">
                    </div>
                ");
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
            WriteLiteral("\r\n                <button type=\"button\" style=\"float:right\" class=\"btn btn-danger\" data-dismiss=\"modal\" onclick=\"window.location.reload();\">Close</button>\r\n");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
