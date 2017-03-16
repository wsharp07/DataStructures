namespace DataStructures.LinkedList.Lib
{
    public interface IDoubleLinkedListNode<T>
    {
        IDoubleLinkedListNode<T> Previous { get; set; }
        IDoubleLinkedListNode<T> Next { get; set; }
        T Value { get; }
    }
}