using Newtonsoft.Json;
using System.Collections.Generic;

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
        public List<Cof> Coefs { get; set; }
    }
}
