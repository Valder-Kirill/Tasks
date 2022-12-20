using RestSharp;

namespace TaskSix.API
{
    public static class APIUtils
    {
        public static IRestResponse SendGetRequest(string req, string parameters)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(req + parameters, Method.GET);
            return client.Execute(request);
        }

        public static IRestResponse SendPostRequest(string upload_url, string pic_path)
        {
            RestClient client = new RestClient(upload_url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file1", pic_path);
            request.AddHeader("Content-Type", "multipart/form-data"); 
            return client.Execute(request);
        }
    }
}
