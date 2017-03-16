using System;
using System.Collections.Specialized;

namespace Queue.Lib
{
    public class WsQueue<T> : IQueue<T>
    {
        private T[] _array;
        private int _size;
        private int _headIndex;
        private int _tailIndex => (_headIndex + Count) % _size;

        public int Count { get; private set; }

        public WsQueue(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(size)}' must be greater than 0");
            }

            _size = size;
            _array = new T[size];
        }

        public void Enqueue(T value)
        {
            if (Count == _size)
            {
                GrowQueue();
            }

            _array[_tailIndex] = value;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var result = _array[_headIndex];
            _array[_headIndex] = default(T);

            Count--;
            EvaluateHead();

            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _array[_headIndex];
        }

        private bool IsEmpty()
        {
            return this.Count <= 0;
        }

        private void EvaluateHead()
        {
            _headIndex = (_headIndex + 1) % _size;
        }

        private void GrowQueue()
        {
            var newSize = (_size + 1) * 2;
            var newArray = new T[newSize];

            var index = 0;
            var prevCount = Count;
            while (index < prevCount)
            {
                newArray[index] = this.Dequeue();
                index++;
            }

            _array = newArray;
            _headIndex = 0;
            _size = newSize;
            Count = prevCount;
        }

    }
}