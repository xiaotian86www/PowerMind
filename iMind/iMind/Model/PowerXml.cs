using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerMind.Model
{
    class PowerXml : XmlDocument
    {
        private bool IsModify { get; set; }

        private String XmlPath { get; set; }

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
