using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Match_BLL
{
    [JsonObject]
    public class RootObject
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("Id")]
        public  int Id { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }
        
        [JsonProperty("Value")]
        public List<JsonLine> Lines { get; set; }
    }

    [JsonObject]
    public class JsonLine
    {
        [JsonProperty("CI")]
        public string Id { get; set; }

        [JsonProperty("COI")]
        public int COI { get; set; }

        [JsonProperty("L")]
        public string LeagueTitle { get; set; }

        [JsonProperty("LE")]
        public string LeagueTitleEnglish { get; set; }

        [JsonProperty("TSt")]
        public string LeagueAdditionalInfo { get; set; }

        [JsonProperty("O1")]
        public string Country { get; set; }

        [JsonProperty("O1E")]
        public string CountryEnglish { get; set; }

        [JsonProperty("O2")]
        public string City { get; set; }

        [JsonProperty("O2E")]
        public string CityEnglish { get; set; }

        [JsonProperty("SN")]
        public string Sport { get; set; }

        [JsonProperty("SE")]
        public string SportEnglish { get; set; }

        [JsonProperty("SI")]
        public int SportId { get; set; }

        [JsonProperty("E")]
        public List<JsonCoef> Coefs { get; set; }
    }

    [JsonObject]
    public class JsonCoef
    {
        [JsonProperty("C")]
        public double Coef { get; set; }

        [JsonProperty("G")]
        public int Group { get; set; }

        [JsonProperty("T")]
        public int Type { get; set; }

        [JsonProperty("P")]
        public double Points { get; set; }
    }
}
