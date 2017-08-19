using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using Match.Models;

namespace Match.ParsingCode
{
    public static class ParserFootballua
    {
        public static IEnumerable<SoccerMatch> MainPage()
        {
            List<SoccerMatch> matches = new List<SoccerMatch>();
            var web = new HtmlWeb();
            string url = "http://football.ua/scoreboard/";  //"http://www.myscore.com.ua/#";
            //http://football.ua/default.aspx?menu_id=scoreboard&dt=2017-08-06

            //HtmlWeb webClient = new HtmlWeb();
            //webClient.DownloadFile("http://greenqubes.ru/hack/sandbox/sandbox.jar", @"C:\test\sandbox.jar");

            HtmlDocument html = web.Load(url);

            string testing = html.DocumentNode.InnerHtml;
            bool testbool = testing.Contains("table-block");


            var divs = html.DocumentNode.Descendants("article").Where(n => n.Attributes["class"].Value == "match-center").First();
            var devs1 = divs   .ChildNodes.Descendants("div").ToList().Where( n => n.Attributes["class"].Value == "match-name").ToList().First().ParentNode;

            //var leagues = html.DocumentNode.Descendants("div")
            //    .Select(y => y.Descendants()
            //   .Where(n => n.Attributes["class"].Value.Contains("table-block")))
            //   .First();

            var leagues = devs1;

            string currentTournament = string.Empty;
            foreach ( HtmlNode node in leagues.Descendants( "div" ) )//ChildNodes )
            {
                if ( node.Attributes["class"].Value == "match-name" )
                {
                    currentTournament = node.Descendants("h4").First().InnerText;
                }
                else if ( node.Attributes["class"].Value == "match" )
                {
                    SoccerMatch newMatch = new SoccerMatch();

                    // --IT's WRONG WAY
                    //var node_time = node.ChildNodes.Where(n => n.HasAttributes && n.Attributes["class"].Value == "time").FirstOrDefault();


                    //var td = node.Descendants("td").Where(n => n.Attributes["class"].Value == "time");
                    //var tdFirst = td.First().Descendants("a").First();
                    //var tdFirstChild = tdFirst.FirstChild;
                    newMatch.Time = GetSingleChildNodeByClass( node, "td", "time" )
                        .Descendants( "a" )
                        .First()
                        .FirstChild.InnerHtml;

                    newMatch.HomeTeamTitle = node.Descendants("td").Where(n => n.Attributes["class"].Value == "left-team" ).First().Descendants("a").First().InnerText;
                    newMatch.GuestTeamTitle = node.Descendants("td").Where(n => n.Attributes["class"].Value == "right-team" ).First().Descendants("a").First().InnerText;
                    newMatch.Score = node.Descendants( "td" ).Where( n => n.Attributes["class"].Value.Contains("score")).First().Descendants("a").First().InnerText;
                    newMatch.IsInProgres = node.Descendants("td").Where(n => n.Attributes["class"].Value.Contains("score")).First().Attributes["class"].Value.Contains("inprogress");

                    newMatch.Tournament = currentTournament;
                    newMatch.Date = DateTime.UtcNow.Date;

                    matches.Add(newMatch);
                }

            }


            return matches;
        }

        private static HtmlNode GetSingleChildNodeByClass(HtmlNode parent, string element, string elClass)
        {
            return parent.Descendants(element)
                .Where(n => n.Attributes["class"].Value == elClass)
                .First();
        }


    }
    
    
}
