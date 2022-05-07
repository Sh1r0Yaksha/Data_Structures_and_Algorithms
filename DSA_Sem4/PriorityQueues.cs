using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class PriorityQueues
    {

        public class Node
        {
            public int data;
            public int priority;
            public Node next;

            public Node(int data, int priority)
            {
                this.data = data;
                this.priority = priority;
                next = null;
            }
        }
        public Node head = null;

        public int Peek()
        {
            return head.data;
        }

        public Node Pop()
        {
            Node temp = head;
            head = head.next;
            return temp;
        }

        public void Push(int data, int priority)
        {
            if (head == null)
                head = new Node(data, priority);

            else
            {
                Node start = head;

                Node temp = new Node(data, priority);
                temp.next = null;

                if (head.priority < priority)
                {
                    temp.next = head;
                    head = temp;
                }

                else
                {
                    while (start.next != null && start.next.priority > priority)
                    {
                        start = start.next;
                    }

                    temp.next = start.next;
                    start.next = temp;
                }

            }
        }
    }
}
