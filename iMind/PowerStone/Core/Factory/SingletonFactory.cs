using PowerStone.Core.Design;
using PowerStone.Core.Exception;
using PowerStone.Core.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    class SingletonFactory : AbstractFactory
    {
        public override Object Stone
        {
            get
            {
                if (null == this.product)
                {
                    try
                    {
                        DirectoryInfo diri = new DirectoryInfo(Context.GetString("PowerStone.Core.StonePath"));

                        Assembly assembly = Assembly.Load(this.design.Dll);
                        Type stoneType = assembly.GetType(this.design.Type);
                        this.product = new StoneProduct();
                        Object stone = Activator.CreateInstance(stoneType);
                        this.product.Stone = stone;
                    }
                    catch (System.Exception ex)
                    {
                        throw new TypeNotFoundException("dll:" + this.design.Dll + ",type:" + this.design.Type + "没有找到", ex);
                    }

                }
                return this.product.Stone;
            }
        }
    }
}
