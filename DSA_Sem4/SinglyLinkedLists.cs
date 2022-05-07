using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class SinglyLinkedLists
    {
        // Creating nodes as classes
        public class SinglyNode
        {
            // Each node has 2 properties, the data inside it and the next node
            public int data;
            public SinglyNode next;

            public SinglyNode(int data)
            {
                this.data = data;
                next = null;
            }
        }

        // Creating the head node of the linked list
        public SinglyNode head = null;       

        // Append means adding to the rear of linked list (after last node)
        public void SinglyAppend(int data)
        {
            // We just check if the head is not null, and add our data to the head if it is
            if (head == null)
            {
                head = new SinglyNode(data);
            }

            
            else
            {
                // Create a temporary node with the data
                SinglyNode newNode = new SinglyNode(data);

                // Make next node of the temp node null
                newNode.next = null;

                // Assume head is the last node
                SinglyNode last = head;

                // Loop through the next nodes until the last node is reached
                while (last.next != null)
                {
                    last = last.next;
                }

                // Add our temporary node as the next node of the last node
                last.next = newNode;
            }

            
        }

        // Push means adding value to the front of linked list (before head)
        public void SinglyPush(int data)
        {
            // Make a temporary node with the data
            SinglyNode node = new SinglyNode(data);

            // Make the head node the next node of our temporary node
            node.next = head;

            // Make the temp node the head node
            head = node;
        }

        // To insert after a certain node if it exists
        public void SinglyInsertAfter(SinglyNode prevNode, int data)
        {
            // Check if the node exists
            if (prevNode == null)
            {
                Console.WriteLine("Node doesn't exist");
                return;
            }

            else
            {
                // Make a temp node with data
                SinglyNode node = new SinglyNode(data);

                // Make next node of our temp node the next node of our previous node after which we have to insert it
                node.next = prevNode.next;

                // Make our temporary node the next node of the previous node
                prevNode.next = node;
            }
        }


        // Method to call the traverse linked list function
        public void TraverseSingly()
        {
            TraverseSinglyRec(head);
        }

        // Main method to call traverse function
        void TraverseSinglyRec(SinglyNode node)
        {
            // We give a node and it checks if the node is not null
            if (node != null)
            {
                // If not null, traverses to the next node of our current node recursively
                Console.Write(node.data + " -> ");
                TraverseSinglyRec(node.next);
            }
        }
    }
}
