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

            try
            {
                sd.Num = Convert.ToInt32(xmle.GetAttribute("num"));
            }
            catch (System.Exception ex)
            {
                throw new XMLAttributeNotFoundException(sd.Id + ":num属性没有找到，或不能转化为int类型", ex);
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
