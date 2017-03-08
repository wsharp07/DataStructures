namespace LinkedList.Lib
{
    public interface ISingleLListNode<T>
    {
        ISingleLListNode<T> Next { get; set; }
        T Value { get; }
    }
}