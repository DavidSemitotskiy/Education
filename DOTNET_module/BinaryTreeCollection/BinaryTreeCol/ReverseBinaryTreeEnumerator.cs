using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class ReverseBinaryTreeEnumerator : IBinaryTreeEnumerator
    {
        public IEnumerable<int> GetEnumerator(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var item in GetEnumerator(node.left))
            {
                yield return item;
            }

            foreach (var item in GetEnumerator(node.right))
            {
                yield return item;
            }

            yield return node.Value;
        }
    }
}
