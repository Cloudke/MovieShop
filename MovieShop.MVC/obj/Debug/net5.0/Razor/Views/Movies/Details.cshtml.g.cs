#pragma checksum "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0378e9dcf9facc58827c3eafd1cb956f91ce9e76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0378e9dcf9facc58827c3eafd1cb956f91ce9e76", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.Response.MovieDetailResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n\r\n    <div class=\"row\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 111, "\"", 135, 1);
#nullable restore
#line 6 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 117, Model.BackdropUrl, 117, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"1500\" height=\"700\"/>\r\n    </div>\r\n\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col\">            \r\n            <img");
            BeginWriteAttribute("src", " src=\"", 260, "\"", 282, 1);
#nullable restore
#line 12 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 266, Model.PosterUrl, 266, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n\r\n        <div class=\"col\">\r\n            <div class=\"row\">\r\n                <h1> ");
#nullable restore
#line 17 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"row\">\r\n                <h5>");
#nullable restore
#line 20 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            </div>\r\n\r\n            <div>\r\n                <div class=\"row\">\r\n                    <div class=\"col\">\r\n                        ");
#nullable restore
#line 26 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m| ");
#nullable restore
#line 26 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                     Write(Model.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n\r\n                    <div class=\"col\">\r\n");
#nullable restore
#line 30 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                         foreach (var genre in Model.Genres)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5>\r\n                                ");
#nullable restore
#line 33 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                           Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </h5>\r\n");
#nullable restore
#line 35 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <h3>");
#nullable restore
#line 39 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"row\">\r\n                    ");
#nullable restore
#line 42 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               Write(Model.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>

        </div>
        <div class=""col"">
            <ul>
                <li>
                    <button type=""button""
                            class=""btn"">
                        REVIEW
                    </button>
                </li>
                <li>
                    <button type=""button""
                            class=""btn"">
                        Trailer
                    </button>
                </li>
                <li>
                    <a class=""btn"">
                        BUY ");
#nullable restore
#line 63 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </a>
                </li>
                <li>
                    <a class=""btn"">
                        WATCH MOVIE
                    </a>
                </li>
            </ul>
        </div>
    </div>
    <div class=""row"">
           <div class=""col"">
                <h3>Movie Facts</h3>
                <hr />
                <div>Release Date</div>
                <div>Run Time</div>
                <div>Box Office</div>
                <div>Budget  ");
#nullable restore
#line 81 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                        Write(Model.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n           </div>\r\n           <div class=\"col\">\r\n               <h3>Casts</h3>\r\n");
#nullable restore
#line 86 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                foreach (var cast in Model.Casts)
               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                   <div class=\"row\">\r\n                       <div class=\"col\">\r\n                           <img");
            BeginWriteAttribute("src", " src=\"", 2580, "\"", 2603, 1);
#nullable restore
#line 90 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 2586, cast.ProfilePath, 2586, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                                alt=\"", 2604, "\"", 2653, 1);
#nullable restore
#line 91 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 2643, cast.Name, 2643, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                width=\"55\" height=\"60\" />\r\n                       </div>\r\n                       <div class =\"col\"> ");
#nullable restore
#line 94 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                     Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                       <div class=\"col\"> ");
#nullable restore
#line 95 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                    Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                   </div>\r\n");
#nullable restore
#line 97 "C:\Users\owner-pc\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
               }

#line default
#line hidden
#nullable disable
            WriteLiteral("           </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.Response.MovieDetailResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
