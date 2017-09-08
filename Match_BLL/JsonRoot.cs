using Newtonsoft.Json;
using System.Collections.Generic;

namespace Match_BLL
{
    [JsonObject]
    public class JsonRoot
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("Value")]
        public List<Line> Lines { get; set; }
    }
}
