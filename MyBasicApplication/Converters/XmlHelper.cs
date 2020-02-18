using System;
using System.Xml;
using MyBasicApplication.Properties;

namespace MyBasicApplication.Converters
{
    public class XmlHelper
    {
        private static string serverIP;


        public static string MyLanguage
        {
            get { return Properties.Settings.Default.applanguage; }
            set { Properties.Settings.Default.applanguage = value; }
        }

        public static string GetItemNames(string srcDir, string _language)
        {
            Settings set = Settings.Default;
            MyLanguage = _language;

            try
            {

                //Lees de XML Nodes rfp en sync
                var doc = new XmlDocument();
                doc.Load(srcDir);
                var items = doc.GetElementsByTagName("config");
                var subitemserver = doc.GetElementsByTagName("language");
                var subitemredundancy = doc.GetElementsByTagName("redundancy");
                var subitemredundancymode = doc.GetElementsByTagName("mode");
                var subitembasestation = doc.GetElementsByTagName("rfp");
                var subitemmediaresource = doc.GetElementsByTagName("media_resource");
                string logType = "";
                string redundantType = "";

                for (int i = 0; i < items.Count; i++)
                {
                    var xmlAttributeCollection = items[i].Attributes;
                    if (xmlAttributeCollection != null)
                    {
                        XmlElement root = doc.DocumentElement;
                        String strOriginalString = "";
                        String strRedundantSystem = "";

                        foreach (XmlNode node in root.SelectNodes("/config"))
                        {
                            if (node.SelectSingleNode("language") != null)
                            {
                                XmlNode child = node.SelectSingleNode("language");
                                strOriginalString = child.InnerText;
                                if (strOriginalString != null)
                                {
                                    XmlNode child2 = node.SelectSingleNode("redundancy/mode");
                                    if (child2 != null)
                                    {
                                        strRedundantSystem = child2.InnerText;
                                        redundantType = strRedundantSystem;
                                    }

                                    logType = INIFile.ReadValue(MyLanguage, "LogFile", "thisLog") + " " + redundantType + " Server";

                                }
                                XmlNode child3 = node.SelectSingleNode("network/ipaddr");
                                if (child3 != null)
                                {
                                    serverIP = child3.InnerText;
                                }
                                logType = logType + " " + INIFile.ReadValue(MyLanguage, "LogFile", "thisIPaddr") + " " + serverIP;

                            }

                            else if (node.SelectSingleNode("media_resource/server") != null)
                            {
                                XmlNode childMR = node.SelectSingleNode("media_resource/server");
                                if (childMR != null)
                                {
                                    string strMRSystem = childMR.InnerText;
                                    logType = INIFile.ReadValue(MyLanguage, "LogFile", "thisLog") + " " + INIFile.ReadValue(MyLanguage, "LogFile", "MRConnected") + " " + strMRSystem;
                                }
                            }
                            else if (node.SelectSingleNode("rfp/server") != null)
                            {
                                XmlNode childBS = node.SelectSingleNode("rfp/server");
                                if (childBS != null)
                                {
                                    string strMRSystem = childBS.InnerText;
                                    logType = INIFile.ReadValue(MyLanguage, "LogFile", "thisLog") + " " + INIFile.ReadValue(MyLanguage, "LogFile", "BSConnected") + " " + strMRSystem;

                                }
                            }
                            break;
                        }
                    }
                }
                return logType;
            }
            catch (Exception es)
            {
                throw es;
            }
        }

    }

}
