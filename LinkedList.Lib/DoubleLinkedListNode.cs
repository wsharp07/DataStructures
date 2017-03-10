namespace LinkedList.Lib
{
    public class DoubleLinkedListNode : IDoubleLinkedListNode<int>
    {
        public IDoubleLinkedListNode<int> Previous { get; set; }
        public IDoubleLinkedListNode<int> Next { get; set; }
        public int Value { get; }

        public DoubleLinkedListNode(int value)
        {
            Value = value;
        }
    }
}