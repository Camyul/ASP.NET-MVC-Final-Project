using System.Collections.Generic;
using System.Web.Mvc;

namespace TelerikAcademy.FinalProject.Web.Infrastructure.Helpers
{
    public static class HtmlExtentions
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, object htmlAtributes = null)
        {
            var input = new TagBuilder("input");
            var atributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAtributes) as IDictionary<string, string>;
            input.MergeAttributes(atributes);
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("@class", "form-control btn btn-info");

            if (htmlAtributes != null)
            {
                foreach (var atr in htmlAtributes.GetType().GetProperties())
                {
                    input.Attributes.Add(atr.Name, atr.GetValue(htmlAtributes, null).ToString());
                }
            }
            return new MvcHtmlString(input.ToString());
        }
    }
}