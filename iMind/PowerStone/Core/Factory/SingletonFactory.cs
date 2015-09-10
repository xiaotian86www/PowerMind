using PowerStone.Core.Product;
using System;

namespace PowerStone.Core.Factory
{
    class SingletonFactory : AbstractFactory
    {
        private StoneProduct product;

        public override Object Stone
        {
            get
            {
                if (null == this.product)
                {
                    this.product = this.CreateProduct();
                }
                return this.product.Stone;
            }
        }
    }
}
