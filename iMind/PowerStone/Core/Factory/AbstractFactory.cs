using PowerStone.Core.Design;
using PowerStone.Core.Exception;
using PowerStone.Core.Product;
using System;
using System.IO;
using System.Reflection;

namespace PowerStone.Core.Factory
{
    abstract class AbstractFactory : IFactory
    {
        // 设计模板
        protected StoneDesign design;

        public abstract Object Stone { get; }

        public virtual StoneDesign Design 
        {
            set
            {
                this.design = value;
            }
        }

        protected StoneProduct CreateProduct()
        {
            try
            {
                DirectoryInfo diri = new DirectoryInfo(Context.GetString("PowerStone.Core.StonePath"));

                Assembly assembly = Assembly.Load(this.design.Dll);
                Type stoneType = assembly.GetType(this.design.Type);
                StoneProduct product = new StoneProduct();
                Object stone = Activator.CreateInstance(stoneType);
                product.Stone = stone;
                return product;
            }
            catch (System.Exception ex)
            {
                throw new TypeNotFoundException("dll:" + this.design.Dll + ",type:" + this.design.Type + "没有找到", ex);
            }
        }
    }
}
