namespace BTree.Lib
{
    public interface IBinaryTree<T>
    {
        void Insert(T value);
        void Remove(T value);
        ITreeNode Find(T value);
        T FindMinimum(ITreeNode node);
        bool IsEmpty();
    }
}