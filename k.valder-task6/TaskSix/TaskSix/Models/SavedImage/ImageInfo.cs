using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskSix.Models.SavedImageModel
{
    public class ImageInfo
    {
        [JsonProperty("album_id")]
        public int Album_id { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner_id")]
        public int Owner_id { get; set; }

        [JsonProperty("has_tags")]
        public bool Has_tags { get; set; }

        [JsonProperty("sizes")]
        public List<Size> Sizes { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
