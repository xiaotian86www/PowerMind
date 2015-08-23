using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerStone.Core.Stone
{
    class AbstractStone : IStone
    {
        // 原石
        public Object Stone { get; set; }

        // 原石类型
        public Type Type { get; set; }
    }
}
