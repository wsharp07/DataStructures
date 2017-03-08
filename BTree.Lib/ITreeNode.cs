namespace BTreeMono.Lib
{
    public interface ITreeNode
    {
        int Value { get; }
        ITreeNode Left { get; set; }
        ITreeNode Right { get; set; }
    }
}