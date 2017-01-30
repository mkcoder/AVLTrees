using Microsoft.VisualStudio.TestTools.UnitTesting;
using AVLTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees.Tests
{
    [TestClass()]
    public class AVLTreeTests
    {
        [TestMethod()]
        public void HeightTest()
        {
            // Given
            AVLTree avl = new AVLTree();
            Assert.AreEqual(0, avl.Height());
        }

        [TestMethod()]
        public void HeightGrowsAsYouNewNodesToTheTree()
        {
            // Given
            AVLTree avl = new AVLTree();
            avl.Add(0);
            Assert.AreEqual(1, avl.Height());
        }

        [TestMethod()]
        public void TestThatBalanceFactorIsCorrect()
        {
            AVLTree avl = new AVLTree();
            Assert.IsTrue(avl.IsBalanced());
        }

        [TestMethod()]
        public void TestThatBalanceFactorIsCorrectWhenIAddOneElements()
        {
            AVLTree avl = new AVLTree();
            avl.Add(0);
            Assert.IsTrue(avl.IsBalanced());
        }

        [TestMethod()]
        public void TestThatBalanceFactorIsCorrectWhenIAddOneElementsIGetCorrectBalanceFactor()
        {
            AVLTree avl = new AVLTree();
            avl.Add(0);
            Node node = getNode(avl);
            Assert.AreEqual(0, node.BalanceFactor);
        }

        [TestMethod()]
        public void TestThatBalanceFactorIsCorrectWhenIAddThreeElements()
        {
            AVLTree avl = new AVLTree();
            avl.Add(2);
            avl.Add(1);
            avl.Add(0);
            Assert.IsTrue(avl.IsBalanced());
        }


        [TestMethod()]
        public void TestThatWhenIAddThreeItemsToTheTreeItDoesLeftRightRoation()
        {
            AVLTree avl = new AVLTree();
            avl.Add(3);
            avl.Add(0);
            avl.Add(1);
            var item = getNode(avl);
            Assert.IsNotNull(item.Data);
            Assert.AreEqual(3, item.Data);
            Assert.IsNotNull(item.Left.Data);            
            Assert.AreEqual(1, item.Left.Data);
            Assert.IsNotNull(item.Left.Left.Data);
            Assert.AreEqual(0, item.Left.Left.Data);
        }

        [TestMethod()]
        public void TestThatWhenIInsertIntoTheAvlThatIsLeftOreintedItWillRotate()
        {
            AVLTree avl = new AVLTree();
            avl.Add(10);
            avl.Add(9);
            avl.Add(8);
            var item = getNode(avl);
            Assert.IsNotNull(item.Data);
            Assert.AreEqual(9, item.Data);
            Assert.IsNotNull(item.Left.Data);
            Assert.AreEqual(8, item.Left.Data);
            Assert.IsNotNull(item.Right.Data);
            Assert.AreEqual(10, item.Right.Data);
        }

        [TestMethod()]
        public void TestThatWhenIInsertElementsInTheAvlTreeItDoesARightRotation()
        {
            AVLTree avl = new AVLTree();
            avl.Add(0);
            avl.Add(2);
            avl.Add(1);
            var item = getNode(avl);
            Assert.IsNotNull(item.Data);
            Assert.AreEqual(0, item.Data);
            Assert.IsNotNull(item.Right.Data);
            Assert.AreEqual(1, item.Right.Data);
            Assert.IsNotNull(item.Right.Right.Data);
            Assert.AreEqual(2, item.Right.Right.Data);
        }

        [TestMethod()]
        public void TestThatWhenIInsertIntoElementItDoesRightRight()
        {
            AVLTree avl = new AVLTree();
            avl.Add(0);
            avl.Add(2);
            avl.Add(3);
            var item = getNode(avl);
            Assert.IsNotNull(item.Data);
            Assert.AreEqual(3, item.Data);
            Assert.IsNotNull(item.Left.Data);
            Assert.AreEqual(0, item.Left.Data);
            Assert.IsNotNull(item.Right.Data);
            Assert.AreEqual(2, item.Right.Data);
        }
        
        private Node getNode(AVLTree avl)
        {
            return (Node)avl.GetType().GetField("root", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(avl);
        }
    }
}