using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{

    // Time complexity O(V^2)
    // Can be reduced to O(E logV) by using adjacency list and binary heap
    // Doesn't work with negative edges graph
    // For negative edges Bellman-Ford algo is used
    // Can be used for directed acyclic graphs (DAG) and undirected graphs
    internal class Dijkstra
    {

        // A method to get the index of the adjacent vertex with minimum distance
        static int MinDist(int[] dist, int vertices, bool[] visited)
        {
            int min = int.MaxValue, min_index = -1;

            for (int i = 0; i < vertices; i++)
            {
                if (visited[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }

        // Method for printing soln
        static void PrintSoln(int[] dist, int vertices)
        {
            Console.Write("Vertex \t\t Distance from source\n");
            for (int i = 0; i < vertices; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        // Method for running Dijkstra's algorithm
        public static void DijkstraMethod(int[, ] graph, int sourceVertex)
        {
            // no. of vertices
            int vertices = graph.GetLength(0);

            // an array which keeps track of distances of each vertex from the source
            int[] dist = new int[vertices];

            // boolean array which marks if a vertex is visited or not
            bool[] visited = new bool[vertices];

            // Initially set all distances to infinity and visited to false
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            // set distance of initial vertex as 0
            dist[sourceVertex] = 0;

            for (int count = 0; count < vertices - 1; count++)
            {
                // Index of vertex with minimum distance
                int u = MinDist(dist, vertices, visited);

                visited[u] = true;

                for (int v = 0; v < vertices; v++)
                {
                    // Optimal substructure property / Relaxation property
                    if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }

            PrintSoln(dist, vertices);
        }
    }
}
