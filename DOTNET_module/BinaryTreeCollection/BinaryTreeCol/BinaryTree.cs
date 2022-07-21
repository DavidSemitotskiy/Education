using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCol
{
    public class BinaryTree<T> : ICollection<T> where T: IComparable<T>
    {
        private int Length = 0;

        private Node<T> _binaryTreeNode;

        public BinaryTree(IBinaryTreeEnumerator<T> enumerator)
        {
            Enumerator = enumerator;
        }

        public Node<T> BinaryTreeNode
        {
            get
            {
                return _binaryTreeNode;
            }
        }

        public IBinaryTreeEnumerator<T> Enumerator { get; set; }

        public int Count => Length;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddNewItem(ref _binaryTreeNode, item);
            Length++;
        }

        public void Clear()
        {
            Length = 0;
            _binaryTreeNode = null;
        }

        public bool Contains(T item)
        {
            return ContainsElement(BinaryTreeNode, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var binaryCollection = Enumerator.GetEnumerator(BinaryTreeNode).ToArray();
            for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
            {
                array[i] = binaryCollection[j];
            }
        }

        public bool Remove(T item)
        {
            var binaryCollection = Enumerator.GetEnumerator(BinaryTreeNode).ToList();
            if (!binaryCollection.Contains(item))
            {
                return false;
            }

            binaryCollection.Remove(item);
            var binaryTree = binaryCollection.ToBinary();
            _binaryTreeNode = binaryTree.BinaryTreeNode;
            Length--;
            return true;
        }

        private void AddNewItem(ref Node<T> node, T item)
        {
            if (node == null)
            {
                node = new Node<T>(item);
                return;
            }

            if (node.Value.CompareTo(item) > 0)
            {
                AddNewItem(ref node.left, item);
            }

            else
            {
                AddNewItem(ref node.right, item);
            }
        }

        private bool ContainsElement(Node<T> node, T item)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(item) == 0)
            {
                return true;
            }

            else if (node.Value.CompareTo(item) > 0)
            {
                return ContainsElement(node.left, item);
            }

            else
            {
                return ContainsElement(node.right, item);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (Enumerator == null)
            {
                throw new Exception("Enumerator for BinaryTree can't be null");
            }

            return Enumerator.GetEnumerator(BinaryTreeNode).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }
    }
}
