using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    // For Krushal's algo
    // Time complexity O(ElogE) or O(ElogV)
    // Sorting of edges takes O(ELogE) time
    //  After sorting, we iterate through all edges and apply the find-union algorithm
    // The find and union operations can take at most O(ELogV)
    // Overall O(ElogE + ElogV)
    // Worst case O(V^2 logV)


    // For Prim's algo, time complexity is O(ElogV) with adjacency list and binary heap
    internal class MinimumSpanningTree
    {
    }
}
