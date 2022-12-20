using Newtonsoft.Json;

namespace TaskSix.Models.GetPhotoModel
{
    public class GetPhoto
    {
        [JsonProperty("response")]
        public GetPhotoResponse GetPhotoResponse { get; set; }
    }
}
