using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            /*tree.Add(5);
            tree.Add(4);
            tree.Add(11);
            tree.Add(10);
            tree.Add(15);

            tree.Add(7);*/
            tree.Add(25);
            tree.Add(21);
            tree.Add(10);
            tree.Add(23);
            tree.Add(7);
            tree.Add(26);
            tree.Add(12);
            tree.Add(30);
            tree.Add(16);
            tree.Add(19);
            Console.WriteLine(tree.Height());
        }
    }
}
