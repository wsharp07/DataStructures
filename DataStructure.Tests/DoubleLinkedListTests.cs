using System.Linq;
using LinkedList.Lib;
using Xunit;

namespace DataStructure.Tests
{
    public class DoubleLinkedListTests
    {
        [Fact]
        public void InsertFirst_Expect_EqualHead()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);

            Assert.NotNull(linkedList.Head);
            Assert.Equal(2, linkedList.Head.Value);
        }

        [Fact]
        public void InsertLast_Expect_EqualTail()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);

            Assert.NotNull(linkedList.Tail);
            Assert.Equal(2, linkedList.Tail.Value);
        }

        [Fact]
        public void InsertFirstTwoValues_Expect_LastEqualHead_FirstEqualTail()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            Assert.Equal(2, linkedList.Tail.Value);
            Assert.Equal(3, linkedList.Head.Value);
        }

        [Fact]
        public void InsertFirstTwoValues_Expect_LastReferencePrevious()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            Assert.Equal(3, linkedList.Tail.Previous.Value);
        }

        [Fact]
        public void InsertLastTwoValues_Expect_LastEqualTail_FirstEqualHead()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(3);

            Assert.Equal(2, linkedList.Head.Value);
            Assert.Equal(3, linkedList.Tail.Value);
        }

        [Fact]
        public void InsertLastTwoValues_Expect_LastReferencePrevious()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(3);

            Assert.Equal(2, linkedList.Tail.Previous.Value);
        }

        [Fact]
        public void InsertFirstTwoValues_Expect_CountEqualTwo()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void InsertLastTwoValues_Expect_CountEqualTwo()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(3);

            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void LinkedListToArray_Expect_AllValuesIncluded()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(3);
            linkedList.InsertFirst(6);

            var arr = linkedList.ToArray();
            Assert.Equal(6, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
        }

        [Fact]
        public void RemoveValue_Expect_ValueWasRemoved()
        {
            int valueToBeRemoved = 3;
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(valueToBeRemoved);
            linkedList.Remove(valueToBeRemoved);

            var exists = linkedList.ToArray().Any(x => x == valueToBeRemoved);

            Assert.False(exists);
        }

        [Fact]
        public void RemoveValue_Expect_CountDecreasesBy1()
        {
            int valueToBeRemoved = 3;
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertLast(2);
            linkedList.InsertLast(valueToBeRemoved);
            linkedList.Remove(valueToBeRemoved);

            Assert.Equal(1, linkedList.Count);
        }

        [Fact]
        public void InsertThree_Expect_FindThree()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            var valueFound = linkedList.Find(3);

            Assert.NotNull(valueFound);
            Assert.Equal(3, valueFound.Value);
        }

        [Fact]
        public void InsertNodeInMiddle_Expect_OrderPersisted()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertAfter(3, 1);

            var arr = linkedList.ToArray();
            Assert.Equal(3, arr[0]);
            Assert.Equal(1, arr[1]);
            Assert.Equal(2, arr[2]);
        }

        [Fact]
        public void InsertNodeInMiddle_Expect_ReferencePrevious()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertAfter(3, 1);

            var nodeInserted = linkedList.Find(1);
            Assert.Equal(3, nodeInserted.Previous.Value);
        }

        [Fact]
        public void InsertNodeAfterInMiddle_Expect_CorrectCount()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertAfter(3, 1);

            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void InsertNodeBeforeInMiddle_Expect_OrderPersisted()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertBefore(2, 1);

            var arr = linkedList.ToArray();
            Assert.Equal(3, arr[0]);
            Assert.Equal(1, arr[1]);
            Assert.Equal(2, arr[2]);
        }

        [Fact]
        public void InsertNodeBeforeInMiddle_Expect_ReferencePrevious()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertBefore(2, 1);

            var nodeInserted = linkedList.Find(1);
            Assert.Equal(3, nodeInserted.Previous.Value);
        }

        [Fact]
        public void InsertNodeBeforeInMiddle_Expect_CorrectCount()
        {
            var linkedList = new WsDoubleLinkedList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(3);

            linkedList.InsertBefore(2, 1);

            Assert.Equal(3, linkedList.Count);
        }
    }
}