#pragma checksum "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2e1125c690042568c9bf1af4957b403989ff5a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LeaveAllocation_Details), @"mvc.1.0.view", @"/Views/LeaveAllocation/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2e1125c690042568c9bf1af4957b403989ff5a7", @"/Views/LeaveAllocation/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61013c2965838230520743cd2eb90f34a8aaa45", @"/Views/_ViewImports.cshtml")]
    public class Views_LeaveAllocation_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LeaveManagement.Models.ViewLeaveAllocationsVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListEmployees", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_AdminLTE.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details For - ");
#nullable restore
#line 8 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
             Write(Model.Employee.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 8 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
                                       Write(Model.Employee.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.TaxId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.TaxId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Employee.DateJoined));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
       Write(Html.DisplayFor(model => model.Employee.DateJoined));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<hr />\r\n<h2>Leave Allocations</h2>\r\n\r\n<div class=\"card col-md-12\">\r\n    <ul class=\"list-group list-group-flush\">\r\n");
#nullable restore
#line 69 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
         foreach (var item in Model.LeaveAllocations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item\">\r\n                <h6>");
#nullable restore
#line 72 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
               Write(item.LeaveType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-secondary\">");
#nullable restore
#line 72 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
                                                                        Write(item.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> | ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2e1125c690042568c9bf1af4957b403989ff5a711890", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i> Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
                                                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" </h6>\r\n            </li>\r\n");
#nullable restore
#line 74 "F:\Github_Version_Learning_Projects\LeaveManagement\Views\LeaveAllocation\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>\r\n<br />\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2e1125c690042568c9bf1af4957b403989ff5a714533", async() => {
                WriteLiteral("Back to Employee List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LeaveManagement.Models.ViewLeaveAllocationsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
