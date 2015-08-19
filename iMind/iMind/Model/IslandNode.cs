using PowerMind.Model.Base;
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
            return this.tree.GetParent().Content;
        }

        // 获取话题
        public List<AbstractMindTree> GetSubtopics()
        {
            List<AbstractMindTree>  subtopics = new List<AbstractMindTree>();
            List<IBiTree<AbstractMindTree>> children = this.tree.GetChildren();

            foreach(IBiTree<AbstractMindTree> tchild in children)
            {
                subtopics.Add(tchild.Content);
            }

            return subtopics;
        }
    }
}
