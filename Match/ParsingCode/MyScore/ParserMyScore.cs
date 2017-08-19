using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using Match.Models;

namespace Match.ParsingCode
{
    public static class ParserMyScore
    {
        public static IEnumerable<SoccerMatch> MainPage()
        {
            List<SoccerMatch> matches = new List<SoccerMatch>();
            var web = new HtmlWeb();
            string url = "http://football.ua/scoreboard/";  //"http://www.myscore.com.ua/#";
            //http://football.ua/default.aspx?menu_id=scoreboard&dt=2017-08-06


            HtmlDocument html = web.Load( url );

            var leagues = html.DocumentNode.Descendants("table")
               .Select(y => y.Descendants()
               .Where(x => x.Attributes["class"].Value.Contains( "soccer" )))
               .ToList();

            foreach ( HtmlNode node in leagues )
            {
                HtmlNode countryInfoNode = node.ChildNodes.Where(x => x.Attributes["class"].Value.Contains("country left")).FirstOrDefault();
                string countryName = countryInfoNode.Descendants().Where( x => x.Attributes["class"].Value == "country_part").First().FirstChild.InnerText;
                string tournamentName = countryInfoNode.Descendants().Where(x => x.Attributes["class"].Value == "tournament_part").First().FirstChild.InnerText;

                var allMatchesInTour = node.Descendants("tr").Where( n => n.Attributes["class"].Value.Contains("stage-scheduled"));

                foreach ( HtmlNode match in allMatchesInTour )
                {
                    string homeTeam = match.ChildNodes.Where( n => n.Attributes["class"].Value.Contains("team-home") ).First().FirstChild.InnerText;
                    string awayTeam = match.ChildNodes.Where(n => n.Attributes["class"].Value.Contains("team-away")).First().FirstChild.InnerText;

                    string time = match.ChildNodes.Where(n => n.Attributes["class"].Value.Contains("cell_ad time")).First().InnerText;

                    matches.Add(new SoccerMatch()
                    {
                        Date = DateTime.Parse(time),
                        Tournament = countryName + tournamentName,
                        HomeTeamTitle = homeTeam,
                        GuestTeamTitle = awayTeam
                    }
                        );
                }
            }


            return matches;
        }
    }
}