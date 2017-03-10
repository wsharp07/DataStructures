namespace BTreeMono.Lib
{
    public interface ITreeNode
    {
        int Value { get; }
        ITreeNode Parent { get; set; }
        ITreeNode Left { get; set; }
        ITreeNode Right { get; set; }
    }
}