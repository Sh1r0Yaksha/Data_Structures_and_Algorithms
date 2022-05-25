using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Sem4
{
    // Both red-black tree and AVL tree uses rotation and height checking for self-balancing 
    // Red-black tree also uses painting nodes for self-balancing unlike AVL tree which uses height checking

    // RB tree has better insertion and deletion time
    // For searching, AVL tree is preffered

    // Time and space complexity same as AVL tree:
    // O(n) space complexity
    // O(log n) time complexity
    internal class RedBlackTrees
    {

        public class Node
        {
            public bool colour = true;
            public Node left;
            public Node right;
            public Node parent;
            public int data;

            public Node(int data) { this.data = data; }
            public Node(bool colour) { this.colour = colour; }
            public Node(int data, bool colour) { this.data = data; this.colour = colour; }
        }
        /// <summary>
        /// Root node of the tree (both reference & pointer)
        /// </summary>
        public Node root;
        /// <summary>
        /// New instance of a Red-Black tree object
        /// </summary>
        public RedBlackTrees() { }
        /// <summary>
        /// Left Rotate
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
        private void LeftRotate(Node X)
        {
            Node Y = X.right; // set Y
            X.right = Y.left;//turn Y's left subtree into X's right subtree
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;//link X's parent to Y
            }
            if (X.parent == null)
            {
                root = Y;
            }
            if (X == X.parent.left)
            {
                X.parent.left = Y;
            }
            else
            {
                X.parent.right = Y;
            }
            Y.left = X; //put X on Y's left
            if (X != null)
            {
                X.parent = Y;
            }

        }
        /// <summary>
        /// Rotate Right
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
        private void RightRotate(Node Y)
        {
            // right rotate is simply mirror code from left rotate
            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;//put Y on X's right
            if (Y != null)
            {
                Y.parent = X;
            }
        }
        /// <summary>
        /// Display Tree
        /// </summary>
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }
        /// <summary>
        /// Find item in the tree
        /// </summary>
        /// <param name="key"></param>
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            //Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                else if (key < temp.data)
                {
                    temp = temp.left;
                }
                else if (key > temp.data)
                {
                    temp = temp.right;
                }
                else
                {
                    isFound = true;
                    //item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }
        /// <summary>
        /// Insert a new object into the RB Tree
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item)
        {
            Node newItem = new Node(item);
            if (root == null)
            {
                root = newItem;
                root.colour = false;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.data < Y.data)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = false;//colour the new node red
            InsertFixUp(newItem);//call method to check for violations and fix
        }
        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplay(current.right);
            }
        }
        private void InsertFixUp(Node item)
        {
            //Checks Red-Black Tree properties
            while (item != root && item.parent.colour == true)
            {
                /*We have a violation*/
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == true)//Case 1: uncle is red
                    {
                        item.parent.colour = false;
                        Y.colour = false;
                        item.parent.parent.colour = true;
                        item = item.parent.parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = false;
                        item.parent.parent.colour = true;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    //mirror image of code above
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == false)//Case 1
                    {
                        item.parent.colour = false;
                        X.colour = false;
                        item.parent.parent.colour = false;
                        item = item.parent.parent;
                    }
                    else //Case 2
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = false;
                        item.parent.parent.colour = false;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = false;//re-colour the root black as necessary
            }
        }
        /// <summary>
        /// Deletes a specified value from the tree
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == false)
            {
                DeleteFixUp(X);
            }

        }
        /// <summary>
        /// Checks the tree for any violations after deletion and performs a fix
        /// </summary>
        /// <param name="X"></param>
        private void DeleteFixUp(Node X)
        {

            while (X != null && X != root && X.colour == false)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == false)
                    {
                        W.colour = false; //case 1
                        X.parent.colour = false; //case 1
                        LeftRotate(X.parent); //case 1
                        W = X.parent.right; //case 1
                    }
                    if (W.left.colour == false && W.right.colour == false)
                    {
                        W.colour = false; //case 2
                        X = X.parent; //case 2
                    }
                    else if (W.right.colour == false)
                    {
                        W.left.colour = false; //case 3
                        W.colour = false; //case 3
                        RightRotate(W); //case 3
                        W = X.parent.right; //case 3
                    }
                    W.colour = X.parent.colour; //case 4
                    X.parent.colour = false; //case 4
                    W.right.colour = false; //case 4
                    LeftRotate(X.parent); //case 4
                    X = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node W = X.parent.left;

                     

                    if (W.colour == false)
                    {
                        W.colour = false;
                        X.parent.colour = false;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    else if (W.right.colour == false && W.left.colour == false)
                    {
                        W.colour = false;
                        X = X.parent;
                    }
                    else if (W.left.colour == false)
                    {
                        W.right.colour = false;
                        W.colour = false;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = false;
                    W.left.colour = false;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = false;
        }
        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }
        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }






        // Red black trees are same as BST but have following properties it must follow
        //
        // 1. Root node is always black
        // 2. Traversal from root to leaf will have same amount of black nodes in all branches, i.e. black-height will be
        // same throughout the tree
        // 3. Both children of a red node will be black
        // 4. All leaf nodes will be black


        // Set false as black and true as red
        //    public class Node
        //    {
        //        public int key;
        //        public Node left;
        //        public Node right;
        //        public bool colour;

        //        public Node parent;

        //        public Node(int key)
        //        {
        //            this.key = key;
        //            this.colour = false;
        //            this.left = null;
        //            this.right = null;
        //            this.parent = null;
        //        }
        //    }

        //    public Node rootNode;

        //    public RedBlackTrees()
        //    {
        //        rootNode = null;
        //    }

        //public void LeftRotate(Node x)
        //{
        //    Node y = x.right;
        //    if (y.left != null)
        //    {
        //        y.left.parent = x;
        //        x.right = y.left;
        //    }

        //    y.parent = x.parent;

        //    // check if x is root node
        //    if (x.parent == null)
        //        root = y;

        //    else if (x.parent.left == x)
        //        x.parent.left = y;
        //    else
        //        x.parent.right = y;

        //    y.left = x;
        //    x.parent = y;
        //}

        //public void RightRotate(Node x)
        //{
        //    Node y = x.left;

        //    if (y.right != null)
        //    {
        //        y.right.parent = x;
        //        x.left = y.right;
        //    }

        //    y.parent = x.parent;

        //    if (x.parent == null)
        //        root = y;
        //    else if (x.parent.left == x)
        //        x.parent.left = y;
        //    else
        //        x.parent.right = y;

        //    y.right = x;
        //    x.parent = y;
        //}

        //    bool ll = false;
        //    bool lr = false;
        //    bool rl = false;
        //    bool rr = false;

        //    public void Insert(int key)
        //    {
        //        Node node = new Node(key);
        //        Node y = null;
        //        Node x = rootNode;

        //        while (x != null)
        //        {
        //            y = x;
        //            if (node.key < x.key)
        //                x = x.left;
        //            else
        //                x = x.right;
        //        }

        //        node.parent = y;

        //        if (y == null)
        //            rootNode = node;
        //        else if (node.key < y.key)
        //            y.left = node;
        //        else
        //            y.right = node;

        //        if (node.parent == null)
        //        {
        //            node.colour = false;
        //            return;
        //        }

        //        if (node.parent.parent == null)
        //            return;

        //        FixInsert(node);
        //    }

        //    void FixInsert(Node k)
        //    {
        //        Node u;

        //        while (k.parent.colour == true)
        //        {
        //            if (k.parent == k.parent.parent.right)
        //            {
        //                u = k.parent.parent.left;
        //                if (u.colour == true)
        //                {
        //                    u.colour = false;
        //                    k.parent.colour = false;
        //                    k.parent.parent.colour = true;
        //                    k = k.parent.parent;
        //                }
        //                else
        //                {
        //                    if (k == k.parent.left)
        //                    {
        //                        k = k.parent;
        //                        RotateRight(k);
        //                    }
        //                    k.parent.colour = false;
        //                    k.parent.parent.colour = true;
        //                    RotateLeft(k.parent.parent);
        //                }
        //            }
        //            else
        //            {
        //                u = k.parent.parent.right;

        //                if (u.colour == true)
        //                {
        //                    u.colour = false;
        //                    k.parent.colour = false;
        //                    k.parent.parent.colour = true;
        //                    k = k.parent.parent;
        //                }
        //                else
        //                {
        //                    if (k == k.parent.right)
        //                    {
        //                        k = k.parent;
        //                        RotateLeft(k);
        //                    }
        //                    k.parent.colour = false;
        //                    k.parent.parent.colour = true;
        //                    RotateRight(k.parent.parent);
        //                }
        //            }
        //            if (k == rootNode)
        //                break;

        //        }
        //        rootNode.colour = false;
        //    }

        //    public void DeleteNode(int key)
        //    {
        //        DeleteUtil(rootNode, key);
        //    }

        //    void RBTransplant(Node u, Node v)
        //    {
        //        if (u.parent == null)
        //            rootNode = v;
        //        else if (u == u.parent.left)
        //            u.parent.left = v;
        //        else
        //            u.parent.right = v;

        //        v.parent = u.parent;
        //    }

        //    void DeleteUtil(Node node, int key)
        //    {
        //        Node x, y;
        //        Node z = null;

        //        while (node != null)
        //        {
        //            if (node.key == key)
        //                z = node;

        //            if (key <= node.key)
        //                node = node.left;
        //            else
        //                node = node.right;
        //        }

        //        if (z == null)
        //        {
        //            Console.WriteLine($"Couldn't find the node with key = {key}");
        //            return;
        //        }

        //        y = z;
        //        bool yOriginalColour = y.colour;

        //        if (z.left == null)
        //        {
        //            x = z.right;
        //            RBTransplant(z, z.left);
        //        }
        //        else if (z.right == null)
        //        {
        //            x = z.left;
        //            RBTransplant(z, z.left);
        //        }
        //        else
        //        {
        //            y = Minimum(z.right);
        //            yOriginalColour = y.colour;
        //            x = y.right;

        //            if (y.parent == z)
        //                x.parent = y;
        //            else
        //            {
        //                RBTransplant(y, y.right);
        //                y.right = z.right;
        //                y.right.parent = y;
        //            }

        //            RBTransplant(z, y);
        //            y.left = z.left;
        //            y.left.parent = y;
        //            y.colour = z.colour;
        //        }
        //        if (yOriginalColour == false)
        //            FixDelete(x);
        //    }

        //    void FixDelete(Node x)
        //    {
        //        Node s;

        //        while (x != rootNode && x.colour == false)
        //        {
        //            if (x == x.parent.left)
        //            {
        //                s = x.parent.right;
        //                if (s.colour == true)
        //                {
        //                    s.colour = false;
        //                    x.parent.colour = true;
        //                    RotateLeft(x.parent);
        //                    s = x.parent.right;
        //                }

        //                if (s.left.colour == false && s.right.colour == false)
        //                {
        //                    s.colour = true;
        //                    x = x.parent;
        //                }
        //                else
        //                {
        //                    if (s.right.colour == false)
        //                    {
        //                        s.left.colour = false;
        //                        s.colour = true;
        //                        RotateRight(s);
        //                        s = x.parent.right;
        //                    }

        //                    s.colour = x.parent.colour;
        //                    x.parent.colour = false;
        //                    s.right.colour = false;
        //                    RotateLeft(x.parent);
        //                    x = rootNode;
        //                }
        //            }
        //            else
        //            {
        //                s = x.parent.left;
        //                if (s.colour == true)
        //                {
        //                    s.colour = false;
        //                    x.parent.colour = true;
        //                    RotateRight(x.parent);
        //                    s = x.parent.left;
        //                }

        //                if (s.left.colour == false && s.right.colour == false)
        //                {
        //                    s.colour = true;
        //                    x = x.parent;
        //                }
        //                else
        //                {
        //                    if (s.left.colour == false)
        //                    {
        //                        s.right.colour = false;
        //                        s.colour = true;
        //                        RotateLeft(s);
        //                        s = x.parent.left;
        //                    }

        //                    s.colour = x.parent.colour;
        //                    x.parent.colour = false;
        //                    s.left.colour = false;
        //                    RotateRight(x.parent);
        //                    x = rootNode;
        //                }

        //            }

        //        }

        //        x.colour = false;
        //    }

        //    public Node Minimum(Node node)
        //    {
        //        while (node.left != null)
        //            node = node.left;

        //        return node;
        //    }

        //    public Node Maximum(Node node)
        //    {
        //        while (node.right != null)
        //            node = node.right;

        //        return node;
        //    }

        //    public Node Successor(Node x)
        //    {
        //        if (x.right != null)
        //            return Minimum(x.right);

        //        else
        //        {
        //            Node y = x.parent;
        //            while (y != null && x == y.right)
        //            {
        //                x = y;
        //                y = y.parent;
        //            }
        //            return y;
        //        }
        //    }

        //    public Node Predecessor(Node x)
        //    {
        //        if (x.left != null)
        //            return Maximum(x.left);

        //        else
        //        {
        //            Node y = x.parent;

        //            while (y != null && x == y.left)
        //            {
        //                x = y;
        //                y = y.parent;
        //            }

        //            return y;
        //        }
        //    }



        //    // Search is just like BST
        //    public Node Search(Node root, int key)
        //    {
        //        if (root == null || root.key == key)
        //            return root;

        //        else if (key < root.key)
        //            return Search(root.left, key);
        //        else
        //            return Search(root.right, key);
        //    }

        //    public void PreOrder()
        //    {
        //        PreOrderRec(rootNode);
        //    }

        //    // The method prints the keys in preorder way, i.e. first prints the root node, then left node and then right node
        //    void PreOrderRec(Node root)
        //    {
        //        // Checks if root exists, then recursively runs the preorder traversal steps
        //        if (root != null)
        //        {
        //            Console.WriteLine(root.key);
        //            PreOrderRec(root.left);
        //            PreOrderRec(root.right);
        //        }
        //    }

        //    public void Inorder()
        //    {
        //        InorderRec(rootNode); // runs inorder traversal on root node of bst
        //    }

        //    // The method prints the keys in inorder way, i.e. first prints the left node, then root node and then right node
        //    static void InorderRec(Node root)
        //    {
        //        // Checks if root exists, then recursively runs the inorder traversal steps
        //        if (root != null)
        //        {
        //            InorderRec(root.left);
        //            Console.WriteLine(root.key);
        //            InorderRec(root.right);
        //        }
        //    }
    }
}
