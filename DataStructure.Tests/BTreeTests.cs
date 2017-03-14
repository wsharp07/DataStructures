using System;
using BTree.Lib;
using Xunit;

namespace DataStructure.Tests
{
    public class Tests
    {
        [Fact]
        public void NewTree_Has_RootNode()
        {
            var tree = new BinaryTree(1);
            Assert.NotNull(tree.Root);
            Assert.Equal(1, tree.Root.Value);
        }

        [Fact]
        public void InitSeven_AddOne_ExpectLeft()
        {
            var tree = new BinaryTree(7);
            tree.Insert(1);

            Assert.NotNull(tree.Root.Left);
            Assert.Equal(1, tree.Root.Left.Value);
        }

        [Fact]
        public void InitSeven_AddOne_ExpectSevenAsParent()
        {
            var tree = new BinaryTree(7);
            tree.Insert(1);

            Assert.NotNull(tree.Root.Left.Parent);
            Assert.Equal(7, tree.Root.Left.Parent.Value);
        }

        [Fact]
        public void InitSeven_AddEight_ExpectRight()
        {
            var tree = new BinaryTree(7);
            tree.Insert(8);

            Assert.NotNull(tree.Root.Right);
            Assert.Equal(8, tree.Root.Right.Value);
        }

        [Fact]
        public void InitOne_AddTwo_AddThree_ExpectTwoLevelsRight()
        {
            var tree = new BinaryTree(1);
            tree.Insert(2);
            tree.Insert(3);

            var level1 = tree.Root;
            var level2 = tree.Root.Right;

            Assert.NotNull(level1.Right);
            Assert.NotNull(level2.Right);

            Assert.Equal(2, level1.Right.Value);
            Assert.Equal(3, level2.Right.Value);
        }

        [Fact]
        public void InitSeven_AddSix_AddFive_ExpectTwoLevelsLeft()
        {
            var tree = new BinaryTree(7);
            tree.Insert(6);
            tree.Insert(5);

            var level1 = tree.Root;
            var level2 = tree.Root.Left;

            Assert.NotNull(level1.Left);
            Assert.NotNull(level2.Left);

            Assert.Equal(6, level1.Left.Value);
            Assert.Equal(5, level2.Left.Value);
        }

        [Fact]
        public void InitSeven_AddSix_AddFive_ExpectFiveHasParentSix()
        {
            var tree = new BinaryTree(7);
            tree.Insert(6);
            tree.Insert(5);

            var level2 = tree.Root.Left;

            Assert.NotNull(level2.Left.Parent);
            Assert.Equal(6, level2.Left.Parent.Value);
        }

        [Fact]
        public void FindKnownNode_Expect_Found()
        {
            var tree = new BinaryTree(7);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(8);

            var nodeToFind = tree.Find(8);
            Assert.Equal(8, nodeToFind.Value);
        }

        [Fact]
        public void FindMissingNode_Expect_Null()
        {
            var tree = new BinaryTree(7);
            tree.Insert(3);
            tree.Insert(2);

            var nodeToFind = tree.Find(10);
            Assert.Null(nodeToFind);
        }

        [Fact]
        public void RemoveLeafNode_Expect_Removed()
        {
            var tree = new BinaryTree(7);
            tree.Insert(3);
            tree.Insert(2);

            tree.Remove(2);

            var removedNode = tree.Find(2);
            Assert.Null(removedNode);
        }

        [Fact]
        public void LongTreeRemoveRightLeafNode_Expect_Removed()
        {
            var tree = new BinaryTree(7);
            tree.Insert(8);
            tree.Insert(9);
            tree.Insert(10);
            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(13);

            tree.Remove(13);

            var removedNode = tree.Find(13);
            Assert.Null(removedNode);
        }

        [Fact]
        public void RemoveNodeWithChild_Expect_Removed()
        {
            var tree = new BinaryTree(7);
            tree.Insert(3);
            tree.Insert(2);

            tree.Remove(3);

            var removedNode = tree.Find(3);
            var nodeToFind = tree.Find(2);
            Assert.Null(removedNode);
            Assert.Equal(7, nodeToFind.Parent.Value);
        }

        [Fact]
        public void LongTreeRemoveNodeWithChild_Expect_Removed()
        {
            var tree = new BinaryTree(7);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);

            tree.Remove(3);

            var removedNode = tree.Find(3);
            var nodeToFind = tree.Find(2);
            Assert.Null(removedNode);
            Assert.Equal(4, nodeToFind.Parent.Value);
        }

        [Fact]
        public void RemoveNodeWithBothChildren_Expect_Removed()
        {
            var tree = new BinaryTree(7);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);
            tree.Remove(3);

            var removedNode = tree.Find(3);
            var nodeToFind = tree.Find(4);
            Assert.Null(removedNode);
            Assert.Equal(7, nodeToFind.Parent.Value);
        }

        [Fact]
        public void FindMinimumRecursive()
        {
            var tree = new BinaryTree(8);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(7);

            var x = tree.Find(6);
            var sut = tree.FindMinimum(x);
            Assert.Equal(5, sut);
        }
    }
}