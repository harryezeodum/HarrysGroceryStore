using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public string PageAction { get; set; }

        public string PageClass { get; set; }

        public bool PageClassEnabled { get; set; } = false;

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        public PagingInfo PageModel { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { userPage = i });

                if (PageClassEnabled)
                {
                    tag.AddCssClass(PageClass);
                    if (i == PageModel.CurrentPage)
                    {
                        tag.AddCssClass(PageClassSelected);
                    }
                    else
                    {
                        tag.AddCssClass(PageClassNormal);
                    }
                }
                tag.InnerHtml.Append($"{i}");
                result.InnerHtml.AppendHtml(tag);
                output.Content.AppendHtml(result.InnerHtml);
            }
            
        }
    }
}
