using PowerMind.Context.Base;
using PowerMind.Context.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Context
{
    class IslandNode : AbstractMindTree
    {
        // 获取主题
        public AbstractMindTree GetTheme()
        {
            return this.tree.GetParent().Content;
        }

        // 获取话题
        public List<AbstractMindTree> GetSubtopics()
        {
            List<AbstractMindTree>  subtopics = new List<AbstractMindTree>();
            List<ITree<AbstractMindTree>> children = this.tree.GetChildren();

            foreach(ITree<AbstractMindTree> tchild in children)
            {
                subtopics.Add(tchild.Content);
            }

            return subtopics;
        }
    }
}
