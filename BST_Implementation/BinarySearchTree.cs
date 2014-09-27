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

        #region Interative Algorithms

        public void Insert(T data)
        {
            root = Insert(root, data);
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

        #endregion

        #region Recursive Algorithms

        #endregion

        private BstNode<T> CrateBsdNode(T data)
        {
            BstNode<T> newNode = new BstNode<T>()
            {
                data = data
            };
            return newNode;
        }

        public bool Search(T data)
        {
            return Search(root, data);
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

        public T Min()
        {
            if (root == null)
                throw new InvalidOperationException("Min function not possible when tree is empty.");
            BstNode<T> tempNode = root;
            while (tempNode.left != null)
            {
                tempNode = tempNode.left;
            }
            return tempNode.data;
        }

        public T Max()
        {
            BstNode<T> tempNode = root;
            while (tempNode.right != null)
            {
                tempNode = tempNode.right;
            }
            return tempNode.data;
        }


        public T MaxRecursion()
        {
            return MaxRecursion(root);
        }

        private T MaxRecursion(BstNode<T> myNode)
        {
            if (root == null)
                throw new InvalidOperationException("Max function not possible when tree is empty.");
            if (myNode.right != null)
                return MaxRecursion(myNode.right);
            return myNode.data;
        }

        public int FindHeight()
        {
            return FindHeight(root);
        }
        private int FindHeight(BstNode<T> myNode)
        {
            if (myNode == null)
                return -1;
            return Math.Max(FindHeight(myNode.left), FindHeight(myNode.right)) + 1;
        }


        private bool Search(BstNode<T> root, T data)
        {
            if (root == null) return false;
            else if (root.data.CompareTo(data) == 0) return true;
            else if (root.data.CompareTo(data) == -1) return Search(root.right, data);
            else return Search(root.left, data);
        }



        public string LevelOrder()
        {
            string printData = "";
            if (root == null) return "";
            Queue<BstNode<T>> myNodes = new Queue<BstNode<T>>();
            myNodes.Enqueue(root);
            while (myNodes.Count != 0)
            {
                BstNode<T> current = myNodes.Peek();
                printData += current.data.ToString() + " ";
                if (current.left != null) myNodes.Enqueue(current.left);
                if (current.right != null) myNodes.Enqueue(current.right);
                myNodes.Dequeue(); //removing the element at front
            }
            return printData;
        }

        public string printPreOrderTraversal = "";

        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(BstNode<T> root)
        {
            if (root == null) return;
            printPreOrderTraversal += root.data.ToString();
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        public string resultInOrder = "";

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(BstNode<T> root)
        {
            if (root == null) return;
            InOrderTraversal(root.left);
            resultInOrder += root.data.ToString() + " ";
            InOrderTraversal(root.right);
        }

        public string resultPostOrder = "";

        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
        }

        private void PostOrderTraversal(BstNode<T> root)
        {
            if (root == null) return;
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            resultPostOrder += root.data.ToString() + " ";
            
        }

    }

    public class BstNode<T>
    {
        public T data;
        public BstNode<T> left;
        public BstNode<T> right;
    }
}
