using PowerStone.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    this.product = new SingletonProduct();
                    Object stone = Activator.CreateInstance(this.design.Class);
                    this.product.Stone = stone;
                    return stone;
                }
                return this.product.Stone;
            }
        }
    }
}
