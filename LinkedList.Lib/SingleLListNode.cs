namespace LinkedList.Lib
{
    public class SingleLListNode : ISingleLListNode<int>
    {
        public ISingleLListNode<int> Next { get; set; }
        public int Value { get; }

        public SingleLListNode(int value)
        {
            Value = value;
        }
    }
}