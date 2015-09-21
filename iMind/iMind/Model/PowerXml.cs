using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerMind.Control
{
    public class PowerXml
    {
        private XmlDocument xml;

        private bool IsModify { get; set; }

        private String XmlPath { get; set; }

        public String FileName { get; set; }

        public XmlElement RootElement
        {
            get
            {
                return xml.DocumentElement;
            }
        }

        private PowerXml(String fileName)
        {
            this.xml = new XmlDocument();
            this.FileName = fileName;
            xml.NodeChanged += PowerXml_NodeChanged;
            xml.NodeInserted += PowerXml_NodeInserted;
            xml.NodeRemoved += PowerXml_NodeRemoved;
        }

        private PowerXml(FileInfo fileInfo)
        {
            this.xml = new XmlDocument();
            this.XmlPath = fileInfo.FullName;
            this.FileName = fileInfo.Name;
            xml.NodeChanged += PowerXml_NodeChanged;
            xml.NodeInserted += PowerXml_NodeInserted;
            xml.NodeRemoved += PowerXml_NodeRemoved;
        }

        public static PowerXml CreatePowerXml(String fileName)
        {
            PowerXml powerXml = new PowerXml(fileName);

            XmlDeclaration xmld = powerXml.xml.CreateXmlDeclaration("1.0", "uft-8", null);
            powerXml.xml.AppendChild(xmld);
            XmlElement root = powerXml.xml.CreateElement("root");
            root.SetAttribute("key", "中心");
            powerXml.xml.AppendChild(root);

            return powerXml;
        }

        public static PowerXml LoadPowerXml(String filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists)
                return CreatePowerXml(fi.Name);
            PowerXml powerXml = new PowerXml(fi);
            powerXml.xml.Load(fi.FullName);

            return powerXml;
        }

        void PowerXml_NodeRemoved(object sender, XmlNodeChangedEventArgs e)
        {
            this.IsModify = true;
        }

        void PowerXml_NodeInserted(object sender, XmlNodeChangedEventArgs e)
        {
            this.IsModify = true;
        }

        void PowerXml_NodeChanged(object sender, XmlNodeChangedEventArgs e)
        {
            this.IsModify = true;
        }

        public void Save()
        {
            if (IsModify && null != XmlPath)
            {
                Save(XmlPath);
            }
        }

        public void Save(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists && (IsModify || !fi.FullName.Equals(XmlPath)))
                xml.Save(filename);
        }
    }
}
