using Newtonsoft.Json;
using System;

namespace TaskSix.Models.UploadServer
{
    public class UploadServerData
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public Uri UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}
