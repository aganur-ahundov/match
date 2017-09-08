using Match_BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Match.ParsingCode
{
    public static class XBetParser
    {
        static string jsonGamesUrl = "https://1xdoc.xyz/LineFeed/Get1x2_Zip?count=50&lng=ru&tf=1000000&tz=3&mode=4&country=2";

        public static IEnumerable<Line> GetFootballGames()
        {
            JsonRoot root = null;
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                var jsonGames = wc.DownloadString(jsonGamesUrl);
                root = JsonConvert.DeserializeObject<JsonRoot>(jsonGames);
            }

            return root.Lines.Where(l => l.SportType == SportType.Football);
        }
    }
}