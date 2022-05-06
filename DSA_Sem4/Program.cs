using System;

namespace DSA_Sem4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Initializing array
            int[] testArray = {4,2,9,1,5,6,3,7,8};
            int[] temp = new int[testArray.Length];
            ReplaceArray(testArray, temp);

            // Printing original array
            Console.WriteLine("The original array: ");
            PrintArray(testArray);
            
            // Bubble sort
            Console.WriteLine("\n\nBubble sort: ");
            BubbleSort.BubbleSortMethod(testArray);
            PrintArray(testArray);

            // Binary search
            ReplaceArray(temp, testArray);
            Console.WriteLine("\n\nBinary search:");
            Console.WriteLine(BinarySearch.BinarySearchMethod(2, testArray, 0, testArray.Length - 1));

            // Insertion sort
            ReplaceArray(temp, testArray);
            Console.WriteLine("\n\nInsertion sort:");
            InsertionSort.InsertionSortMethod(testArray);
            PrintArray(testArray);

            // Merge sort
            ReplaceArray(temp, testArray);
            Console.WriteLine("\n\nMergeSort: ");
            MergeSort.Sort(testArray, 0, testArray.Length - 1);
            PrintArray(testArray);

            // Heap sort
            ReplaceArray(temp, testArray);
            Console.WriteLine("\n\nHeapSort: ");
            HeapSort.Sort(testArray);
            PrintArray(testArray);

            // Quick sort
            ReplaceArray(temp, testArray);
            Console.WriteLine("\n\nQuickSort: ");
            QuickSort.Sort(testArray, 0, testArray.Length - 1);
            PrintArray(testArray);

            // BST
            BinarySearchTrees bst = new BinarySearchTrees();
            ReplaceArray(temp, testArray);

            // Inserting elements in BST
            for (int i = 0; i < testArray.Length; i++)
            {
                bst.Insert(testArray[i]);
            }


            // BST Inorder traversal
            Console.WriteLine("\n\nBST inorder traversal: ");
            bst.Inorder();

            // BST Preorder traversal
            Console.WriteLine("\n\nBST preorder traversal: ");
            bst.PreOrder();

            // BST Postorder traversal
            Console.WriteLine("\n\nBST postorder traversal: ");
            bst.PostOrder();

            // BST search
            Console.WriteLine("\n\nBST search for 11: ");
            if (bst.Search(bst.root, 11) != null)
                Console.WriteLine("It exists!");
            else
                Console.WriteLine("It doesn't exist");
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
                Console.WriteLine(i);
        }

        static void ReplaceArray(int[] sourceArray, int[] targetArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = sourceArray[i];
            }
        }
    }
}