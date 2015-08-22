using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm.Tree
{
    class BiTree<T> : ITree<T>
    {
        // 文本
        private T data;

        // 父节点
        private BiTree<T> parent;

        // 兄弟节点
        private BiTree<T> brother;

        // 子节点
        private BiTree<T> child;

        // 构造函数
        public BiTree()
        {
            
        }

        public BiTree(T data)
        {
            this.data = data;
        }

        #region 二叉树基本操作
        // Text读写属性
        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        // 插入子节点
        public void InsertChild(T data)
        {
            BiTree<T> tchild = new BiTree<T>(data);
            tchild.parent = this;

            if (null == data)
            {
                this.child = tchild;
            }
            else
            {
                BiTree<T> temp = this.child;
                while (null != temp.brother)
                {
                    temp = temp.brother;
                }
                temp.brother = tchild;
            }
        }

        // 删除子节点
        public void DeleteChild(T data)
        {
            BiTree<T> prior = null;

            foreach (BiTree<T> tchild in this)
            {
                if (null == prior)
                {
                    prior = tchild;
                    continue;
                }

                if (tchild == child)
                {
                    if (tchild.parent == prior)
                        prior.child = tchild.brother;
                    else
                        prior.brother = tchild.brother;
                }
            }
        }

        // 查找子节点
        public ITree<T> SearchChild(T data)
        {
            BiTree<T> prior = null;

            foreach (BiTree<T> tchild in this)
            {
                if (null == prior)
                {
                    prior = tchild;
                    continue;
                }

                if (tchild.Data.Equals(data))
                {
                    return tchild;
                }
            }

            return null;
        }

        // 获取父节点
        public ITree<T> Parent
        {
            get { return this.parent; }
        }

        // 获取子节点
        public List<ITree<T>> Children
        {
            get
            {
                List<ITree<T>> children = new List<ITree<T>>();

                if (null != this.child)
                {
                    BiTree<T> tchild = this.child;
                    children.Add(tchild);

                    while (null != tchild.brother)
                    {
                        tchild = tchild.brother;
                        children.Add(tchild);
                    }
                }

                return children;
            }
        }
        #endregion

        #region 实现IEnumerable接口
        //  先序遍历
        private IEnumerable<ITree<T>> PreTraverse()
        {
            yield return this;

            if (null != this.child)
                foreach (ITree<T> tchild in this.child.PreTraverse())
                    yield return tchild;

            if (null != this.brother)
                foreach (ITree<T> tchild in this.brother.PreTraverse())
                    yield return tchild;
        }

        // 后序遍历
        private IEnumerable<ITree<T>> PostTraverse()
        {
            if (null != this.child)
                foreach (ITree<T> tchild in this.child.PostTraverse())
                    yield return tchild;

            yield return this;

            if (null != this.brother)
                foreach (ITree<T> tchild in this.brother.PostTraverse())
                    yield return tchild;
        }

        // 层次遍历
        private IEnumerable<ITree<T>> LevelTraverse()
        {
            yield return this;

            if (null != this.brother)
                foreach (ITree<T> tchild in this.brother.LevelTraverse())
                    yield return tchild;

            if (null != this.child)
                foreach (ITree<T> tchild in this.child.LevelTraverse())
                    yield return tchild;
        }

        public IEnumerator<ITree<T>> GetEnumerator()
        {
            foreach (ITree<T> tnode in this.PreTraverse())
                yield return tnode;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
