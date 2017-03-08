namespace LinkedList.Lib
{
    public interface ISingleLinkedList<T>
    {
        void InsertFirst(T value);
        void InsertAfter(T valueToFind, T valueToInsert);
        void InsertLast(T value);
        void InsertBefore(T valueToFind, T valueToInsert);
        void Remove(T value);
        ISingleLinkedListNode<T> Find(T value);
        T[] ToArray();
    }
}