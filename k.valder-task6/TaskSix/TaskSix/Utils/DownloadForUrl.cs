using System;
using System.Net;


namespace TaskSix.Utils
{
    public static class DownloadForUrl
    {
        public static void Download(string photoUrl, string filename)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(photoUrl, AppDomain.CurrentDomain.BaseDirectory + filename);
            }
        }
    }
}
