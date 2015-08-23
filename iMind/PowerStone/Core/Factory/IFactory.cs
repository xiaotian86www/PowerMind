using System;
using PowerStone.Core.Stone;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    interface IFactory
    {
        // 类型
        Type Type { get; set; }

        // 创建Stone
        IStone Create();
    }
}
