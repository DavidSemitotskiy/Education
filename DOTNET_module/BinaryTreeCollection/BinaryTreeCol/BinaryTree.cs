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
        private int _length = 0;

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

        public int Count => _length;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddNewItem(ref _binaryTreeNode, item);
            _length++;
        }

        public void Clear()
        {
            _length = 0;
            _binaryTreeNode = null;
        }

        public bool Contains(T item)
        {
            return ContainsElement(BinaryTreeNode, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("array can't be null");
            }

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
            _length--;
            return true;
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
    }
}
