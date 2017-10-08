using Match.ParsingCode;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Match_BLL
{
    [JsonObject]
    public class Line
    {
        [JsonProperty("CI")]
        public string Id { get; set; }

        [JsonProperty("COI")]
        public int COI { get; set; }

        [JsonProperty("L")]
        public string LeagueTitle { get; set; }

        [JsonProperty("TSt")]
        public string LeagueAdditionalInfo { get; set; }

        [JsonProperty("O1")]
        public string HomeTeam { get; set; }

        [JsonProperty("O2")]
        public string AwayTeam { get; set; }

        [JsonProperty("SN")]
        public string Sport { get; set; }

        [JsonProperty("SI")]
        public SportType SportType { get; set; }

        [JsonProperty("E")]
        public List<Cof> Coefs { get; set; }

        
        /*In English*/
        [JsonProperty("LE")]
        public string LeagueTitleEnglish { get; set; }

        [JsonProperty("SE")]
        public string SportEnglish { get; set; }

        [JsonProperty("O1E")]
        public string HomeTeamEnglish { get; set; }

        [JsonProperty("O2E")]
        public string AwayTeamEnglish { get; set; }


        public Cof GetCof(BetType type)
        {
            return Coefs.Where(c => c.Type == type).FirstOrDefault();
        }
    }
}
