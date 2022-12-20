using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskSix.Models.SavedImageModel
{
    public class SavedImageResponse
    {
        [JsonProperty("response")]
        public List<ImageInfo> ImageInfo { get; set; }
    }
}
