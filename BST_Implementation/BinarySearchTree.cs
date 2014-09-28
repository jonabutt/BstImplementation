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

        #region Recursive Algorithms

        //Wrapper method for insert method using recursion
        public void Insert(T data)
        {
            //Calling the Insert method and updating the root variable
            root = Insert(root, data);
        }

        private BstNode<T> Insert(BstNode<T> root, T data)
        {
            //Check if the tree is empty
            if (root == null)
            {
                //Create a new node to be set as the root variable
                root = CrateBsdNode(data);
            }
            else
            {
                //Check the data that is going to be inserted is lower then current node 
                if (data.CompareTo(root.data) <= 0)
                    // data <= root.value , therefore go the left subtree
                    root.left = Insert(root.left, data);
                //This eslse statements means the value that going to be inserted is bigger than current node
                else
                    // data > root.value, therefore go the right subtree
                    root.right = Insert(root.right, data);
            }
            return root;
        }

        //Wrapper method for the search function that uses recursions
        public bool Search(T data)
        {
            return Search(root, data);
        }

        //The recursive search method
        private bool Search(BstNode<T> root, T data)
        {
            //Returns false when the you traverse a node that is null,therefore there is no element same as the data in there tree 
            //Also returns false when tree is empty.
            if (root == null) return false;
            //CompareTo to returns a 0 when the compared data are the same, therefore the data was found in the tree
            else if (root.data.CompareTo(data) == 0) return true;
            //ComaperTo returns less the -1 when the first value (root.data) is smaller than value in method paramater (data)
            //Therefore the data > than root.data, this means you need to go the right subtree
            else if (root.data.CompareTo(data) <= -1) return Search(root.right, data);
            //This else statments means NOT 0 and NOT -1, therefore this means higher than 1
            //data < than root.data , this means you need to go the left subtree
            else return Search(root.left, data);
        }

        //Wrapper function for the max function that uses recursion
        public T MaxUsingRecursion()
        {
            //Check if the tree is empty and throw an exception 
            if (root == null)
                throw new InvalidOperationException("Max function not possible when tree is empty.");
            //Calling the recursive function to find max value
            return MaxUsingRecursion(root);
        }

        //The max function that uses recursion to traverse the tree
        private T MaxUsingRecursion(BstNode<T> myNode)
        {
            //Check if current right subtree of the current node is not null
            if (myNode.right != null)
                //recursive call with the right subtree
                return MaxUsingRecursion(myNode.right);
            //return the data after finish the recursion
            return myNode.data;
        }

        #endregion

        #region Interative Algorithms

        public void InsertUsingIterations(T data)
        {
            //Setting the temp variable to root to start the traversing on the root node
            BstNode<T> temp = root;
            //Check if tree is empty, if not start traversing 
            while (temp != null)
            {
                //data <= then temp.data, therefore check the left subtee
                if (data.CompareTo(temp.data) <= 0)
                {
                    //Check if the left subtree is null, therefore no more traversing
                    if (temp.left == null)
                        break;
                    //change the temp variable to temp.left to traverse to the left subtree
                    temp = temp.left;
                }
                //data > then temp.data, there check the right subtree
                else
                {
                    //Check if the right subtree is null, there no more travesing
                    if (temp.right == null)
                        break;
                    //change the temp varaible to temp.right to trave to the right subtree
                    temp = temp.right;
                }
            }
            //Check if the tree is empty
            if (temp == null)
            {
                //if the tree is empty create a new node and set it as root
                root = CrateBsdNode(data);
            }
            //data <= temp.data, therfore create a new node to left
            else if (data.CompareTo(temp.data) <= 0)
            {
                temp.left = CrateBsdNode(data);
            }
            //data > temp.data, therefore create a node to right
            else
            {
                temp.right = CrateBsdNode(data);
            }
        }

        //This search method uses iterations to traverse through the tree
        public bool SeachUsingIteration(T data)
        {
            //Setting a temp variable by begining it as root
            BstNode<T> temp = root;
            //Thes while loop is used to traverse through the tree
            while (temp != null)
            {
                //CompareTo returns 0 when the two values are the same
                //If the seached data is same as the node it will return true
                if (temp.data.CompareTo(data) == 0)
                    return true;
                //temp.Data < data
                else if (temp.data.CompareTo(data) <= -1)
                    //Change the temp variable to the right subtree
                    temp = temp.right;
                //temp.Data > data
                else
                    //Change the temp varaible to the left subtree
                    temp = temp.left;
            }
            return false;
        }

        //This min method uses a loop to traverse through the tree
        public T Min()
        {
            //Check if the tree is empty throw exception
            if (root == null)
                throw new InvalidOperationException("Min function not possible when tree is empty.");
            //Setting a temp variable to be using with the loop
            BstNode<T> tempNode = root;
            //Check if the left subtree is NOT empty 
            while (tempNode.left != null)
            {
                //Traverse to the left subtree
                tempNode = tempNode.left;
            }
            return tempNode.data;
        }

        //This max method usese a loop to traverse through the tree
        public T Max()
        {
            //Check if the tree is empty throw exception
            if (root == null)
                throw new InvalidOperationException("Min function not possible when tree is empty.");
            //Setting a temp variable to be using with the loop
            BstNode<T> tempNode = root;
            //Check if the right subtree is NOT empty 
            while (tempNode.right != null)
            {
                //Traverse to the left subtree
                tempNode = tempNode.right;
            }
            return tempNode.data;
        }

        #endregion

        //Used to create a node that is used in the BST
        private BstNode<T> CrateBsdNode(T data)
        {
            //Create a new instance of the BstNode
            BstNode<T> newNode = new BstNode<T>()
            {
                //Setting the data in the new node
                data = data
            };
            return newNode;
        }

        //Method wrapper that uses the a recursive method for height of tree
        public int FindHeight()
        {

            //calling the recursive method for FindHeight
            return FindHeight(root);
        }

        //The recursive method to find height of the tree
        private int FindHeight(BstNode<T> myNode)
        {
            //Check if the current node is empty
            if (myNode == null)
                //return -1 when tree is empty
                return -1;
            //Get the highest value from the right subtree and the left subtree and add +1
            return Math.Max(FindHeight(myNode.left), FindHeight(myNode.right)) + 1;
        }

        //Level order means the tree will travesed as breath first,
        //Breath first - visit all nodes as the same depth starting from root
        public string LevelOrder()
        {
            //this variable used to save the results from this function
            string printData = "";
            //check if root is null, therefore the tree is null
            if (root == null) return printData;
            //Create a queue which saves the nodes
            Queue<BstNode<T>> myNodes = new Queue<BstNode<T>>();
            //Enqueue the root node
            myNodes.Enqueue(root);
            //Check if there is more than one nodes in the queue
            while (myNodes.Count != 0)
            {
                //Remove the first node from queue and returning save it as current ndoe
                BstNode<T> current = myNodes.Dequeue();
                //Modify the print data with the current data
                printData += current.data.ToString() + " ";
                //Check if there is a left subtree to the current node
                if (current.left != null)
                    //Enqueue the left node into the queue
                    myNodes.Enqueue(current.left);
                //Check if there is a right subtree to the current node
                if (current.right != null)
                    //Enqueue the right node into the queue
                    myNodes.Enqueue(current.right);
            }
            return printData;
        }

        //Wrapper method for the PreOrderTraversal recursive method 
        //<root><left><right>
        public string PreOrderTraversal()
        {
            //String builder used for result
            StringBuilder sb = new StringBuilder();
            //calling the recursive method
            PreOrderTraversal(root, sb);
            return sb.ToString();
        }

        //Recursive method for PreOrderTravesal
        private void PreOrderTraversal(BstNode<T> root, StringBuilder sb)
        {
            //check if the node is null, is true when there no substrees left or tree is empty
            if (root == null) return;
            //append the data to string builder
            sb.Append(root.data.ToString() + " ");
            //traverse to the left subtree
            PreOrderTraversal(root.left, sb);
            //traverse to the right subtree
            PreOrderTraversal(root.right, sb);
        }

        //Wrapper method for the InOrderTraversal recursive method 
        //<left><root><right>
        public string InOrderTraversal()
        {
            //String builder used for result
            StringBuilder sb = new StringBuilder();
            //calling the recursive method
            InOrderTraversal(root, sb);
            return sb.ToString();
        }

        //Recursive method for InOrderTraversal
        private void InOrderTraversal(BstNode<T> root, StringBuilder sb)
        {
            //check if the node is null, is true when there no substrees left or tree is empty
            if (root == null) return;
            //traverse to the left subtree
            InOrderTraversal(root.left, sb);
            //append the data to string builder
            sb.Append(root.data.ToString() + " ");
            //traverse to the right subtree
            InOrderTraversal(root.right, sb);
        }

        //Wrapper method for the PostOrderTraversal recursive method 
        //<left><right><root>
        public string PostOrderTraversal()
        {
            //String builder used for result
            StringBuilder sb = new StringBuilder();
            //calling the recursive method
            PostOrderTraversal(root, sb);
            return sb.ToString();
        }

        //Recursive method for PostOrderTraversal
        private void PostOrderTraversal(BstNode<T> root, StringBuilder sb)
        {
            //check if the node is null, is true when there no substrees left or tree is empty
            if (root == null) return;
            //traverse to the left subtree
            PostOrderTraversal(root.left, sb);
            //traverse to the right subtree
            PostOrderTraversal(root.right, sb);
            //append the data to string builder
            sb.Append(root.data.ToString() + " ");
        }

        //Wrapper method for the DeleteNode recursive method
        public void DeleteNode(T data)
        {
            DeleteNode(root, data);
        }

        //The recusrive method for DeleteNode
        private BstNode<T> DeleteNode(BstNode<T> root, T data)
        {
            //Check if the current node is empty
            if (root == null) return null;
            //Check if root.data > data, therefore traverse to left subtree
            else if (root.data.CompareTo(data) >= 1)
                root.left = DeleteNode(root.left, data);
            //Check if root.data < data, therefore traverse to right subtree
            else if (root.data.CompareTo(data) <= -1)
                root.right = DeleteNode(root.right, data);
            //Else statment when the data and current node are the same
            else
            {
                //Check if the current node has any children, therefore clear the current node
                if (root.left == null && root.right == null)
                {
                    //remove the current node
                    root = null;
                    return root;
                }
                //left subtree == null
                else if (root.left == null)
                {
                    //temp variable for current node
                    BstNode<T> tempNode = root;
                    //the current node will be changed for the right subtree
                    root = root.right;
                    return root;
                }
                //right subtree == null
                else if (root.right == null)
                {
                    //temp variable for current node
                    BstNode<T> tempNode = root;
                    //the current node will be changed for the left subtree
                    root = root.left;
                    return root;
                }
                //Else when there is right subtree and also a left subtree
                else
                {
                    //tempnode for the right subtree
                    BstNode<T> tempNode = root.right;
                    //traverse the subtree to get the lowest node of right subtree
                    while (tempNode.left != null)
                    {
                        tempNode = tempNode.left;
                    }
                    //the root data will be changed to the one from the lowest value of right tree
                    root.data = tempNode.data;
                    //recursive call the right subtree to delete the node that was taken place the deleted node
                    root.right = DeleteNode(root.right, tempNode.data);
                }
            }
            return root;
        }

        //Wrapper method for GetSuccessor recursive method
        public T GetSuccessor(T data)
        {
            //Return the successor data by calling the recursive method
            return GetSuccessor(root, data).data;
        }

        //Recuresive method for GetSuccessor
        private BstNode<T> GetSuccessor(BstNode<T> root, T data)
        {
            BstNode<T> currentNode = FindNode(root, data);
            if (currentNode == null) return null;
            //Case 1: Node has right subtree
            if (currentNode.right != null)
            {
                BstNode<T> tempNode = currentNode.right;
                while (tempNode.left != null)
                {
                    tempNode = tempNode.left;
                }
                return tempNode;
            }
            else
            {
                BstNode<T> successorNode = null;
                BstNode<T> ancestorNode = root;
                while (ancestorNode != currentNode)
                {
                    if (currentNode.data.CompareTo(ancestorNode.data) <= -1)
                    {
                        successorNode = ancestorNode;
                        ancestorNode = ancestorNode.left;
                    }
                    else
                    {
                        //there is no need to put successorNode = ancestoreNode becuase your are traversing to the right and the parent node will be smaller the current
                        ancestorNode = ancestorNode.right;
                    }
                }
                return successorNode;
            }
        }

        //Method used to return a node using data
        private BstNode<T> FindNode(BstNode<T> root, T data)
        {
            if (root == null) return null;
            else if (root.data.CompareTo(data) == 0) return root;
            else if (root.data.CompareTo(data) == -1) return FindNode(root.right, data);
            else return FindNode(root.left, data);
        }

    }

    public class BstNode<T>
    {
        public T data;
        public BstNode<T> left;
        public BstNode<T> right;
    }
}
