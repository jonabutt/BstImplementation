using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public class BinarySearchTree<T> where T : IComparable<T>, IEquatable<T>
    {
        BstNode<T> root;

        private BstNode<T> CrateBsdNode(T data)
        {
            BstNode<T> newNode = new BstNode<T>()
            {
                data = data
            };
            return newNode;
        }
        public void Insert(T data)
        {
            root = Insert(root, data);
        }
        public bool Search(T data)
        {
            return Search(root, data);
        }
        private BstNode<T> Insert(BstNode<T> root, T data)
        {
            if (root == null)
            {
                root = CrateBsdNode(data);
            }
            else
            {
                if (data.CompareTo(root.data) <= 0)
                    // root.Value > data, therefore n must be added to the left subtree
                    root.left = Insert(root.left, data);
                else
                    // parent.Value < data, therefore n must be added to the right subtree
                    root.right = Insert(root.right, data);
            }
            return root;
        }

        public void InsertUsingIterations(T data)
        {
            BstNode<T> temp = root;
            while (temp != null)
            {
                if (data.CompareTo(temp.data) <= 0)
                {
                    if (temp.left == null)
                        break;
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                        break;
                    temp = temp.right;
                }
            }
            if (temp == null)
            {
                root = CrateBsdNode(data);
            }
            else if (data.CompareTo(temp.data) <= 0)
            {
                temp.left = CrateBsdNode(data);
            }
            else
            {
                temp.right = CrateBsdNode(data);
            }
        }

        public bool SeachUsingIteration(T data)
        {
            BstNode<T> temp = root;
            while (temp != null)
            {
                if (temp.data.CompareTo(data) == 0)
                    return true;
                else if (temp.data.CompareTo(data) == -1)
                    temp = temp.right;
                else
                    temp = temp.left;
            }
            return false;
        }


        private bool Search(BstNode<T> root, T data)
        {
            if (root == null) return false;
            else if (root.data.CompareTo(data) == 0) return true;
            else if (root.data.CompareTo(data) == -1) return Search(root.right, data);
            else return Search(root.left, data);
        }
    }

    public class BstNode<T>
    {
        public T data;
        public BstNode<T> left;
        public BstNode<T> right;
    }
}
