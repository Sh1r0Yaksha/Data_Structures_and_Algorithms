using System;

namespace DSA_Sem4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = {1,2,9,4,5,6,3,7,8};
            int[] temp = testArray;

            Console.WriteLine("Bubble sort: ");
            BubbleSort.BubbleSortMethod(testArray);
            PrintArray(testArray);

            Console.WriteLine("\n\nBinary search:");
            Console.WriteLine(BinarySearch.BinarySearchMethod(9, testArray, 0, testArray.Length - 1));

            testArray = temp;
            Console.WriteLine("\n\nInsertion sort:");
            InsertionSort.InsertionSortMethod(testArray);
            PrintArray(testArray);

            testArray = temp;
            Console.WriteLine("\n\nMergeSort: ");
            MergeSort.Sort(testArray, 0, testArray.Length - 1);
            PrintArray(testArray);

            testArray = temp;
            Console.WriteLine("\n\nHeapSort: ");
            HeapSort.Sort(testArray);
            PrintArray(testArray);

            testArray = temp;
            Console.WriteLine("\n\nQuickSort: ");
            QuickSort.Sort(testArray, 0, testArray.Length - 1);
            PrintArray(testArray);

            BinarySearchTrees bst = new BinarySearchTrees();
            testArray = temp;
            for (int i = 0; i < testArray.Length; i++)
            {
                bst.Insert(testArray[i]);
            }
            Console.WriteLine("\n\nBST inorder traversal: ");
            bst.Inorder();

            Console.WriteLine("\n\nBST search for 11: ");

            if (bst.Search(bst.root, 11) != null)
                Console.WriteLine("It exists!");
            else
                Console.WriteLine("It doesn't exist");

            Console.WriteLine("\n\nBST preorder traversal: ");
            bst.PreOrder();

            BinarySearchTrees bt = new BinarySearchTrees();
            bt.root = new BinarySearchTrees.Node(38);
            bt.root.left = new BinarySearchTrees.Node(28);
            bt.root.right = new BinarySearchTrees.Node(48);
            bt.root.left.left = new BinarySearchTrees.Node(23);
            bt.root.left.right = new BinarySearchTrees.Node(33);
            bt.root.left.left.left = new BinarySearchTrees.Node(13);
            bt.root.left.left.right = new BinarySearchTrees.Node(26);
            bt.root.right.left = new BinarySearchTrees.Node(43);
            bt.root.right.right = new BinarySearchTrees.Node(58);
            bt.root.right.right.left = new BinarySearchTrees.Node(53);
            bt.root.right.right.right = new BinarySearchTrees.Node(68);

            Console.WriteLine("\n\nBST preorder traversal: ");
            bt.PreOrder();

            Console.WriteLine("\n\nBST inorder traversal: ");
            bt.Inorder();
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
                Console.WriteLine(i);
        }
    }
}