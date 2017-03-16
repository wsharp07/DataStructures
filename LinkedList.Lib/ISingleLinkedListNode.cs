namespace DataStructures.LinkedList.Lib
{
    public interface ISingleLinkedListNode<T>
    {
        ISingleLinkedListNode<T> Next { get; set; }
        T Value { get; }
    }
}