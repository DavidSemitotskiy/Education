using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class Node
    {
        public Node left;

        public Node right;

        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
