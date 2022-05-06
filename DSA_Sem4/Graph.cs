using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    // Class for creating a graph
    // We are using a linked list of adjacent vertices of each vertex to form the graph
    internal class Graph
    {
        public int vertices;
        public List<int>[] adjListOfEachVertex; // Creating the linked list

        // Constructor for graph
        public Graph(int numOfVertices)
        {
            this.vertices = numOfVertices + 1;
            adjListOfEachVertex = new List<int>[this.vertices];
            for (int i = 0; i < this.vertices; i++)
            {
                adjListOfEachVertex[i] = new List<int>();
            }
            
        }

        // Method to add edge to a vertex
        public void AddDirectedEdge (int fromVertexIndex, int toVertexIndex)
        {
            // add the vertex we have to add to the list
            adjListOfEachVertex[fromVertexIndex].Add(toVertexIndex);
        }

        public void AddUndirectedEdge(int firstVertex, int secondVertex)
        {
            adjListOfEachVertex[firstVertex].Add(secondVertex);
            adjListOfEachVertex[secondVertex].Add(firstVertex);
        }

    }
}
