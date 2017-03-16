namespace DataStructures.BTree.Lib
{
    public interface ITreeNode
    {
        int Value { get; set; }
        ITreeNode Parent { get; set; }
        ITreeNode Left { get; set; }
        ITreeNode Right { get; set; }
    }
}