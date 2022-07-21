using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public static class UnusualOrderBinaryTreeExtension
    {
        public static IEnumerable<int> UnusualOrder(this BinaryTree<int> binaryTree)
        {
            var binaryTreeCollection = binaryTree.Enumerator.GetEnumerator(binaryTree.BinaryTreeNode);
            var evenOrderedItems = binaryTreeCollection.Where(item => item % 2 == 0).OrderBy(item => item).ToList();
            var oddOrderedItems = binaryTreeCollection.Where(item => item % 2 != 0).OrderBy(item => item).ToList();
            int countIterations = evenOrderedItems.Count + oddOrderedItems.Count;
            for (int i = 0, j = 0, count = 0; count < countIterations; )
            {
                if (i < oddOrderedItems.Count)
                {
                    yield return oddOrderedItems[i];
                    i++;
                }

                if (j < evenOrderedItems.Count)
                {
                    yield return evenOrderedItems[j];
                    j++;
                }

                count++;
            }
        }
    }
}
