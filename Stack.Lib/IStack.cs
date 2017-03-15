namespace Stack.Lib
{
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
    }
}