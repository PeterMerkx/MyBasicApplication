using System;
using System.IO;
using System.Xml;
using MyBasicApplication.Library;

namespace MyBasicApplication.Converters
{
    public class INIFile
    {
        private static string mysetting;
        private static string iniDirectory;
        public static int i;
        public static string ReadValue(string applanguage, string sectie, string key)
        {
            try
            {
                iniDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MyBasicApplication";
                string FILENAME = iniDirectory + "\\" + applanguage + ".xml";
                var doc = new XmlDocument();
                doc.Load(FILENAME);
                var items = doc.GetElementsByTagName("root");
                for (i = 0; i < items.Count; i++)
                {
                    var xmlAttributeCollection = items[i].Attributes;
                    if (xmlAttributeCollection != null)
                    {
                        XmlElement root = doc.DocumentElement;
                        String strOriginalString = "";

                        foreach (XmlNode node in root.SelectNodes("/root"))
                        {
                            if (strOriginalString != null)
                            {
                                XmlNode child2 = node.SelectSingleNode(sectie + "/" + key);
                                if (child2 != null)
                                {
                                    mysetting = PartOfString.Mid(child2.InnerText,1, child2.InnerText.Length-2);
                                }
                            }
                        }
                    }
                    break;
                }
                return mysetting;
            }
            catch (Exception es)
            {
                throw es;
            }

        }

    }
}
