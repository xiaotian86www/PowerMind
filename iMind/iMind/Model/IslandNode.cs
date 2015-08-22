using Comm.Tree;
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
            return this.tree.Parent.Data;
        }

        // 获取话题
        public List<AbstractMindTree> GetSubtopics()
        {
            List<AbstractMindTree>  subtopics = new List<AbstractMindTree>();
            List<ITree<AbstractMindTree>> children = this.tree.Children;

            foreach(ITree<AbstractMindTree> tchild in children)
            {
                subtopics.Add(tchild.Data);
            }

            return subtopics;
        }
    }
}
