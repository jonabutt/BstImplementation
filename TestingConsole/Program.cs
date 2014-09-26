using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BST_Implementation;
namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTreeInt bst = new BinarySearchTreeInt();
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.InsertUsingIterations(80);
            bst.InsertUsingIterations(20);
            bst.InsertUsingIterations(90);
            bst.InsertUsingIterations(80);
            bst.InsertUsingIterations(25);
            bst.InsertUsingIterations(340);
            bst.InsertUsingIterations(50);
            string userValue = Console.ReadLine();
            int val = Int32.Parse(userValue);
            if (bst.SeachUsingIteration(val))
                Console.WriteLine("Found");
            else
                Console.WriteLine("Not found");
            Console.ReadKey();
        }
    }
}
