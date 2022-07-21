using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class BinaryTree<T> : ICollection<int>
    {
        private int Length = 0;

        private Node _binaryTreeNode;

        public BinaryTree(IBinaryTreeEnumerator enumerator)
        {
            Enumerator = enumerator;
        }

        public Node BinaryTreeNode
        {
            get
            {
                return _binaryTreeNode;
            }
        }

        public IBinaryTreeEnumerator Enumerator { get; set; }

        public int Count => Length;

        public bool IsReadOnly => false;

        public void Add(int item)
        {
            AddNewItem(ref _binaryTreeNode, item);
            Length++;
        }

        public void Clear()
        {
            Length = 0;
            _binaryTreeNode = null;
        }

        public bool Contains(int item)
        {
            return ContainsElement(BinaryTreeNode, item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            var binaryCollection = Enumerator.GetEnumerator(BinaryTreeNode).ToArray();
            for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
            {
                array[i] = binaryCollection[j];
            }
        }

        public bool Remove(int item)
        {
            var binaryCollection = Enumerator.GetEnumerator(BinaryTreeNode).ToList();
            if (!binaryCollection.Contains(item))
            {
                return false;
            }

            binaryCollection.Remove(item);
            var binaryTree = binaryCollection.ToBinary<int>();
            _binaryTreeNode = binaryTree.BinaryTreeNode;
            Length--;
            return true;
        }

        private void AddNewItem(ref Node node, int item)
        {
            if (node == null)
            {
                node = new Node(item);
                return;
            }

            if (node.Value > item)
            {
                AddNewItem(ref node.left, item);
            }

            else
            {
                AddNewItem(ref node.right, item);
            }
        }

        private bool ContainsElement(Node node, int item)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value == item)
            {
                return true;
            }

            else if (node.Value > item)
            {
                return ContainsElement(node.left, item);
            }

            else
            {
                return ContainsElement(node.right, item);
            }
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            if (Enumerator == null)
            {
                throw new Exception("Enumerator for BinaryTree can't be null");
            }

            return Enumerator.GetEnumerator(BinaryTreeNode).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<int>).GetEnumerator();
        }
    }
}
