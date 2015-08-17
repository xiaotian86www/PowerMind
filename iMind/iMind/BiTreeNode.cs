using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMind
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
        BiTreeNode()
        {
            id = ++sId;
        }

        BiTreeNode(BiTreeNode parentNode)
        {
            this.parent = parentNode;
            id = ++sId;
        }

        // 获取id
        public UInt32 GetId()
        {
            return id;
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

                if (node.GetId() == id)
                {
                    if (node.parent == prior)
                        prior.child = node.brother;
                    else
                        prior.brother = node.brother;
                }
            }
        }

        #region 先序遍历
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
