using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskSix.Models.GetPhotoModel
{
    public class GetPhotoItem
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("has_tags")]
        public bool HasTags { get; set; }

        [JsonProperty("sizes")]
        public List<GetPhotoSize> GetPhotoSize { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
