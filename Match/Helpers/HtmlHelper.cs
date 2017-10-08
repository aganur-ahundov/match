using Match.ParsingCode;
using Match_BLL.Models;
using System.Linq;
using System.Web.Mvc;

namespace Match_BLL.Helpers
{
    public static class MatchHtmlHelper
    {
        public static MvcHtmlString RenderCoefValue(FilterResultLine line, BetType type)
        {
            return MvcHtmlString.Create($"<td class='{ (line.BetTypes.Contains(type) ? "filter-selected-value" : "")}'>" 
                + (line.Line.GetCof(type)?.Value ?? -1) + "</td>");
        }
    }
}
