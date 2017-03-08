namespace LinkedList.Lib
{
    public class SingleLinkedListNode : ISingleLinkedListNode<int>
    {
        public ISingleLinkedListNode<int> Next { get; set; }
        public int Value { get; }

        public SingleLinkedListNode(int value)
        {
            Value = value;
        }
    }
}