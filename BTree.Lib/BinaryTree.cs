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

            InsertRecursive(_root, value);
        }

        private ITreeNode InsertRecursive(ITreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            if (value < node.Value)
            {
                node.Left = InsertRecursive(node.Left, value);
            }

            if (value > node.Value)
            {
                node.Right = InsertRecursive(node.Right, value);
            }

            return node;
        }
    }
}