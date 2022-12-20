using System;
using System.Xml;

namespace TaskSix.DataUtils
{
    public static class GetTestData
    {
        private const string fileName = @"/Resources/TestData.xml";

        public static string Get(string itemName, string nodeName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Environment.CurrentDirectory + fileName);
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
    }
}