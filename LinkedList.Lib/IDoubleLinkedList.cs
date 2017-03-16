namespace DataStructures.LinkedList.Lib
{
    public interface IDoubleLinkedList<T>
    {
        void InsertFirst(T value);
        void InsertAfter(T valueToFind, T valueToInsert);
        void InsertLast(T value);
        void InsertBefore(T valueToFind, T valueToInsert);
        void Remove(T value);
        IDoubleLinkedListNode<T> Find(T value);
        T[] ToArray();
    }
}