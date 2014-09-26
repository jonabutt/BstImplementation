using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Implementation
{
    public class BinarySearchTreeInt
    {
        public BstNode root = null;

        private BstNode CrateBsdNode(int data)
        {
            BstNode newNode = new BstNode()
            {
                data = data,
                left = null,
                right = null
            };
            return newNode;
        }
        public void Insert(int data)
        {
            root = Insert(root, data);
        }
        public bool Search(int data)
        {
            return Search(root, data);
        }
        private BstNode Insert(BstNode root, int data)
        {
            if (root == null)
            {
                root = CrateBsdNode(data);
            }
            else
            {
                int result = data.CompareTo(root.data);
                if (result >= 0)
                    // root.Value > data, therefore n must be added to the left subtree
                    root.left = Insert(root.left, data);
                else
                    // parent.Value < data, therefore n must be added to the right subtree
                    root.right = Insert(root.right, data);
            }
            return root;
        }

        private bool Search(BstNode root, int data)
        {
            if (root == null) return false;
            else if (root.data.CompareTo(data) == 0) return true;
            else if (root.data.CompareTo(data) == -1) return Search(root.left, data);
            else return Search(root.right, data);
        }

    }

    public class BstNode
    {
        public int data;
        public BstNode left;
        public BstNode right;
    }

}
