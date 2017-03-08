namespace LinkedList.Lib
{
    public interface ILList<T>
    {
        void InsertFirst(T value);
        void InsertAfter(T valueToFind, T valueToInsert);
        void InsertLast(T value);
        void InsertBefore(T valueToFind, T valueToInsert);
        void Remove(T value);
        ISingleLListNode<T> Find(T value);
        T[] ToArray();
    }
}