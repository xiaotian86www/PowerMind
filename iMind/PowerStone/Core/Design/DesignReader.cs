using PowerStone.Core.Exception;
using System;
using System.Collections.Generic;
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
            if (null == xmle)
                throw new XMLNodeNotFoundException();

            sd.Id = xmle.GetAttribute("id");
            if (null == sd.Id)
                throw new XMLAttributeNotFoundException("Id没有找到！");

            sd.Mode = xmle.GetAttribute("mode");
            if (null == sd.Mode)
                sd.Mode = "Singleton";
            

            String dll = xmle.GetAttribute("dll");
            String type = xmle.GetAttribute("type");
            try
            {
                Assembly assembly = Assembly.Load(dll);
                sd.Type = assembly.GetType(type);
            }
            catch (System.Exception ex)
            {
                throw new TypeNotFoundException("dll:" + dll + ",type:" + type + "没有找到", ex);
            }

            Dictionary<String, String> attributes = new Dictionary<string,string>();
            XmlNodeList xmlnl = xmln.ChildNodes;
            foreach (XmlNode txmln in xmln)
            {
                XmlElement txmle = txmln as XmlElement;
                attributes.Add(txmle.GetAttribute("name"), xmle.InnerText);
            }
            sd.Attributes = attributes;

            return sd;
        }
    }
}
