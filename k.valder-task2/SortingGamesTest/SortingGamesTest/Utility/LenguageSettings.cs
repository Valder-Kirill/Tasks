using System.Xml;

namespace SortingGamesTest.Utility
{
    class LenguageSettings
    {
        private string rezult;
        public string CheckLenguage(string nodeName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"../../../Config/TextConfig.xml");
            XmlElement xmlElement = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlElement)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    XmlNode attr = xmlNode.Attributes.GetNamedItem("settings");
                    foreach(XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if(childNode.Name == nodeName)
                            rezult = childNode.InnerText;
                    }
                }
            }
            return rezult;
        }
    }
}
