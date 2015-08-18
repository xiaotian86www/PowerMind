using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMind.Model.Base
{
    interface IBiTreeNode : IEnumerable<IBiTreeNode>
    {
        // 获取id标识
        UInt32 Id { get; }

        // 插入子节点
        void InsertChild(IBiTreeNode child);

        // 删除子节点
        void DeleteChild(UInt32 id);

        // 获取父节点
        IBiTreeNode GetParent();

        // 获取子节点
        List<IBiTreeNode> GetChildren();
    }
}
