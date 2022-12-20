using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskSix.PageObjects
{
    public class UserPageObject : Form
    {
        private static ILabel postAuthorName = ElementFactory.GetLabel(By.XPath("//a[contains(@class,'PostHeaderImgContainer')]"), "Post author name");
        private static ILabel post = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'post_content')]//div[contains(@class,'wall_post_text')]"), "Post");
        private static ILabel photo = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'post_content')]//a[contains(@class,'image_cover')]"), "Photo in post");
        private static IButton showComments = ElementFactory.GetButton(By.XPath("//div[contains(@class,'replies_list')]//a[contains(@class,'replies_next')]"), "Show comments button");
        private static ILabel commentAuthorName = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'reply')]//a[contains(@class,'reply_image')]"), "Comment author name");
        private static IButton likeBtn = ElementFactory.GetButton(By.XPath("//span[contains(@class,'_like_button_icon')]"), "Like button");
        private static ILabel lastPost(long userID,long postID) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{userID}_{postID}']"), "Last post");

        public UserPageObject() : base(By.XPath("//a[contains(@data-from-id,'677813764')]"), "Profile block")
        {

        }

        public string GetAuthorId()
        {
            return postAuthorName.GetAttribute("href").Substring(17);
        }

        public string GetPostText()
        {
            return post.GetText();
        }

        public string GetPhotoID()
        {
            return photo.GetAttribute("data-photo-id");
        }
        
        public void ClickShowBtn()
        {
            showComments.Click();
        }

        public string GetCommentAuthor()
        {
            return commentAuthorName.GetAttribute("href").Substring(17);
        }

        public void ClickLike()
        {
            likeBtn.Click();
        }

        public bool LastPostIsNotDispleyed(long userID, long postID)
        {
            return lastPost(userID, postID).State.WaitForNotDisplayed();
        }
    }
}
