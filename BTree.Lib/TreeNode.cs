namespace BTreeMono.Lib
{
    public class TreeNode : ITreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }

        public int Value { get; }
        public ITreeNode Left { get; set; }
        public ITreeNode Right { get; set; }
    }
}