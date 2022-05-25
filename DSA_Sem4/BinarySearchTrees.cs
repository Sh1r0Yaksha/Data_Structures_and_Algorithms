using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{

   
    internal class BinarySearchTrees
    {      
        // Creating nodes as classes, can be made as structures in functional languages like C
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

        // Assigning root node to the BST
        public Node root;

        // Constructor for BST, used to call in programs
        public BinarySearchTrees()
        {
            root = null;
        }

        // Method to call the insert function, key is the value to insert in the bst
        public void Insert (int key)
        {
            root = InsertRec(root, key); // Whenever Insert is called, it will run the insert method on root node
        }

        // The method that inserts a key to the given root
        protected virtual Node InsertRec(Node root, int key)
        {

            // If the node doesn't exists, creates a new node and inserts the key value on the node
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            // If root node exists, checks if the key to add is greater than or less than the key of root, and places
            // it accordingly to the left or right of the root node
            else
            {
                if (key < root.key)
                    root.left = InsertRec(root.left, key); // the new root node has become the left node if key is smaller
                else if (key > root.key)
                    root.right = InsertRec(root.right, key);// the new root node has become the right node if key is larger

                return root;
            }
            
        }

        // Method to call the inorder traversal function
        public void Inorder()
        {
            InorderRec(root); // runs inorder traversal on root node of bst
        }

        // The method prints the keys in inorder way, i.e. first prints the left node, then root node and then right node
        void InorderRec(Node root)
        {
            // Checks if root exists, then recursively runs the inorder traversal steps
            if (root != null)
            {              
                InorderRec(root.left);
                Console.WriteLine(root.key);
                InorderRec(root.right);
            }
        }

        // Method to call the preorder traversal function
        public virtual void PreOrder()
        {
            PreOrderRec(root);
        }

        // The method prints the keys in preorder way, i.e. first prints the root node, then left node and then right node
        public void PreOrderRec(Node root)
        {
            // Checks if root exists, then recursively runs the preorder traversal steps
            if (root != null)
            {
                Console.WriteLine(root.key);
                PreOrderRec(root.left);
                PreOrderRec(root.right);
            }                          
        }

        // Method to call the postorder traversal function
        public void PostOrder()
        {
            PostOrderRec(root);
        }
        // The method prints the keys in preorder way, i.e. first prints the left node, then right node and then root node
        void PostOrderRec(Node root)
        {
            // Checks if root exists, then recursively runs the postorder traversal steps
            if (root != null)
            {
                PostOrderRec(root.left);
                PostOrderRec(root.right);
                Console.WriteLine(root.key);
            }            
        }

        // Method to search for a key in the BST, it is like the binary search operation where we compare the value to
        // search with the key of root node and go left or rightacoording to value is s
        public Node Search(int key)
        {
            return SearchRec(root, key);
        }

        protected virtual Node SearchRec(Node root, int key)
        {
            if (root == null || root.key == key)
                return root;

            else if (root.key < key)
                return SearchRec(root.right, key);

            else
                return SearchRec(root.left, key);
        }
    }

    

}
