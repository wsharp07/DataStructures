using System;

namespace LinkedList.Lib
{
    public class LList : ILList<int>
    {
        public ISingleLListNode<int> Head { get; private set; }
        public ISingleLListNode<int> Tail { get; private set; }
        public int Count { get; private set; }

        public LList()
        {
            Count = 0;
        }

        public void InsertFirst(int value)
        {
            IncrementCount();

            var node = new SingleLListNode(value);

            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        public void InsertAfter(int valueToFind, int valueToInsert)
        {
            IncrementCount();

            var nodeToInsert = new SingleLListNode(valueToInsert);
            var node = Find(valueToFind);

            if (node == null)
            {
                throw new ArgumentException($"Unable to find a node with value '{valueToFind}' to insert after.");
            }

            nodeToInsert.Next = node.Next;
            node.Next = nodeToInsert;
        }

        public void InsertLast(int value)
        {
            IncrementCount();

            var node = new SingleLListNode(value);

            if (Head == null)
            {
                Tail = node;
                Head = Tail;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public void InsertBefore(int valueToFind, int valueToInsert)
        {
            IncrementCount();

            var nodeToInsert = new SingleLListNode(valueToInsert);
            var current = Head;
            var previous = current;

            while (current != null)
            {
                if (current.Value == valueToFind)
                {
                    nodeToInsert.Next = current;
                    previous.Next = nodeToInsert;
                    break;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void Remove(int value)
        {
            if (Head == null)
            {
                throw new ArgumentOutOfRangeException("Linked List has no elements");
            }

            DecrementCount();
            var current = this.Head;

            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
            }
        }

        public ISingleLListNode<int> Find(int value)
        {
            var current = this.Head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            int index = 0;

            var current = this.Head;
            while (current != null)
            {
                result[index] = current.Value;
                current = current.Next;
                index++;
            }

            return result;
        }

        private void IncrementCount()
        {
            ++Count;
        }

        private void DecrementCount()
        {
            --Count;
        }
    }
}