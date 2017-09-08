using Match.Models;
using Match_BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Match.ParsingCode
{
    public static class XBetParser
    {
        //static string siteUrl = "https://1xdoc.xyz/ua/line/";
        static string jsonGames = "https://1xdoc.xyz/LineFeed/Get1x2_Zip?count=50&lng=ru&tf=1000000&tz=3&mode=4&country=2";

        public static List<Match_BLL.Line> GetGames()
        {
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument html = web.Load(siteUrl);

            JsonRoot root = null;
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                var jsonGames = wc.DownloadString(XBetParser.jsonGames);
                root = JsonConvert.DeserializeObject<JsonRoot>(jsonGames);
            }

            return root.Lines;
        }


        /******************************************************************************************/
        /******************************************************************************************/

        //var ul = HapHelper.GetChildNodeByAttribute(html.DocumentNode, "id", "games_content");
        //var divs = ul.Descendants("div").ToList();


        //string tournament = string.Empty;
        //var result = new List<SoccerMatch>();

        //foreach (HtmlNode node in divs)
        //{
        //    if (HapHelper.IsContainsAttr(node, "class", "c-events__name"))
        //    {
        //        tournament = HapHelper.GetChildNodeByAttribute(node, "class", "c-events__liga").InnerText;
        //    }

        //    if (HapHelper.IsContainsAttr(node, "class", "c-events__item"))
        //    {
        //        SoccerMatch match = new SoccerMatch();
        //        match.Tournament = tournament;
        //        FillMainInfo(node, match);
        //        FillBetInfo(node, match);


        //        result.Add(match);
        //    }
        //}

        //return result;

        ///* Private Help Methods */
        //private static void FillBetInfo(HtmlNode node, SoccerMatch match)
        //{
        //    var betList = node.Descendants("div")
        //        .Where(n =>
        //        !string.IsNullOrEmpty(n.Attributes["class"]?.Value)
        //        && n.Attributes["class"].Value == "c-bets__item")
        //        .ToArray();

        //    FillCoefs(match, betList);
        //}

        //private static void FillCoefs(SoccerMatch match, HtmlNode[] betList)
        //{
        //    string coef_value;
        //    match.Line = new Line();
        //    HtmlNode coef_node = null;

        //    HtmlNode bet = betList[0];
        //    match.Line.Home = GetBetCoef(bet, BetType.Home);
        //    match.Line.Draw = GetBetCoef(bet, BetType.Draw);
        //    match.Line.Away = GetBetCoef(bet, BetType.Away);

        //    bet = betList[1];
        //    match.Line.HomeOrDraw = GetBetCoef(bet, BetType.HomeOrDraw);
        //    match.Line.NotDraw = GetBetCoef(bet, BetType.NotDraw);
        //    match.Line.AwayOrDraw = GetBetCoef(bet, BetType.AwayOrDraw);

        //    bet = betList[2];
        //    match.Line.TotalMore = GetBetCoef(bet, BetType.TotalMore);
        //    match.Line.TotalLess = GetBetCoef(bet, BetType.TotalLess);

        //    coef_node = HapHelper.GetChildNodeByAttribute(bet, "class", "num");
        //    coef_value = coef_node == null ? "0,0" : coef_node.InnerText.Trim()/*Replace(" ", string.Empty)*/.Replace(",", ".").Substring(1);
        //    match.Line.Total = coef_value;//Convert.ToDouble(coef_value);

        //    bet = betList[3];
        //    match.Line.HandicapHome = GetBetCoef(bet, BetType.HandicapHome);
        //    match.Line.HandicapAway = GetBetCoef(bet, BetType.HandicapAway);

        //    coef_node = HapHelper.GetChildNodeByAttribute(bet, "class", "num");
        //    coef_value = coef_node == null ? "none" : coef_node.InnerText.Replace(",", ".");/*.Replace(" ", string.Empty).Replace(".", ",").Substring(1)*/;
        //    match.Line.HandicapValue = coef_value;

        //    bet = betList[4];
        //    match.Line.ITHomeLess = GetBetCoef(bet, BetType.ITHomeLess);
        //    match.Line.ITHomeMore = GetBetCoef(bet, BetType.ITHomeMore);

        //    coef_node = HapHelper.GetChildNodeByAttribute(bet, "class", "num");
        //    coef_value = coef_node == null ? "0,0" : coef_node.InnerText.Replace(" ", string.Empty).Replace(",", ".")/*.Replace(".", ",")*/.Substring(1);
        //    match.Line.ITHomeValue = Convert.ToDouble(coef_value);

        //    bet = betList[5];
        //    match.Line.ITAwayLess = GetBetCoef(bet, BetType.ITAwayLess);
        //    match.Line.ITAwayMore = GetBetCoef(bet, BetType.ITAwayMore);

        //    coef_node = HapHelper.GetChildNodeByAttribute(bet, "class", "num");
        //    coef_value = coef_node == null ? "0,0" : coef_node.InnerText.Replace(" ", string.Empty).Replace(",", ".")/*.Replace(".", ",")*/.Substring(1);
        //    match.Line.ITHomeValue = Convert.ToDouble(coef_value);
        //}

        //private static double GetBetCoef(HtmlNode bet, BetType type)
        //{
        //    int t = (int)type;
        //    HtmlNode node = HapHelper.GetChildNodeByAttribute(bet, "a", "data-type", t.ToString());
        //    string coef = (node != null) ?
        //                    node.InnerText
        //                    .Replace(" ", string.Empty)
        //                    .Replace(",", ".")
        //                    .Substring(1)
        //                    : "0.0";

        //    return Convert.ToDouble(coef);
        //}


        //private static void FillMainInfo(HtmlNode node, SoccerMatch match)
        //{
        //    var a = HapHelper.GetChildNodeByAttribute(node, "a", "class", "c-events__name");
        //    var teams = HapHelper.GetAllChildNodeByAttribute(a, "class", "c-events__team");

        //    match.HomeTeamTitle = teams[1].InnerText;
        //    match.GuestTeamTitle = teams[2].InnerText;

        //    var time_div = HapHelper.GetChildNodeByAttribute(node, "class", "c-events__time min");
        //    match.Time = time_div.InnerText;

        //    match.IsInProgres = false;
        //    match.Score = " - ";
        //    match.Date = DateTime.UtcNow;
        //}

    }
}