using PowerStone.Core.Design;
using PowerStone.Core.Product;
using System;

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
                this.design = value;
            }
        }
    }
}
