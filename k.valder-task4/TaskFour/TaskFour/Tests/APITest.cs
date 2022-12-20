using NUnit.Framework;
using TaskTwo.Utils;
using TaskTwo.API;
using System.Collections.Generic;
using TaskFour.Utils;
using System;
using Aquality.Selenium.Browsers;
using System.Diagnostics;
using TaskFour.DBTabelsUtils;
using MySqlConnector;
using TaskFour.UnionReportingDBUtils;

namespace TaskTwo
{
    public class Tests
    {
        private int status = 0;
        private string startTime;
        private string methodName;
        

        [Test]
        public void ApiTest()
        {
            startTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            
            methodName = new StackTrace(false).GetFrame(0).GetMethod().Name;

            Assert.AreEqual(GetDataUtil.Get(@"requests", "postType"), ApplicationAPI.GetContentType(GetDataUtil.Get(@"requests", "posts").ToString()), "The list was not formatted correctly.");
            Assert.IsTrue(ASCCheckUtil.ASCCheck(ApplicationAPI.GetListAllPosts(GetDataUtil.Get(@"requests", "posts"))), "The list was sorted incorrectly.");

            Post post = ApplicationAPI.GetPost(GetDataUtil.Get(@"requests", "post99"));
            Assert.AreEqual(GetDataUtil.Get(@"postsData", "post99UserID"), post.UserId.ToString(), "Invalid user ID.");
            Assert.AreEqual(GetDataUtil.Get(@"postsData", "post99ID"), post.Id.ToString(), "Invalid ID.");

            string post150Body = GetDataUtil.Get(@"postsData", "post150Body");
            if (string.IsNullOrEmpty(post150Body)) post150Body = null;
            Assert.AreEqual(post150Body, ApplicationAPI.GetPost(GetDataUtil.Get(@"requests", "post150")).Body, "Body is not null.");

            post = new Post();
            post.UserId = Convert.ToInt64(GetDataUtil.Get(@"sendPostData", "userId").ToString());
            if (string.IsNullOrEmpty(GetDataUtil.Get(@"sendPostData", "body"))) post.Body = "";
            else post.Body = GetDataUtil.Get(@"sendPostData", "userId");
            if (string.IsNullOrEmpty(GetDataUtil.Get(@"sendPostData", "title"))) post.Title = "";
            else post.Title = GetDataUtil.Get(@"sendPostData", "userId");
            Assert.AreEqual(GetDataUtil.Get(@"postsData", "postsRet101"), ApplicationAPI.SendPost(GetDataUtil.Get(@"requests", "posts"), post), "Invalid value returned.");

            List<User> listUsers = ApplicationAPI.GetUsers(GetDataUtil.Get(@"requests", "users"));
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "name"), listUsers[4].Name.ToString(), "Invalid name.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "username"), listUsers[4].Username.ToString(), "Invalid username.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "email"), listUsers[4].Email.ToString(), "Invalid email.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "street"), listUsers[4].Address.Street.ToString(), "Invalid street.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "suite"), listUsers[4].Address.Suite.ToString(), "Invalid suite.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "city"), listUsers[4].Address.City.ToString(), "Invalid city.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "zipcode"), listUsers[4].Address.Zipcode.ToString(), "Invalid zipcode.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "geoLat"), listUsers[4].Address.Geo.Lat.ToString(), "Invalid geo lat.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "geoLng"), listUsers[4].Address.Geo.Lng.ToString(), "Invalid geo lng.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "phone"), listUsers[4].Phone.ToString(), "Invalid phone.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "website"), listUsers[4].Website.ToString(), "Invalid website.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "companyName"), listUsers[4].Company.Name.ToString(), "Invalid company name.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "companyCatchPhrase"), listUsers[4].Company.CatchPhrase.ToString(), "Invalid company catchPhrase.");
            Assert.AreEqual(GetDataUtil.Get(@"user4Data", "companyBs"), listUsers[4].Company.Bs.ToString(), "Invalid company bs.");

            User user = ApplicationAPI.GetUser(GetDataUtil.Get(@"requests", "user5"));
            Assert.AreEqual(user.Name.ToString(), listUsers[4].Name.ToString(), "The users are different.");
            status = Convert.ToInt32(GetDataUtil.Get(@"StatusValue", "Passed"));
        }

        [TearDown]
        public void TearDown()
        {
            //TC-1

            MySqlConnection conn = DBServerUtil.GetDBConnection(GetDataUtil.Get(@"DBData", "Server"),
                GetDataUtil.Get(@"DBData", "TestTable"), GetDataUtil.Get(@"DBData", "User"), GetDataUtil.Get(@"DBData", "Password"));

            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string env = Environment.UserName;
            string browser = "";// AqualityServices.Browser.BrowserName.ToString();

            long projectId;
            if (ProjectTableUtils.GetID(conn, GetDataUtil.Get(@"ProjectInfo", "Name")) != "")
            {
                projectId = Convert.ToInt64(ProjectTableUtils.GetID(conn, GetDataUtil.Get(@"ProjectInfo", "Name")));
            }
            else
            {
                ProjectTableUtils.Insert(conn, GetDataUtil.Get(@"ProjectInfo", "Name"));
                projectId = Convert.ToInt64(ProjectTableUtils.GetID(conn, GetDataUtil.Get(@"ProjectInfo", "Name")));
            }

            SessionTabelUtils.Insert(conn, startTime, startTime, Convert.ToInt64(GetDataUtil.Get(@"ProjectInfo", "BuildNumber")));
            long sessionId = Convert.ToInt64(SessionTabelUtils.GetID(conn, $"{startTime}"));

            if (status == 0)
            {
                status = Convert.ToInt32(GetDataUtil.Get(@"StatusValue", "Failed"));
            }

            long userID;
            if (AuthorTableUtils.GetID(conn, GetDataUtil.Get(@"AuthorData", "NameAuthor")) != "")
            {
                userID = Convert.ToInt64(AuthorTableUtils.GetID(conn, GetDataUtil.Get(@"AuthorData", "NameAuthor")));
            }
            else
            {
                AuthorTableUtils.Insert(conn, GetDataUtil.Get(@"AuthorData", "NameAuthor"), GetDataUtil.Get(@"AuthorData", "Login"),
                    GetDataUtil.Get(@"AuthorData", "Email"));
                userID = Convert.ToInt64(AuthorTableUtils.GetID(conn, GetDataUtil.Get(@"AuthorData", "NameAuthor")));
            }

            TestTableUtils.Insert(conn, GetDataUtil.Get(@"ProjectInfo", "Name"), status, methodName, projectId, sessionId, startTime, endTime, env, browser, userID);

            //TC-2

            string[] CompID = ComparisonOfNumbersUtil.Get(TestTableUtils.GetAllID(conn));
            
            for (int i = 0; i < CompID.Length; i++)
            {
                string[] row = TestTableUtils.GetDataIfID(conn, CompID[i]);
                row[1] = "1";
                Random rnd = new Random();
                TestTableUtils.Insert(conn, GetDataUtil.Get(@"ProjectInfo", "Name"), rnd.Next(1,4), row[2], Convert.ToInt64(projectId), 
                    Convert.ToInt64(row[4]), Convert.ToDateTime(row[5]).ToString("yyyy-MM-dd HH-mm-ss"), Convert.ToDateTime(row[5]).ToString("yyyy-MM-dd HH-mm-ss"), row[7], row[8], userID);
            }

            for (int i = 0; i < CompID.Length; i++)
            {
                string[] row = TestTableUtils.GetDataIfID(conn, CompID[i]);
                row[1] = "1";
                TestTableUtils.Delete(conn, GetDataUtil.Get(@"ProjectInfo", "Name"), row[2], Convert.ToInt64(projectId),
                    Convert.ToInt64(row[4]), Convert.ToDateTime(row[5]).ToString("yyyy-MM-dd HH-mm-ss"), Convert.ToDateTime(row[5]).ToString("yyyy-MM-dd HH-mm-ss"), row[7], row[8], userID);
            }

            AqualityServices.Browser.Quit();
        }
    }
}