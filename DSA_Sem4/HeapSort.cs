using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class HeapSort
    {
        static void Heapify(int[] array,int n, int rootNode)
        {
            int largestValueNode = rootNode; // assume root node is the largest
            int leftNode = 2 * rootNode + 1; // give left and right nodes values accordingly (2n + 1 and 2n + 2)
            int rightNode = 2 * rootNode + 2;

            if (leftNode < n && array[leftNode] > array[largestValueNode]) // if left node is larger and exists, set largest node to left node
                largestValueNode = leftNode;

            if (rightNode < n && array[rightNode] > array[largestValueNode]) // if right node is larger adn exists, set largest node to right node
                largestValueNode = rightNode;


            // if root node is not the largest node, replace it with the largest and apply max-heapify property on the largest value node
            if (largestValueNode != rootNode) 
            {
                int temp = array[rootNode];
                array[rootNode] = array[largestValueNode];
                array[largestValueNode] = temp;

                Heapify(array, n, largestValueNode);
            }

            
        }

        public static void Sort(int[] array)
        {
            int n = array.Length;

            // First heapify the array, we do this by running the following loop n/2 - 1 times (half the amount of elements)
            // as the final node above leaf nodes, having index 'i' will give 2i + 2 = n, which means n/2 - 1 = i and running
            // max-heapify on that node and all nodes behind it will certainly give a max-heap
            for (int i = n/2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // Starting from last index to first index, the array is heapified on each iteration and the last value is swapped with the first value
            // and then the array is heapified again except for the last element as that is already sorted and the largest value 
            // by doing this, the array gets sorted from behind
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // call max heapify on the reduced heap
                Heapify(array, i, 0);
            }
        }
    }
}
