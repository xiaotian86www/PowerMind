using PowerStone.Core.Stone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    class SingletonFactory : AbstractFactory
    {
        // 构造函数
        public SingletonFactory(Type type)
            : base(type)
        { 
        
        }

        public override IStone Create()
        {
            SingletonStone stone = new SingletonStone();
            stone.Stone = Activator.CreateInstance(this.Type);
            return stone;
        }
    }
}
