using System;
using PowerStone.Core.Product;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Factory
{
    interface IFactory
    {
        // 创建Stone
        Object Stone { get; }
    }
}
