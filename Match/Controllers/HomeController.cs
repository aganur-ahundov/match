using Match.ParsingCode;
using Match_BLL;
using Match_BLL.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Match.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(XBetParser.GetFootballGames());
        }

        public ActionResult GamesFilterView()
        {
            return View("/Views/Home/GamesFilter.cshtml");
        }

        public ActionResult SearchFilteredGames(FilterViewModel model)
        {
            List<FilterResultLine> games = new List<FilterResultLine>();
            if (model.BetType != 0)
            {
                games = XBetParser.GetFootballGames()
                   .Where(g => g.Line.Coefs

                   .Any(c => c.Type == model.BetType
                        && c.Value >= model.Min
                        && c.Value <= model.Max))

                           .Select(l => new FilterResultLine(new List<BetType>() { model.BetType }, l.Line))
                           .ToList();
            }
            else
            {
                foreach (var l in XBetParser.GetFootballGames())
                {
                    List<BetType> types = new List<BetType>();

                    foreach (var c in l.Line.Coefs)
                    {
                        if (c.Value >= model.Min && c.Value <= model.Max)
                        {
                            types.Add(c.Type);
                        }
                    }

                    if (types.Count > 0)
                    {
                        games.Add(new FilterResultLine(types, l.Line));
                    }
                }
            }

            return PartialView("/Views/Partials/_pv_FilterResults.cshtml", games);
        }

        public ActionResult AddMatch()
        {
            return null;
        }
    }
}