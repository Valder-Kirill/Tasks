using RestSharp;
using TaskFour.Utils;

namespace TaskTwo
{
    public static class APIUtils
    {
        public static RestResponse SendGetRequest(string strRec)
        {
            RestClient client = new RestClient(GetDataUtil.Get(@"generalData", "url"));
            RestRequest request = new RestRequest(strRec, Method.Get);
            return client.Execute(request);
        }
        
        public static RestResponse SendPostRequest(string strRec, string post)
        {
            RestClient client = new RestClient(GetDataUtil.Get(@"generalData", "url"));
            RestRequest request = new RestRequest(strRec, Method.Post/*, DataFormat.Json)*/);
            request.AddJsonBody(post);
            return client.Execute(request);
        }
    }
}
