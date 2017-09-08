using Match.ParsingCode;
using Newtonsoft.Json;

namespace Match_BLL
{
    [JsonObject]
    public class Cof
    {
        [JsonProperty("C")]
        public double Value { get; set; }

        [JsonProperty("G")]
        public int Group { get; set; }

        [JsonProperty("T")]
        public BetType Type { get; set; }
        
        [JsonProperty("P")]
        public double AdditionalPoints { get; set; }
        //Handicap value, total goals value
    }
}
