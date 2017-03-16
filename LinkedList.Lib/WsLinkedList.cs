using System;

namespace DataStructures.LinkedList.Lib
{
    public class WsLinkedList : ISingleLinkedList<int>
    {
        public ISingleLinkedListNode<int> Head { get; private set; }
        public ISingleLinkedListNode<int> Tail { get; private set; }
        public int Count { get; private set; }

        public WsLinkedList()
        {
            Count = 0;
        }

        public void InsertFirst(int value)
        {
            IncrementCount();

            var node = new SingleLinkedListNode(value);

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

            var nodeToInsert = new SingleLinkedListNode(valueToInsert);
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

            var node = new SingleLinkedListNode(value);

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

            var nodeToInsert = new SingleLinkedListNode(valueToInsert);
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

            var current = this.Head;

            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    DecrementCount();
                    break;
                }

                current = current.Next;
            }
        }

        public ISingleLinkedListNode<int> Find(int value)
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

            var current = this.Head;
            for (int i = 0; i < Count; i++)
            {
                result[i] = current.Value;
                current = current.Next;
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