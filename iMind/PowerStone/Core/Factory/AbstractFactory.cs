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

                Assembly assembly = Assembly.LoadFrom(Context.GetString("PowerStone.Core.StonePath") + "\\" + this.xmlDesign.GetAttribute("dll"));
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
                        String name = xmle.GetAttribute("name");
                        if (xmle.HasAttribute("value"))
                            stoneType.GetProperty(name).SetValue(stone, xmle.GetAttribute("value"));
                        else if (xmle.HasAttribute("ref"))
                            stoneType.GetProperty(name).SetValue(stone, Context.GetStone(xmle.GetAttribute("ref")));
                    }

                }
                return product;
            }
            catch (System.Exception ex)
            {
                throw new CannotCreateProductException("dll:" + this.xmlDesign.GetAttribute("dll") + ",type:" + this.xmlDesign.GetAttribute("type") + "创建失败", ex);
            }
        }
    }
}
