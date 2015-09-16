using PowerMind.Model;
using PowerMind.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace PowerMind.Control
{
    class Context
    {
        private static Context context = new Context();

        private Dictionary<String, PowerXml> xmlMinds = new Dictionary<string, PowerXml>();

        private Dictionary<String, MainForm> mindForms = new Dictionary<string, MainForm>();

        private Context() { }

        public void Init(String[] names)
        {
            if (0 == names.Length)
            {
                context.AddXmlMind("newMind");
            }
            else
            {
                foreach (String name in names)
                {
                    context.LoadXmlMind(name);
                }
            }
        }

        public static Context GetContext()
        {
            return context;
        }

        public PowerXml GetXmlMind(String name)
        {
            return xmlMinds[name];
        }

        public void LoadXmlMind(String xmlPath)
        {
            FileInfo fi = new FileInfo(xmlPath);
            if (!fi.Exists)
                throw new FileNotFoundException(xmlPath + "文件未找到");
            PowerXml xmlMind = new PowerXml(fi.Name);
            xmlMind.Load(fi.FullName);

            xmlMinds.Add(fi.Name, xmlMind);
            mindForms.Add(fi.Name, new MainForm(xmlMind));
            Application.Run(mindForms[fi.Name]);
        }

        public void AddXmlMind(String xmlName)
        {
            PowerXml xmlMind = new PowerXml("NewMind");
            XmlDeclaration xmld = xmlMind.CreateXmlDeclaration("1.0", "uft-8", null);
            xmlMind.AppendChild(xmld);
            XmlElement root = xmlMind.CreateElement("root");
            root.SetAttribute("key", "中心");
            xmlMind.AppendChild(root);

            xmlMinds.Add(xmlName, xmlMind);
            mindForms.Add(xmlName, new MainForm(xmlMind));
            Application.Run(mindForms[xmlName]);
        }
    }
}
