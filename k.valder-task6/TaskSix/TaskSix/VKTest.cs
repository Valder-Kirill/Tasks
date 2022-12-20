using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TaskSix.DataUtils;
using TaskSix.PageObjects;
using TaskSix.API;
using TaskSix.Models;
using TaskOne.Utils;
using TaskSix.Models.LikedUsers;
using System;
using XnaFan.ImageComparison;
using TaskSix.Utils;

namespace TaskSix
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var browser = AqualityServices.Browser;

            browser.Maximize();
            browser.GoTo(GetTestData.Get("BrowserData", "Url"));
        }

        [Test]
        public void VkPostTest()
        {
            LoginVkPageObject loginVkPO = new LoginVkPageObject();
            MenuVkPageObject menuVkPO = new MenuVkPageObject();
            UserPageObject userPO = new UserPageObject();

            string postText = RandomUtil.RndString();
            string newPostText = RandomUtil.RndString();
            loginVkPO.SetLogin(GetTestData.Get("UserData", "Login"));
            loginVkPO.SetPass(GetTestData.Get("UserData", "Pass"));
            DeleteLoginAndPass.Del();
            loginVkPO.ClickLoginBtn();
            menuVkPO.ClickOnMyPage();
            string img = VkApiUtils.UploadOnePic(GetTestData.Get("UserData", "AlbumId"),GetTestData.Get("PostData", "Pic"),
                GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            Post response = VkApiUtils.CreatePost(postText, GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            long userId = response.Response.ID;
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => postText == userPO.GetPostText()), "Text is different");
            Assert.AreEqual(GetTestData.Get("UserData", "ID"), userPO.GetAuthorId(), "User is different");
            VkApiUtils.EditPost(userId, newPostText, img,
                GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => newPostText == userPO.GetPostText()), "Text is different");
            string imgId = img.Substring(img.IndexOf('_') + 1);
            string photoUrl = VkApiUtils.GetPhotos(imgId, GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            DownloadForUrl.Download(photoUrl, GetTestData.Get("PostData", "PhotoName"));
            Assert.IsTrue(Convert.ToDouble(GetTestData.Get("PostData", "Fault")) > ImageTool.GetPercentageDifference(AppDomain.CurrentDomain.BaseDirectory + "test.jpg", GetTestData.Get("PostData", "Pic")), "Photo is different");
            VkApiUtils.CreateComment(userId, postText, GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            userPO.ClickShowBtn();
            Assert.AreEqual(GetTestData.Get("UserData", "ID"), userPO.GetCommentAuthor(), "User ID is different");
            userPO.ClickLike();
            LikedUsers likedUsers = VkApiUtils.GetLikes(GetTestData.Get("PostData", "TypeElement"), Convert.ToString(userId), GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            Assert.AreEqual(GetTestData.Get("UserData", "ID"), Convert.ToString(likedUsers.LikerUsersInfo.Items[Convert.ToInt32(GetTestData.Get("PostData", "PicNum"))]), "User is different");
            VkApiUtils.DeletePost(userId, GetTestData.Get("UserData", "Token"), GetTestData.Get("PostData", "V"));
            Assert.IsTrue(userPO.LastPostIsNotDispleyed(Convert.ToInt64(GetTestData.Get("UserData", "ID")), userId), "Post is not deleted");
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}