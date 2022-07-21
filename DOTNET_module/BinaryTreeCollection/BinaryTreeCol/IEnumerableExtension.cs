using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public static class IEnumerableExtension
    {
        public static BinaryTree<T> ToBinary<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            var binaryTree = new BinaryTree<T>(new DirectBinaryEnumerator<T>());
            foreach (var item in collection)
            {
                binaryTree.Add(item);
            }
            return binaryTree;
        }
    }
}
