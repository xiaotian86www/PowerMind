using PowerStone.Core.Design;
using PowerStone.Core.Exception;
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

        public StoneDesign Design 
        {
            set
            {
                String typeName = this.GetType().Name;
                if (!typeName.Equals(value.Mode + "Factory"))
                    throw new FactoryNotMatchException();

                this.design = value;
            }
        }
    }
}
