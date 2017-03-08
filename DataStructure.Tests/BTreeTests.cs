using System;
using BTreeMono.Lib;
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
    }
}