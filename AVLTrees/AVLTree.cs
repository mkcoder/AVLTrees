using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    public class AVLTree
    {
        private Node root;

        public void Add(int data)
        {
            root = Add(data, root);
        }

        private Node Add(int data, Node node)
        {
            if ( node == null )
            {
                return new Node(data);
            }
            else if ( data > node.Data )
            {
                node.Right = Add(data, node.Right);
                if (Height(node.Right) - Height(node.Left) == 2)
                    if (data > node.Right.Data)
                        node = RightRight(node);
                    else
                        node = RightLeft(node);
            }
            else if (data < node.Data)
            {
                node.Left = Add(data, node.Left);

                if (Height(node.Left) - Height(node.Right) == 2)
                    if (data < root.Left.Data)
                        node = LeftLeft(node);
                    else
                        node = LeftRight(node);
            }
            node.BalanceFactor = CalculateBalanceFactor(node?.Left, node?.Right);
            return node;
        }

        private Node LeftRight(Node node)
        {
            /*
             * <>       = Subtree
             * {A,B,C}  = Nodes in a tree 
             *            A                    A
             *           /  \                /   \
             *          B   <D>         =>  C    <D>
             *        /  \                 / \   
             *       <A>  C               B  <C> 
             *           / \             / \   
             *          <B> <C>         <A> <B>  
             *                          
             */            
            Node temp = node.Left.Right; // C
            node.Left.Right = temp.Left; // B => <B>
            temp.Left = node.Left;
            node.Left = temp;
            node.BalanceFactor = CalculateBalanceFactor(node.Left, node.Right);
            temp.BalanceFactor = CalculateBalanceFactor(temp.Left, temp.Right);
            return node;
        }

        private Node LeftLeft(Node node)
        {
            /*
             *            A                    B
             *           /  \                /   \
             *          B   <D>         =>  C      A
             *        /  \                 / \    / \  
             *       C    <C>           <A>  <B> <C> <D>
             *      /  \
             *    <A>  <B>
             */
            Node temp  = node.Left; // B
            node.Left = node.Left.Right; /**/
            temp.Right = node;
            node = temp;
            return node;
        }

        private Node RightLeft(Node node)
        {
            /*
             *            A                      A
             *           /  \                  /   \
             *         <A>   B            => <A>    C    
             *              / \                    / \   
             *             C    <D>              <B>  B   
             *            / \                        / \   
             *          <B> <C>                    <C> <D>  
             */
            Node temp = node.Right.Left;    // C
            node.Right.Left = temp.Right;   // C    => <C>
            temp.Right = node.Right;        // C<C> => B
            node.Right = temp;
            node.BalanceFactor = CalculateBalanceFactor(node.Left, node.Right);
            temp.BalanceFactor = CalculateBalanceFactor(temp.Left, temp.Right);
            return node;
        }

        private Node RightRight(Node node)
        {
            /*
             *            A                   B
             *           / \                /   \
             *         <A>  C         =>   A      C
             *             / \            / \    / \  
             *            <B> B         <A> <B> <C> <D>
             *               / \
             *             <C> <D>
             */
            Node temp = node.Right.Right;   // B
            node.Right.Right = temp.Right;  // C.B => <D>
            Node temp2 = node.Right.Left;   // <B>
            Node temp3 = node;              //  A
            node = temp;                    //  A   => B
            node.Left = temp3;              //  B.L => A
            node.Right = temp3.Right;       //  B.R => C
            node.Left.Right = temp2;        //  B.A.{C} => <B>

            node.BalanceFactor = CalculateBalanceFactor(node.Left, node.Right);
            temp.BalanceFactor = CalculateBalanceFactor(temp.Left, temp.Right);
            return node;
        }

        private int CalculateBalanceFactor(Node left, Node right)
        {
            return Height(left) - Height(right);
        }

        public int Height()
        {
            return Height(root);
        }

        internal int Height(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public bool IsBalanced()
        {
            if (root == null) return true;
            return CalculateBalanceFactor(root.Left, root.Right) != 2;
        }
    }
}
