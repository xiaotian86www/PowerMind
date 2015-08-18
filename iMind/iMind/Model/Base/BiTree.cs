using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model.Base
{
    class BiTree<T> : IBiTree<T>
    {
        // 文本
        private T content;

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

        #region 二叉树基本操作
        // Text读写属性
        public T Text
        {
            get { return this.content; }
            set { this.content = value; }
        }

        // 插入子节点
        public void InsertChild(IBiTree<T> child)
        {
            BiTree<T> tchild = (BiTree<T>)child;
            tchild.parent = this;

            if (null == child)
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
        public void DeleteChild(IBiTree<T> child)
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

        // 获取父节点
        public IBiTree<T> GetParent()
        {
            return this.parent;
        }

        // 获取子节点
        public List<IBiTree<T>> GetChildren()
        {
            List<IBiTree<T>> children = new List<IBiTree<T>>();

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
        #endregion

        #region 先序遍历,实现IEnumerable接口
        //  递归遍历
        protected IEnumerable<IBiTree<T>> Traverse()
        {
            yield return this;

            if (null != this.child)
                foreach (IBiTree<T> tchild in this.child.Traverse())
                    yield return tchild;

            if (null != this.brother)
                foreach (BiTree<T> tchild in this.brother.Traverse())
                    yield return tchild;
        }

        public IEnumerator<IBiTree<T>> GetEnumerator()
        {
            foreach (IBiTree<T> tnode in this.Traverse())
                yield return tnode;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
