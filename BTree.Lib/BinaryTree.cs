namespace DataStructures.BTree.Lib
{
    public class BinaryTree : IBinaryTree<int>
    {
        private ITreeNode _root;
        public ITreeNode Root => _root;

        public BinaryTree(int initialValue)
        {
            _root = new TreeNode(initialValue);
        }

        public void Remove(int value)
        {
            _root = RemoveRecursive(_root, value);

        }

        private ITreeNode RemoveRecursive(ITreeNode rootNode, int value)
        {
            // Base Case (Tree Empty)
            if (rootNode == null)  return rootNode;

            // Recurse the tree
            if (value < rootNode.Value)
            {
                rootNode.Left = RemoveRecursive(rootNode.Left, value);
            }
            else if (value > rootNode.Value)
            {
                rootNode.Right = RemoveRecursive(rootNode.Right, value);

            }

            // Value is equal, must be the node to delete
            else
            {
                // One child
                if (rootNode.Left == null)
                {
                    if (rootNode.Right != null)
                        rootNode.Right.Parent = rootNode.Parent;

                    return rootNode.Right;
                }

                if (rootNode.Right == null)
                {
                    if (rootNode.Left != null)
                        rootNode.Left.Parent = rootNode.Parent;

                    return rootNode.Left;
                }


                // Two children
                // Find the successor, which would be the minimum, and assign its value to the node we are trying to remove
                // Effectively this "deletes" the node
                rootNode.Value = FindMinimum(rootNode.Right);

                // Remove the successor
                rootNode.Right = RemoveRecursive(rootNode.Right, rootNode.Value);
            }

            return rootNode;
        }

        public int FindMinimum(ITreeNode node)
        {
            int minimumValue = node.Value;
            while (node.Left != null)
            {
                minimumValue = node.Left.Value;
                node = node.Left;
            }
            return minimumValue;
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