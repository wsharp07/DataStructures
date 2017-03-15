namespace Queue.Lib
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();
        T Peek();
        int Count { get; }
    }
}