using Newtonsoft.Json;

namespace TaskSix.Models
{
    public class PostID
    {
        [JsonProperty("post_id")]
        public long ID { get; set; }
    }
}
