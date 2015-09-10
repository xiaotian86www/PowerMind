using PowerStone.Core.Design;
using PowerStone.Core.Exception;
using PowerStone.Core.Product;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace PowerStone.Core.Factory
{
    abstract class AbstractFactory : IFactory
    {
        // 设计模板
        protected XmlElement xmlDesign;

        public abstract Object Stone { get; }

        public virtual XmlElement XmlDesign 
        {
            set
            {
                this.xmlDesign = value;
            }
        }

        protected StoneProduct CreateProduct()
        {
            try
            {
                StoneProduct product = new StoneProduct();

                Assembly assembly = Assembly.Load(Context.GetString("PowerStone.Core.StonePath") + this.xmlDesign.GetAttribute("dll"));
                Type stoneType = assembly.GetType(this.xmlDesign.GetAttribute("type"));
                Object stone = Activator.CreateInstance(stoneType);
                product.Stone = stone;

                foreach(XmlElement xmle in this.xmlDesign.ChildNodes)
                {
                    if ("method".Equals(xmle.Name))
                    {
                        String methodName = xmle.GetAttribute("name");
                        String stoneMethodName = xmle.GetAttribute("value");
                        MethodInfo methodInfo = stoneType.GetMethod(stoneMethodName);
                        product.methods.Add(methodName, methodInfo);
                    }
                    else if ("property".Equals(xmle.Name))
                    {

                    }

                }
                return product;
            }
            catch (System.Exception ex)
            {
                throw new TypeNotFoundException("dll:" + this.xmlDesign.Dll + ",type:" + this.xmlDesign.Type + "没有找到", ex);
            }
        }
    }
}
