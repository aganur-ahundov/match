using Match_BLL;
using Match_BLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Hosting;

namespace Match.ParsingCode
{
    public static class XBetParser
    {
        static string jsonGamesUrl = "https://1xdoc.xyz/LineFeed/Get1x2_Zip?count=50&lng=ru&tf=1000000&tz=3&mode=4&country=2";

        public static IEnumerable<FilterResultLine> GetFootballGames()
        {
            JsonRoot root = null;
            var path = HostingEnvironment.ApplicationPhysicalPath + "MatchesXML\\" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".json";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    var jsonGames = wc.DownloadString(jsonGamesUrl);
                    File.WriteAllText(path, jsonGames);
                    root = JsonConvert.DeserializeObject<JsonRoot>(jsonGames);
                }
            }
            else
            {
                var jsonGames = File.ReadAllText(path, Encoding.UTF8);
                root = JsonConvert.DeserializeObject<JsonRoot>(jsonGames);
            }

            return root.Lines.Where(l => l.SportType == SportType.Football)
                .Select(l => new FilterResultLine(new List<BetType>(), l))
                .ToList();
        }
    }
}