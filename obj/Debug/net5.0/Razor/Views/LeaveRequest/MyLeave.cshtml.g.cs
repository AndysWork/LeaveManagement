#pragma checksum "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5992e48358e2652899f4efddc6d4e59df5ff04d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LeaveRequest_MyLeave), @"mvc.1.0.view", @"/Views/LeaveRequest/MyLeave.cshtml")]
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
#line 1 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\_ViewImports.cshtml"
using LeaveManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\_ViewImports.cshtml"
using LeaveManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5992e48358e2652899f4efddc6d4e59df5ff04d8", @"/Views/LeaveRequest/MyLeave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61013c2965838230520743cd2eb90f34a8aaa45", @"/Views/_ViewImports.cshtml")]
    public class Views_LeaveRequest_MyLeave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeLeaveRequestViewVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CancelRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure to cancel the request?\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
  
    ViewData["Title"] = "MyLeave";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My Leave Allocations</h1>\r\n<div class=\"jumbotron\">\r\n    <div class=\"card\">\r\n        <ul class=\"list-group list-group-flush\">\r\n");
#nullable restore
#line 12 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
             foreach (var item in Model.LeaveAllocations)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">\r\n                    <h6>");
#nullable restore
#line 15 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                   Write(item.LeaveType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-secondary\">");
#nullable restore
#line 15 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                                                                            Write(item.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h6>\r\n                </li>\r\n");
#nullable restore
#line 17 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </ul>
    </div>
</div>
<hr />
<h1>My Leave Requests</h1>
<table id=""tblData"" class=""table"">
    <thead>
        <tr>
            <th>
                Leave Type
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Date Requested
            </th>
            <th>
                Approval State
            </th>
            <th>
                Cancel Request
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 48 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
         foreach (var item in Model.LeaveRequests)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
               Write(Html.DisplayFor(modelItem => item.LeaveType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateRequested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 64 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                     if (item.Cancelled)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-secondary\">Cancelled</span>\r\n");
#nullable restore
#line 67 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                    }
                    else if (item.Approved == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-success\">Approved</span>\r\n");
#nullable restore
#line 71 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                    }
                    else if (item.Approved == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-danger\">Rejected</span>\r\n");
#nullable restore
#line 75 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-warning\">Pending Approval</span>\r\n");
#nullable restore
#line 79 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td class=\"text-center\">\r\n");
#nullable restore
#line 82 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                     if (!item.Cancelled && item.StartDate > DateTime.Now)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5992e48358e2652899f4efddc6d4e59df5ff04d810155", async() => {
                WriteLiteral("\r\n                            <i class=\"fa fa-trash\" aria-hidden=\"true\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 87 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 90 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveRequest\MyLeave.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeLeaveRequestViewVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
