using System;

namespace DataStructures.Stack.Lib
{
    public class WsStack<T> : IStack<T>
    {
        private T[] _stack;
        private int _index;

        private WsStack()
        {
            _index = 0;
        }
        public WsStack(int size) : this()
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(size)}' must be greater than 0");
            }

            _stack = new T[size];
        }
        public void Push(T value)
        {
            if (IsStackOverflow())
            {
                Array.Resize(ref _stack, (_stack.Length + 1) * 2);
            }

            _stack[_index++] = value;

        }

        public T Pop()
        {
            if (_index == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            var result = _stack[--_index];
            _stack[_index] = default(T);
            return result;
        }

        private bool IsStackOverflow()
        {
            return _index + 1 > _stack.Length;
        }
    }
}