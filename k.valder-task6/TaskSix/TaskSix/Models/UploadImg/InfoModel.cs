using Newtonsoft.Json;

namespace TaskSix.Models.UploadImg
{
    public class InfoModel
    {
        [JsonProperty("server")]
        public long Server { get; set; }

        [JsonProperty("photos_list")]
        public string PhotosList { get; set; }

        [JsonProperty("aid")]
        public long Aid { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
