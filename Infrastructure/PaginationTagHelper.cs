using BowlingApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Infrastructure
{
    /**
     * This is the PaginationTagHelper class, which inherits from the TagHelper class
     * it contains a private IUrlHelperFactory object, a PageInfo object, a Dictionary of the page number string (key) and the page number object (value),
     * a ViewContext object, a PageClass string, a PageClassNormal string, and a PageClassSelected string
     * The Process method is overrided in this class to build an a tag inside a div tag with all the specifications for page navigations (5 items per page)
     */
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        public PageInfo PageInfo { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> pageUrl { get; set; } = new Dictionary<string, object>();
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public PaginationTagHelper(IUrlHelperFactory urlHelper)
        {
            urlInfo = urlHelper;
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

            TagBuilder divTag = new TagBuilder("div");

            for(int rep = 1; rep <= PageInfo.NumOfPages; rep++)
            {
                TagBuilder aTag = new TagBuilder("a");

                pageUrl["pageNum"] = rep;
                aTag.Attributes["href"] = urlHelp.Action("Index", pageUrl);

                aTag.AddCssClass(PageClass);
                aTag.AddCssClass(rep == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);

                aTag.InnerHtml.Append(rep.ToString());

                divTag.InnerHtml.AppendHtml(aTag);
            }
            output.Content.AppendHtml(divTag.InnerHtml);
        }
    }
}
