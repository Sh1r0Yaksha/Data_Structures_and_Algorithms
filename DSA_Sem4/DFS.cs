using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    // Graph traversal algorithm, 
    internal class DFS
    {
        // Method for calling DFS algorithm
        public static void DFSMethod(Graph graph)
        {
            bool[] visited = new bool[graph.adjListOfEachVertex.Length]; // Create an array of boolean to mark visited
            DFSRec(graph, 1, visited); // run DFS from first vertex
            
        }

        // 
        static void DFSRec(Graph graph,int sourceVertex, bool[] visited)
        {
            visited[sourceVertex] = true; // Mark the current vertex as visited
            Console.Write(sourceVertex + " -> "); // Print the current vertex
            
            // Checks if there are any edges of the current vertex if it does, runs DFS
            // Runs DFS on each edge of the current vertex if the adjacent vertex is not visited
            foreach (int vertex in graph.adjListOfEachVertex[sourceVertex])
            {
                if (!visited[vertex])
                    DFSRec(graph, vertex, visited);
            }
        }
    }
}
