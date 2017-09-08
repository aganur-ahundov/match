using Newtonsoft.Json;

namespace Match_BLL
{
    [JsonObject]
    public class Cof
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
