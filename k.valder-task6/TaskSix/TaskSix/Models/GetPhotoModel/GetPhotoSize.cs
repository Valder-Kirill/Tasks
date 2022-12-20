using Newtonsoft.Json;
using System;

namespace TaskSix.Models.GetPhotoModel
{
    public class GetPhotoSize
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}
