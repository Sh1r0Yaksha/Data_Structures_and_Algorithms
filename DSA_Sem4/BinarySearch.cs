using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class BinarySearch
    {
        public static int BinarySearchMethod(int toFind, int[] array, int startIndex, int lastIndex)
        {
            int middleIndex = (startIndex + lastIndex) / 2;

            if (toFind == array[middleIndex])
                return middleIndex + 1;

            else if (toFind > array[middleIndex]) // searches to the right
                return BinarySearchMethod(toFind, array, middleIndex + 1, lastIndex);
            else // searches to the left
                return BinarySearchMethod(toFind, array, startIndex, middleIndex);
        }
    }
}
