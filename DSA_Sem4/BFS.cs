using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class BFS
    {

        // Method to call BFS on a graph and its vertex
        public static void BFSMethod(Graph graph, int startIndex)
        {
            bool[] visited = new bool[graph.adjListOfEachVertex.Length];

            // set all vertex to not visited
            for (int i = 0; i < graph.adjListOfEachVertex.Length; i++)
            {
                visited[i] = false;
            }

            // run BFS method
            BFSRec(graph,startIndex,visited);
        }

        // Main method that runs BFS
        static void BFSRec(Graph graph, int startIndex, bool[] visited)
        {
            // Making a queue as a linked list
            LinkedList<int> queue = new LinkedList<int>();

            visited[startIndex] = true; // set the first vertex to visited

            queue.AddFirst(startIndex); // add this vertex to the queue

            // as long as there are items in the queue, this loop will run
            while (queue.Any()) 
            {
                // add the first element of the queue to be looked for BFS
                int s = queue.First();
                Console.Write(s + " -> ");
                queue.RemoveFirst();

                // search for all the adjacent elements of first element of queue until they are visited and add them to queue
                foreach (int vertex in graph.adjListOfEachVertex[s])
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        queue.AddLast(vertex); 
                    }
                }
            }
        }
    }
}
