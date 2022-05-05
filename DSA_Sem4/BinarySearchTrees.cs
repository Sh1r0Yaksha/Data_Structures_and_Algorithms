using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    internal class BinarySearchTrees
    {      
        public class Node
        {
            public int key;
            public Node left;
            public Node right;

            public Node (int item)
            {
                key = item;
                left = right = null;
            }
        }

        public Node root;


        public BinarySearchTrees()
        {
            root = null;
        }

        public void Insert (int key)
        {
            root = InsertRec(root, key);
        }

        Node InsertRec(Node root, int key)
        {

            // If the tree is empty,
            // return a new node
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            // Otherwise, recur down the tree
            if (key < root.key)
                root.left = InsertRec(root.left, key);
            else if (key > root.key)
                root.right = InsertRec(root.right, key);

            // Return the (unchanged) node pointer
            return root;
        }

        public void Inorder()
        {
            InorderRec(root);
        }

        static void InorderRec(Node root)
        {
            if (root != null)
            {              
                InorderRec(root.left);

                Console.WriteLine(root.key);

                InorderRec(root.right);
            }
        }

        public void PreOrder()
        {
            PreOrderRec(root);
        }

        void PreOrderRec(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.key);

            PreOrderRec(root.left);

            PreOrderRec(root.right);
                
        }

        public Node Search(Node root, int key)
        {
            if (root == null || root.key == key)
                return root;

            else if (root.key < key)
                return Search(root.right, key);

            else
                return Search(root.left, key);
        }
    }

    

}
