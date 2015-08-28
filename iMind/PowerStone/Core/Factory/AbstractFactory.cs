using PowerStone.Core.Design;
using PowerStone.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerStone.Core.Factory
{
    abstract class AbstractFactory : IFactory
    {
        // 原石
        protected StoneProduct product;

        // 设计模板
        protected StoneDesign design;

        public abstract Object Stone { get; }


        public void Singleton(XmlNode xml)
        {
            XmlNodeList nodes = xml.ChildNodes;

            design = new StoneDesign();
            foreach(XmlNode node in nodes)
            {

            }
        }
    }
}
