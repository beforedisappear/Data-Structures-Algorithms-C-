using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    public enum ColorNode // раскраска узлов
    {
        Red,
        Black
    }
    class RBTnode<T>
    {
        public int Key;
        public T Value;
        public RBTnode<T> Right;
        public RBTnode<T> Left;
        public RBTnode<T> Parent;
        public ColorNode Color;

        public RBTnode(int k, T v) // констуктор для создания узла
        {
            Key = k;
            Value = v;
            Left = null;
            Right = null;
            Parent = null;
        }
        public RBTnode() // пустой конструктор
        {
            Key = int.MaxValue;
            Value = default(T);
            Left = null;
            Right = null;
            Parent = null;
        }
        public override string ToString()
        {
            string ret = string.Format("TreeNode : (Key = {0},Value = {1},Color = {2})", Key, Value, Color);
            if (Parent != null) ret = ret + string.Format(" ParentKey = {0};", Parent.Key);
            if (Left != null) ret = ret + string.Format(" LeftKey = {0};", Left.Key);
            if (Right != null) ret = ret + string.Format(" RightKey = {0}", Right.Key);
            return ret;
        }
    }
}
