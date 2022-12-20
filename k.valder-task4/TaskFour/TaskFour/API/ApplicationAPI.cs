using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace TaskTwo.API
{
    public static class ApplicationAPI
    {
        public static List<Post> GetListAllPosts(string strRec)
        {
            RestResponse response = APIUtils.SendGetRequest(strRec);
            return JsonConvert.DeserializeObject<List<Post>>(response.Content);
        }

        public static Post GetPost(string strRec)
        {
            RestResponse response = APIUtils.SendGetRequest(strRec);
            return JsonConvert.DeserializeObject<Post>(response.Content);
        }

        public static string GetContentType(string strRec)
        {
            RestResponse response = APIUtils.SendGetRequest(strRec);
            return response.ContentType;
        }

        public static string SendPost(string strRec, Post post)
        {
            
            string str = JsonConvert.SerializeObject(post);
            RestResponse response = APIUtils.SendPostRequest(strRec, str);
            return JsonConvert.DeserializeObject<Post>(response.Content).Id.ToString();
        }

        public static List<User> GetUsers(string strRec)
        {
            RestResponse response = APIUtils.SendGetRequest(strRec);
            return JsonConvert.DeserializeObject<List<User>>(response.Content);
        }

        public static User GetUser(string strRec)
        {
            RestResponse response = APIUtils.SendGetRequest(strRec);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }
    }
}
