using PowerStone.Core.Design;
using PowerStone.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    abstract class AbstractFactory : IFactory
    {
        // 原石
        protected IProduct product;

        // 设计模板
        protected IDesign design;

        public abstract Object Stone { get; }
    }
}
