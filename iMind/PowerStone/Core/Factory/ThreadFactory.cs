using PowerStone.Core.Design;
using PowerStone.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    class ThreadFactory : AbstractFactory
    {
        private StoneProduct[] products;

        private int index =  0;

        public override StoneDesign Design
        {
            set
            {
                this.Design = value;
                products = new StoneProduct[value.Num];
            }
        }

        public override object Stone
        {
            get 
            {
                this.index = this.index % base.design.Num;
                if (null == this.products[index])
                {
                    this.products[index] = this.CreateProduct();
                }
                return this.products[index];
            }
        }
    }
}
