using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace TaskSix.DataUtils
{
    public static class DeleteLoginAndPass
    {
        private const string fileName = @"/Resources/TestData.xml";

        public static void Del()
        {
            var xDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory + fileName));
            xDoc.Elements("data").Elements("UserData").FirstOrDefault().SetElementValue("Login", "");
            xDoc.Elements("data").Elements("UserData").FirstOrDefault().SetElementValue("Pass", "");
            xDoc.Save(Environment.CurrentDirectory + fileName);
        }
    }
}
