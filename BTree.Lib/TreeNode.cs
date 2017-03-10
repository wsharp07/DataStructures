namespace BTreeMono.Lib
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

        public int Value { get; }
        public ITreeNode Parent { get; set; }
        public ITreeNode Left { get; set; }
        public ITreeNode Right { get; set; }
    }
}