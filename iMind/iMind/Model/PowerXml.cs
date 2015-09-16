using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerMind.Model
{
    public class PowerXml : XmlDocument
    {
        private bool IsModify { get; set; }

        private String XmlPath { get; set; }

        public String FileName { get; set; }

        public PowerXml(String fileName)
        {
            this.FileName = fileName;
            this.NodeChanged += PowerXml_NodeChanged;
            this.NodeInserted += PowerXml_NodeInserted;
            this.NodeRemoved += PowerXml_NodeRemoved;
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

        public override void Save(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (fi.Exists && (IsModify || !fi.FullName.Equals(XmlPath)))
                base.Save(filename);
        }
    }
}
