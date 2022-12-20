using System;
using System.Xml;
using TheInternetTests.Logs;

namespace TheInternetTests.Utils
{
    public static class GetConfig
    {
        public static string Get(string nodeName)
        {
            try
            {
                Logger.Info("Get config data");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Environment.CurrentDirectory + @"/ConfigFile.xml");
                XmlElement xmlElement = xmlDocument.DocumentElement;
                foreach (XmlNode xmlNode in xmlElement)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        XmlNode attr = xmlNode.Attributes.GetNamedItem("settings");
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == nodeName)
                                return childNode.InnerText;
                        }
                    }
                }
                return "";
            }
            catch(Exception e)
            {
                Logger.Error("Config data not found",e);
                return "";
            }
        }
    }
}
