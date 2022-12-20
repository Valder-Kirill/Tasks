using Newtonsoft.Json;

namespace TaskSix.Models.LikedUsers
{
    public class LikedUsers
    {
        [JsonProperty("response")]
        public LikerUsersInfo LikerUsersInfo { get; set; }
    }
}
