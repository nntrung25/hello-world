using System;

namespace nhap8
{
    class Program
    {
        static void Main(string[] args)
        {

            BinarySearchTree binaryTree = new BinarySearchTree();
            binaryTree.Insert(23);  binaryTree.Insert(16);   binaryTree.Insert(45); binaryTree.Insert(3);     
            binaryTree.Insert(22);  binaryTree.Insert(37);   binaryTree.Insert(99);
            Console.WriteLine("Max:"+binaryTree.FindMax());  //hoặc dùng binaryTree.FindMax2()   
            Console.WriteLine("Min:"+binaryTree.FindMin());  //hoặc dùng binaryTree.FindMin2()
            Node node = binaryTree.Find(5);
            int depth = binaryTree.GetTreeDepth();
            Console.WriteLine("\nPreOrder Traversal:");  binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine("\nInOrder Traversal:");   binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine("\nPostOrder Traversal:"); binaryTree.TraversePostOrder(binaryTree.Root);
            binaryTree.Remove(7); binaryTree.Remove(8);
            Console.WriteLine("\nPreOrder After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            

        }
    }
}
