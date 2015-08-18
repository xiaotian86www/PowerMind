﻿using PowerMind.Model.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model
{
    abstract class AbstractMindNode
    {
        // 二叉树根节点
        protected BiTreeNode root;

        // 构造函数
        public AbstractMindNode(String type)
        {
            this.type = type;
            root = new BiTreeNode();
        }

        #region 字段、属性
        // 节点类型
        private String type;

        // 节点名
        private String title;

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
        public String Shape
        {
            get { return shape; }
            set { this.shape = value; }
        }
        #endregion
    }
}