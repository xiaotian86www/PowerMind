using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMind
{
    class Node : IEnumerable<Node> , IComparable<Node>
    {
        // 类静态变量，每实例化一个对象加一
        private static UInt32 ID = 0;

        // 节点id
        private UInt32 id;

        // 父节点
        private Node parentNode;

        // 兄弟节点
        private Node brotherNode;

        // 子节点
        private Node childNode;

        // 构造函数
        Node()
        {
            id = ++ID;
        }

        Node(Node parentNode)
        {
            this.parentNode = parentNode;
            id = ++ID;
        }

        // 插入子节点
        public void InsertChild(Node childNode)
        {
            childNode.parentNode = this;

            if (null == childNode)
            {
                this.childNode = childNode;
            }
            else
            {
                Node temp = this.childNode;
                while (null != temp.brotherNode)
                {
                    temp = temp.brotherNode;
                }
                temp.brotherNode = childNode;
            }
        }

        // 删除子节点
        public void DeleteChild(Node childNode)
        {
            foreach (Node node in this)
            {

            }
        }

        #region 遍历
        protected IEnumerable<Node> Traverse()
        {
            if (null != childNode)
            {
                foreach (Node node in childNode.Traverse())
                    yield return node;

                yield return this;

                foreach (Node node in brotherNode.Traverse())
                    yield return node;
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (Node node in this.Traverse())
                yield return node;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region 判断节点是否相同
        public int CompareTo(Node other)
        {
            return this.id.CompareTo(other.id);
        }
        #endregion
    }
}
