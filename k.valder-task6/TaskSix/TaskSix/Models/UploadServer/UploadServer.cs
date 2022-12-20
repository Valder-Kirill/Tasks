using Newtonsoft.Json;

namespace TaskSix.Models.UploadServer
{
    public class UploadServer
    {
        [JsonProperty("response")]
        public UploadServerData UploadServerData { get; set; }
    }
}
