using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model
{
    class IslandNode : AbstractMindTree
    {
        // 获取主题
        public AbstractMindTree GetTheme()
        {
            return this.root.Text;
        }
    }
}
