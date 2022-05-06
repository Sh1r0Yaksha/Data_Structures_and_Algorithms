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
        // Red black trees are same as BST but have following properties it must follow
        //
        // 1. Root node is always black
        // 2. Traversal from root to leaf will have same amount of black nodes in all branches, i.e. black-height will be
        // same throughout the tree
        // 3. Both children of a red node will be black
        // 4. All leaf nodes will be black


        // Set false as black and true as red
        public class Node
        {
            public int key;
            public Node left;
            public Node right;
            public bool colour;

            public Node(int item, bool colour)
            {
                this.key = item;
                this.colour = colour;
                left = right = null;
            }
        }

        public Node rootNode;
        public Node parentNode;
        public Node grandParentNode;
        
        public RedBlackTrees()
        {
            rootNode = null;
            parentNode = null;
            grandParentNode = null;
        }


        // Search is just like BST
        public Node Search(Node root, int key)
        {
            if (root == null || root.key == key)
                return root;

            else if (key < root.key)
                return root.left;
            else
                return root.right;
        }


    }
}
