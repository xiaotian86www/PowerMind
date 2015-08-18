using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model.Base
{
    class BiTreeNode : IBiTreeNode
    {
        // 静态ID
        private static UInt32 sId = 0;

        // 对象唯一id
        private UInt32 id;

        // 父节点
        private BiTreeNode parent;

        // 兄弟节点
        private BiTreeNode brother;

        // 子节点
        private BiTreeNode child;

        // 构造函数
        public BiTreeNode()
        {
            id = ++sId;
        }

        #region 二叉树标准操作
        // Id可读属性
        public UInt32 Id
        {
            get { return id; }
        }

        // 插入子节点
        public void InsertChild(IBiTreeNode child)
        {
            BiTreeNode tchild = (BiTreeNode)child;
            tchild.parent = this;

            if (null == child)
            {
                this.child = tchild;
            }
            else
            {
                BiTreeNode temp = this.child;
                while (null != temp.brother)
                {
                    temp = temp.brother;
                }
                temp.brother = tchild;
            }
        }

        // 删除子节点
        public void DeleteChild(UInt32 id)
        {
            BiTreeNode prior = null;

            foreach (BiTreeNode node in this)
            {
                if (null == prior)
                {
                    prior = node;
                    continue;
                }

                if (node.id == id)
                {
                    if (node.parent == prior)
                        prior.child = node.brother;
                    else
                        prior.brother = node.brother;
                }
            }
        }

        // 获取父节点
        public IBiTreeNode GetParent()
        {
            return parent;
        }

        //// 获取子节点
        //public List<IBiTreeNode> GetChildren()
        //{
        //    List<IBiTreeNode> children = new List<IBiTreeNode>();
        //}
        #endregion

        #region 先序遍历,实现IEnumerable接口
        //  递归遍历
        protected IEnumerable<IBiTreeNode> Traverse()
        {
            yield return this;

            if (null != child)
                foreach (IBiTreeNode node in child.Traverse())
                    yield return node;

            if (null != brother)
                foreach (BiTreeNode node in brother.Traverse())
                    yield return node;
        }

        public IEnumerator<IBiTreeNode> GetEnumerator()
        {
            foreach (IBiTreeNode node in this.Traverse())
                yield return node;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
