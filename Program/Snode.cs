using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class SingleNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public SingleNode<T> Next { get; set; }
        public SingleNode(int key, T value, SingleNode<T> next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
        public SingleNode(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
        public override string ToString()
        {
            return string.Format("({0},{1})", Key, Value);
        }
    }
}
