using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class QuickSort
    {
        // Swaps 2 elements in an array
        static void Swap(int[] array, int p, int q)
        {
            int temp = array[p];
            array[p] = array[q];
            array[q] = temp;
        }

        // We partition the array in such a manner that the element at last index (can be any element) is taken as the pivot and all elements
        // smaller than it are put to the left and larger than it are put to the right
        static int Partition(int[] array, int startingIndex, int lastIndex)
        {
            int pivot = array[lastIndex]; // pivot as the last element

            int i = startingIndex - 1; // i is counting the number of swaps done as well as swapping elements at its index

            for (int j = startingIndex; j < lastIndex; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, lastIndex);

            return i + 1;
            // till now, we know that the element is (i + 1)th position is sorted and to its left are smaller elements and to its right are
            // larger elements
        }

        // Here we check if the conditions to stop infinite recursion and recursively partition the array around its pivot so that its sorted
        public static void Sort(int[] array, int startIndex, int lastIndex)
        {
            if (startIndex < lastIndex)
            {
                int partition = Partition(array, startIndex, lastIndex);

                // using quick sort on both the partitions
                Sort(array, startIndex, partition - 1);
                Sort(array, partition + 1, lastIndex);
            }
        }
    }
}
