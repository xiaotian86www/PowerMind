using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerMind.Control
{
    class Context
    {
        private static Context context = new Context();

        private Dictionary<String, XmlDocument> xmlMinds = new Dictionary<string, XmlDocument>();

        private Context() { }

        public static Context GetContext()
        {
            return context;
        }

        public XmlDocument GetXmlMind(String name)
        {
            return xmlMinds[name];
        }

        public void LoadXmlMind(String xmlPath)
        {
            FileInfo fi = new FileInfo(xmlPath);
            if (!fi.Exists)
                throw new FileNotFoundException(xmlPath + "文件未找到");
            XmlDocument xmlMind = new XmlDocument();
            xmlMind.Load(fi.FullName);
            xmlMinds.Add(fi.Name, xmlMind);
        }

        public void AddXmlMind(String xmlName)
        {
            XmlDocument xmlMind = new XmlDocument();
            XmlDeclaration xmld = xmlMind.CreateXmlDeclaration("1.0", "uft-8", null);
            xmlMind.AppendChild(xmld);
            XmlElement root = xmlMind.CreateElement("root");
            root.SetAttribute("key", "中心");
            xmlMind.AppendChild(root);
            xmlMinds.Add(xmlName, xmlMind);
        }
    }
}
