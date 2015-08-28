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
        public static StoneDesign Reader(XmlElement xml)
        {
            StoneDesign sd = new StoneDesign();

            String id = xml.GetAttribute("id");
            String class = xml.GetAttribute("class");

            Assembly assembly = Assembly.load(xml.)
        }
    }
}
