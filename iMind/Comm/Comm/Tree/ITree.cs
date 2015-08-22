using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm.Tree
{
    public interface ITree<T> : IEnumerable<ITree<T>>
    {
        // data读写属性
        T Data { set; get; }

        // 插入子节点
        void InsertChild(T data);

        // 删除子节点
        void DeleteChild(T data);

        // 查找子节点
        ITree<T> SearchChild(T data);

        // 父节点属性
        ITree<T> Parent { get; }

        // 子节点属性
        List<ITree<T>> Children { get; }
    }
}
