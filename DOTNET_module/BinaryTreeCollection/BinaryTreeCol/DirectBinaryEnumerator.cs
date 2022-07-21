using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class DirectBinaryEnumerator<T> : IBinaryTreeEnumerator<T> where T : IComparable<T>
    {
        public IEnumerable<T> GetEnumerator(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Value;

            foreach (var item in GetEnumerator(node.left))
            {
                yield return item;
            }

            foreach (var item in GetEnumerator(node.right))
            {
                yield return item;
            }
        }
    }
}
