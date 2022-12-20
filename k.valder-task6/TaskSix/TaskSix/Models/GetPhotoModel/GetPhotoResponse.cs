using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskSix.Models.GetPhotoModel
{
    public class GetPhotoResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public List<GetPhotoItem> GetPhotoItem { get; set; }
    }
}
