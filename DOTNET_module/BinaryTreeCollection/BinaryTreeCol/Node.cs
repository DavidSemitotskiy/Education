using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class Node<T> where T: IComparable<T>
    {
        public Node<T> left;

        public Node<T> right;

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
