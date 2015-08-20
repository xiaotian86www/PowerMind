using PowerMind.Context.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Context
{
    abstract class AbstractMindTree
    {
        // 二叉树根节点
        protected ITree<AbstractMindTree> tree;

        // 构造函数
        public AbstractMindTree(String type)
        {
            this.type = type;
            this.tree = new BiTree<AbstractMindTree>();
            this.tree.Content = this;
        }

        #region 字段、属性
        // 节点类型
        private String type;

        // 节点名
        private String key;

        // 节点颜色
        private Color color;

        // 节点形状
        private String shape;

        // Type只读属性
        public String Type
        {
            get { return type; }
        }

        // Title读写属性
        public string Key
        {
            get { return key; }
            set { this.key = value; }
        }

        // Color读写属性
        public Color Color
        {
            get { return color; }
            set { this.color = value; }
        }

        // Shape读写属性
        public String Shape
        {
            get { return shape; }
            set { this.shape = value; }
        }
        #endregion
    }
}
