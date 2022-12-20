using System;
using System.Xml;
using TheInternetTests.Logs;

namespace TheInternetTests.Utils
{
    public static class GetTestData
    {
        public static string Get(string itemName, string nodeName)
        {
            try
            {
                Logger.Info("Get test data");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Environment.CurrentDirectory + @"/TestData.xml");
                XmlElement xmlElement = xmlDocument.DocumentElement;
                foreach (XmlNode xmlNode in xmlElement)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        XmlNode attr = xmlNode.Attributes.GetNamedItem(itemName);
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == nodeName)
                                return childNode.InnerText;
                        }
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                Logger.Error("Test data not found", e);
                return "";
            }
        }
    }
}
