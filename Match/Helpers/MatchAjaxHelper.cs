using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Match.Helpers
{
    public static class MatchAjaxHelper
    {
        public static MvcHtmlString ImageActionLink(this AjaxHelper ajax, string imageUrl, string altText, string actionName, string controller, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);
            var icon = builder.ToString(TagRenderMode.SelfClosing);

            return ajax.ActionLink(icon, actionName, controller, routeValues, ajaxOptions);
        }
    }
}