#pragma checksum "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f5cee3a80740e12c7a9b845ca989640e7651ebb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\_ViewImports.cshtml"
using Utility.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\_ViewImports.cshtml"
using Utility.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f5cee3a80740e12c7a9b845ca989640e7651ebb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c86472d4d0d49958b3923cae7d5d0417c7d1ba7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
  int i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
 foreach (var levelOne in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"panel-group\"");
            BeginWriteAttribute("id", " id=\"", 129, "\"", 146, 2);
            WriteAttributeValue("", 134, "accordion_", 134, 10, true);
#nullable restore
#line 9 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 144, i, 144, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"panel panel-default\"");
            BeginWriteAttribute("id", " id=\"", 190, "\"", 203, 2);
            WriteAttributeValue("", 195, "panel_", 195, 6, true);
#nullable restore
#line 10 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 201, i, 201, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"panel-heading\">\r\n                <h4 class=\"panel-title\">\r\n                    <a data-toggle=\"collapse\" data-target=\"#collapseOne_");
#nullable restore
#line 13 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("href", " href=\"", 365, "\"", 387, 2);
            WriteAttributeValue("", 372, "#collapseOne_", 372, 13, true);
#nullable restore
#line 13 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 385, i, 385, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                                                                                              Write(levelOne.MenuLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </h4>\r\n            </div>\r\n            <div");
            BeginWriteAttribute("id", " id=\"", 473, "\"", 492, 2);
            WriteAttributeValue("", 478, "collapseOne_", 478, 12, true);
#nullable restore
#line 16 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 490, i, 490, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"panel-collapse collapse\">\r\n                <div class=\"panel-body\">\r\n                    <ul");
            BeginWriteAttribute("class", " class=\"", 593, "\"", 601, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 602, "\"", 629, 2);
            WriteAttributeValue("", 607, "id-", 607, 3, true);
#nullable restore
#line 18 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 610, levelOne.MenuLevel, 610, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 19 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                         foreach (var item in levelOne.Items)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>N??vel ");
#nullable restore
#line 21 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                             Write(levelOne.MenuLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Item ");
#nullable restore
#line 21 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                                                        Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 22 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                    <ul class=\"filter-categories__list\">\r\n");
#nullable restore
#line 25 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                         foreach (var filter in levelOne.Filters)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>N??vel ");
#nullable restore
#line 27 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                                 Write(levelOne.MenuLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Item ");
#nullable restore
#line 27 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                                                            Write(filter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 28 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 34 "C:\Projects\Personal\DebugTest\Debug.MVC\Views\Home\Index.cshtml"
    i++;
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $('.collapse').on('show.bs.collapse', function () { //Triggered everytime the collapse is show
            $('.collapse.in').each(function () { //select current collapsed (some versions could be .show instead of .in
                $(this).collapse('hide'); //hide previously collapsed
            });
        });
    });
</script>");
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
