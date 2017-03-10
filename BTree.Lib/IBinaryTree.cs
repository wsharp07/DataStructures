namespace BTreeMono.Lib
{
    public interface IBinaryTree
    {
        void Insert(int value);
        void Remove(int value);
        ITreeNode Find(int value);
        bool IsEmpty();
    }
}