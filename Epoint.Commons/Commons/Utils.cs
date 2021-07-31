using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace Epoint.Systems.Commons
{
    public class Utils
    {
        //[DllImport("shell32.dll")]
        //private static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, Utils.ShowCommands nShowCmd);
        public static string ReadConfigXML(string cfile, string inkey)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(cfile);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("/configuration/appSettings/add[@key='" + inkey + "']");
            if (xmlNode != null)
                return xmlNode.Attributes["value"].Value;
            return (string)null;
        }

        public static void WtiteConfigXML(string cfile, string inkey, string invalue)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(cfile);
            XmlNode newChild = xmlDocument.SelectSingleNode("/configuration/appSettings/add[@key='" + inkey + "']");
            if (newChild == null)
            {
                XmlNode xmlNode = xmlDocument.SelectSingleNode("/configuration/appSettings");
                newChild = xmlDocument.CreateNode(XmlNodeType.Element, "add", (string)null);
                xmlNode.AppendChild(newChild);
                XmlAttribute node = (XmlAttribute)xmlDocument.CreateNode(XmlNodeType.Attribute, "key", "");
                node.Value = inkey;
                newChild.Attributes.Append(node);
            }
            if (newChild != null)
            {
                XmlAttribute attribute = newChild.Attributes["value"];
                if (attribute != null)
                    newChild.Attributes.Remove(attribute);
                XmlAttribute node = (XmlAttribute)xmlDocument.CreateNode(XmlNodeType.Attribute, "value", "");
                node.Value = invalue;
                newChild.Attributes.Append(node);
            }
            string str = cfile + ".new";
            xmlDocument.Save(str);
            if (!File.Exists(str))
                return;
            long num = 0;
            using (FileStream fileStream = File.OpenRead(str))
                num = fileStream.Length;
            if (num <= 0L)
                return;
            if (File.Exists(cfile))
                File.Delete(cfile);
            File.Move(str, cfile);
        }
        public static bool CheckExistsXMLNode(string cfile, string inkey)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(cfile);
            XmlNode newChild = xmlDocument.SelectSingleNode("/configuration/appSettings/add[@key='" + inkey + "']");
            if (newChild == null)
            {
                return false;
            }
            return true;
        }

        public static int ParseInt32(object strNumber, int _default)
        {
            if (strNumber == null)
                return _default;
            try
            {
                int length = 0;
                while (length < ((string)strNumber).Length && ((int)((string)strNumber)[length] >= 48 && (int)((string)strNumber)[length] <= 57))
                    ++length;
                return int.Parse(((string)strNumber).Substring(0, length));
            }
            catch (Exception ex)
            {
            }
            return _default;
        }
    }
}
