using Newtonsoft.Json;

namespace TaskSix.Models.SavedImageModel
{
    public class Size
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
