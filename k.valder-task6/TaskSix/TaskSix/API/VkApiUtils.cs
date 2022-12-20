using Newtonsoft.Json;
using RestSharp;
using TaskSix.Models;
using TaskSix.DataUtils;
using TaskSix.Models.UploadServer;
using TaskSix.Models.UploadImg;
using TaskSix.Models.SavedImageModel;
using TaskSix.Models.LikedUsers;
using TaskSix.Models.GetPhotoModel;
using System;

namespace TaskSix.API
{
    public static class VkApiUtils
    {
        public static Post CreatePost(string text, string accessToken, string v)
        {
            IRestResponse response = APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlWallPost"),
                $"message={text}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
            return JsonConvert.DeserializeObject<Post>(response.Content);
        }

        public static void EditPost(long id, string newtext, string photoId, string accessToken, string v)
        {
            APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlWallEdit"),
                $"post_id={id}&" +
                $"message={newtext}&" +
                $"attachments=photo{photoId}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
        }

        public static void CreateComment(long id, string text, string accessToken, string v)
        {
            APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlWallCreateComment"),
                $"post_id={id}&" +
                $"message={text}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
        }

        public static string UploadOnePic(string albumId,string imgPath, string accessToken, string v)
        {
            IRestResponse response = APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlPhotosGetUploadServer"),
                $"album_id={albumId}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
            UploadServer uploadServer = JsonConvert.DeserializeObject<UploadServer>(response.Content);
            response = APIUtils.SendPostRequest(uploadServer.UploadServerData.UploadUrl.ToString(),
                imgPath);
            InfoModel infoModel = JsonConvert.DeserializeObject<InfoModel>(response.Content);
            response = APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlPhotosSave"),
                $"album_id={albumId}&" +
                $"server={infoModel.Server}&"+
                $"photos_list={infoModel.PhotosList}&" +
                $"hash={infoModel.Hash}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
            SavedImageResponse savedImageResponse = JsonConvert.DeserializeObject<SavedImageResponse>(response.Content);
            return savedImageResponse.ImageInfo[Convert.ToInt32(GetTestData.Get("PostData", "PicNum"))].Owner_id + "_" + savedImageResponse.ImageInfo[Convert.ToInt32(GetTestData.Get("PostData", "PicNum"))].Id;
        }

        public static void DeletePost(long id, string accessToken, string v)
        {
            APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlWallDelete"),
                $"post_id={id}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
        }

        public static LikedUsers GetLikes(string type, string itemId, string accessToken, string v)
        {
            IRestResponse response = APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlGetLikes"),
                $"type={type}&" +
                $"item_id={itemId}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
            return JsonConvert.DeserializeObject<LikedUsers>(response.Content);
        }

        public static string GetPhotos(string photoId, string accessToken, string v)
        {
            IRestResponse response = APIUtils.SendGetRequest(GetTestData.Get("BrowserData", "UrlVkApiMethod") + GetTestData.Get("BrowserData", "UrlGetPhotos"),
                $"album_id=wall&" +
                $"photo_id={photoId}&" +
                $"access_token={accessToken}&" +
                $"v={v}");
            GetPhoto getPhoto = JsonConvert.DeserializeObject<GetPhoto>(response.Content);
            return getPhoto.GetPhotoResponse.GetPhotoItem[0].GetPhotoSize[0].Url.ToString();
        }
    }
}
