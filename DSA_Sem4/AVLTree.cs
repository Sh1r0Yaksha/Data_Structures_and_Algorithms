using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    // Both red-black tree and AVL tree uses rotation for self-balancing 
    // AVL tree also uses height checking for self-balancing unlike Red-black tree which uses painting nodes

    // AVL tree has better search time
    // For insertion and deletion, RB tree is preffered 

    // O(n) space complexity
    // O(log n) time complexity of runtime 
    internal class AVLTree
    {

        public class Node
        {
            public int key;
            public int height;
            public Node left;
            public Node right;

            public Node(int item)
            {
                key = item;
                height = 1;
                left = right = null;
            }
        }

        Node root;
        

        int Height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }

        // A utility function to get
        // maximum of two integers
        int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        Node MinValueNode(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
                current = current.left;

            return current;
        }

        Node RightRotate(Node y)
        {           
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation
            x.right = y;          
            y.left = T2;            

            // Update heights
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;

            // Return new root           
            return x;
        }

        // A utility function to left
        // rotate subtree rooted with x
        // See the diagram given above.
        Node? LeftRotate(Node x)
        {
            Node? y = x.right;
            Node? T2 = y.left;

            // Perform rotation
            y.left = x;
            x.right = T2;

            // Update heights
            x.height = Max(Height(x.left),
                        Height(x.right)) + 1;
            y.height = Max(Height(y.left),
                        Height(y.right)) + 1;


            // Return new root
            return y;
        }

        int GetBalance(Node N)
        {
            if (N == null)
                return 0;

            return Height(N.left) - Height(N.right);
        }

        public void Insert(int key)
        {
            root = InsertRec(root, key);
        }


        Node InsertRec(Node node, int key)
        {
            if (this.root == null)
                return (new Node(key));

            Node parent;

            if (node == null)
                return (new Node(key));

            
            if (key < node.key)
            {
                parent = node;
                node.left = InsertRec(node.left, key);
            }
            else if (key > node.key)
            {
                parent = node;
                node.right = InsertRec(node.right, key);
            }
            else // Duplicate keys not allowed
                return node;

            /* 2. Update height of this ancestor node */
            node.height = 1 + Max(Height(node.left),
                                Height(node.right));

            /* 3. Get the balance factor of this ancestor
                node to check whether this node became
                unbalanced */
            int balance = GetBalance(node);

            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && key < node.left.key)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && key > node.right.key)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && key > node.left.key)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key < node.right.key)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }

        public void Delete(int key)
        {
            root = DeleteUtil(root, key);
        }

        Node DeleteUtil(Node root, int key)
        {
            // STEP 1: PERFORM STANDARD BST DELETE
            if (root == null)
                return root;

            // If the key to be deleted is smaller than
            // the root's key, then it lies in left subtree
            if (key < root.key)
                root.left = DeleteUtil(root.left, key);

            // If the key to be deleted is greater than the
            // root's key, then it lies in right subtree
            else if (key > root.key)
                root.right = DeleteUtil(root.right, key);

            // if key is same as root's key, then this is the node
            // to be deleted
            else
            {

                // node with only one child or no child
                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (root.left == null)
                        temp = root.right;
                    else if (root.right == null)
                        temp = root.left;

                    // No child case
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else // One child case
                        root = temp; // Copy the contents of
                                     // the non-empty child
                }
                else
                {

                    // node with two children: Get the inorder
                    // successor (smallest in the right subtree)
                    Node temp = MinValueNode(root.right);

                    // Copy the inorder successor's data to this node
                    root.key = temp.key;

                    // Delete the inorder successor
                    root.right = DeleteUtil(root.right, temp.key);
                }
            }

            // If the tree had only one node then return
            if (root == null)
                return root;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE
            root.height = Max(Height(root.left),
                        Height(root.right)) + 1;

            // STEP 3: GET THE BALANCE FACTOR
            // OF THIS NODE (to check whether
            // this node became unbalanced)
            int balance = GetBalance(root);

            // If this node becomes unbalanced,
            // then there are 4 cases
            // Left Left Case
            if (balance > 1 && GetBalance(root.left) >= 0)
                return RightRotate(root);

            // Left Right Case
            if (balance > 1 && GetBalance(root.left) < 0)
            {
                root.left = LeftRotate(root.left);
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(root.right) <= 0)
                return LeftRotate(root);

            // Right Left Case
            if (balance < -1 && GetBalance(root.right) > 0)
            {
                root.right = RightRotate(root.right);
                return LeftRotate(root);
            }

            return root;
        }

        public Node Find(int key)
        {
            bool isFound = false;
            Node node = root;
            while (!isFound)
            {
                if (node == null)
                    break;

                if (key < node.key)
                    node = node.left;
                else if (key > node.key)
                    node = node.right;
                else
                {
                    isFound = true;
                }
            }

            if (isFound)
                return node;
            else
                return null;
        }

        public Node FindParent(int key)
        {
            bool isFound = false;
            Node node = root;
            Node parent = null;
            while (!isFound)
            {
                if (node == null)
                    break;

                if (key < node.key)
                {
                    parent = node;
                    node = node.left;
                    
                }
                else if (key > node.key)
                {
                    parent = node;
                    node = node.right;
                }
                else
                {
                    isFound = true;
                }
            }

            if (isFound)
                return parent;
            else
                return null;
        }

        public Node Minimum(Node node)
        {
            while (node.left != null)
                node = node.left;

            return node;
        }

        public Node Maximum(Node node)
        {
            while (node.right != null)
                node = node.right;

            return node;
        }

        public Node Predecessor(int key)
        {
            Node x = Find(key);

            if (x.left != null)
                return Maximum(x.left);

            else
            {
                Node y = FindParent(x.key);

                while (y != null && x == y.left)
                {
                    x = y;
                    y = FindParent(y.key);
                }

                return y;
            }
        }

        public Node Successor(int key)
        {
            Node x = Find(key);

            if (x.right != null)
                return Minimum(x.right);

            else
            {
                Node y = FindParent(x.key);
                while (y != null && x == y.right)
                {
                    x = y;
                    y = FindParent(y.key);
                }
                return y;
            }
        }


        public void PreOrder()
        {
            PreOrderRec(root);
        }

        void PreOrderRec(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.key);
                PreOrderRec(root.left);
                PreOrderRec(root.right);
            }
        }

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

        // AVL tree always has a difference between heights of two leaf nodes atmost 1

        // Search is just like BST
    }
}
