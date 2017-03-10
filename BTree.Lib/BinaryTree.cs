using System;

namespace BTreeMono.Lib
{
    public class BinaryTree : IBinaryTree
    {
        private ITreeNode _root;
        public ITreeNode Root => _root;

        public BinaryTree(int initialValue)
        {
            _root = new TreeNode(initialValue);
        }

        public void Remove(int value)
        {
            ITreeNode nodeToDelete = Find(value);

            if (nodeToDelete == null)
            {
                throw new ArgumentException($"Unable to find the node given value: '{value}'. Are you sure it exists?");
            }

            // Leaf node
            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                var parent = nodeToDelete.Parent;
                if (nodeToDelete == parent.Left)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }

            // Has a child
            else if (nodeToDelete.Left == null || nodeToDelete.Right == null)
            {
                var child =
                    nodeToDelete.Left ?? nodeToDelete.Right;

                var parent = nodeToDelete.Parent;

                if (nodeToDelete == parent.Left)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }
                else
                {
                    parent.Right = child;
                    child.Parent = parent;
                }
            }

            // Has both children
            else if (nodeToDelete.Left != null && nodeToDelete.Right != null)
            {

            }

        }

        public ITreeNode Find(int value)
        {
            return IsEmpty()
                ? null
                : FindRecursive(_root, value);
        }

        private ITreeNode FindRecursive(ITreeNode node, int valueToFind)
        {
            if (node == null)
            {
                return null;
            }
            if (valueToFind < node.Value)
            {
                return FindRecursive(node.Left, valueToFind);
            }

            if (valueToFind > node.Value)
            {
                return FindRecursive(node.Right, valueToFind);
            }

            return node;
        }

        public bool IsEmpty()
        {
            return _root == null;
        }

        public void Insert(int value)
        {
            if (IsEmpty())
            {
                _root = new TreeNode(value);
            }

            InsertRecursive(_root, _root.Parent, value);
        }

        private ITreeNode InsertRecursive(ITreeNode node, ITreeNode parent, int value)
        {
            if (node == null)
            {
                return new TreeNode(value, parent);
            }
            if (value < node.Value)
            {
                node.Left = InsertRecursive(node.Left, node, value);
            }

            if (value > node.Value)
            {
                node.Right = InsertRecursive(node.Right, node, value);
            }

            return node;
        }
    }
}