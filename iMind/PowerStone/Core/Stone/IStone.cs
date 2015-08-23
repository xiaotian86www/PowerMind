using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Stone
{
    interface IStone
    {
        // 原石
        Object Stone { get; set; }

        // 类型
        Type Type { get; set; }
    }
}
