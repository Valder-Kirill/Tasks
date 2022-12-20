using Newtonsoft.Json;

namespace TaskSix.Models
{
    public class Post
    {
        [JsonProperty("response")]
        public PostID Response { get; set; }
    }
}
