using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaskSix.Models.LikedUsers
{
    public class LikerUsersInfo
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public List<long> Items { get; set; }
    }
}
