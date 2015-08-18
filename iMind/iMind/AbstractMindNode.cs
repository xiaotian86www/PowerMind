using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind
{   
    // 节点类型枚举
    enum MindNodeOfType { Bridge, Island }

    // 节点形状枚举
    enum MindNodeOfShape { Rectangle, ellipse }

    abstract class AbstractMindNode : BiTreeNode
    {
        // 构造函数
        public AbstractMindNode(MindNodeOfType type)
        {
            this.type = type;
        }

        #region 字段、属性
        // 节点类型
        private MindNodeOfType type;

        // 节点名
        private String title;

        // 节点颜色
        private Color color;

        // 节点形状
        private MindNodeOfShape shape;

        // Type只读属性
        public MindNodeOfType Type
        {
            get { return type; }
        }

        // Title读写属性
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        // Color读写属性
        public Color Color
        {
            get { return color; }
            set { this.color = value; }
        }

        // Shape读写属性
        public MindNodeOfShape Shape
        {
            get { return shape; }
            set { this.shape = value; }
        }
        #endregion
    }
}
