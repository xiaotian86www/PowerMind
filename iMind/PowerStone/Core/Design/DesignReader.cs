using PowerStone.Core.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerStone.Core.Design
{
    class DesignReader
    {
        public static StoneDesign Reader(XmlNode xmln)
        {
            StoneDesign sd = new StoneDesign();

            XmlElement xmle = xmln as XmlElement;

            sd.Id = xmle.GetAttribute("id");
            if (null == sd.Id)
                throw new XMLAttributeNotFoundException("Id属性没有找到！");

            sd.Mode = xmle.GetAttribute("mode");
            if (null == sd.Mode)
                sd.Mode = "Singleton";

            sd.Dll = xmle.GetAttribute("dll");
            if (null == sd.Dll)
                throw new XMLAttributeNotFoundException(sd.Id + ":dll属性没有找到！");
            sd.Dll = sd.Dll + Context.GetString("PowerStone.Core.StonePath");

            sd.Type = xmle.GetAttribute("type");
            if (null == sd.Type)
                throw new XMLAttributeNotFoundException(sd.Id + ":type属性没有找到！");

            XmlNodeList xmlnl = xmln.ChildNodes;
            Dictionary<String, Object> properties = new Dictionary<string, Object>();
            Dictionary<String, String> methods = new Dictionary<string, string>();
            foreach (XmlNode txmln in xmln)
            {
                XmlElement txmle = txmln as XmlElement;
                if ("attribute".Equals(txmle.Name))
                    properties.Add(txmle.GetAttribute("name"), txmle.InnerText);
                else if ("method".Equals(txmle.Name))
                    methods.Add(txmle.GetAttribute("name"), txmle.InnerText);
            }
            sd.Properties = properties;

            return sd;
        }
    }
}
