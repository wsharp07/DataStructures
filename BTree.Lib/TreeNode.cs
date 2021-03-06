﻿namespace DataStructures.BTree.Lib
{
    public class TreeNode : ITreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }
        public TreeNode(int value, ITreeNode parent)
            : this(value)
        {
            Parent = parent;
        }

        public int Value { get; set;  }
        public ITreeNode Parent { get; set; }
        public ITreeNode Left { get; set; }
        public ITreeNode Right { get; set; }
    }
}