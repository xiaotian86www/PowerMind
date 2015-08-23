using PowerStone.Core.Stone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    abstract class AbstractFactory : IFactory
    {
        // 构造函数
        public AbstractFactory(Type type)
        {
            this.Type = type;
        }

        // 属性
        public Type Type { get; set; }

        public abstract IStone Create();
    }
}
