using System;
using Queue.Lib;
using Xunit;

namespace DataStructure.Tests
{
    public class QueueTests
    {
        [Fact]
        public void Enqueue_Expect_EqualDequeue()
        {
            var expected = 12;
            var queue = new WsQueue<int>(2);
            queue.Enqueue(expected);
            var sut = queue.Dequeue();

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void EqueueTwo_Expect_DequeueEqualsFirst()
        {
            var expected = 7;
            var queue = new WsQueue<int>(2);
            queue.Enqueue(expected);
            queue.Enqueue(42);
            var sut = queue.Dequeue();

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void EnqueueMoreThanSize_Expect_AutoResize()
        {
            var queue = new WsQueue<int>(3);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Dequeue();
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(11);

            var result = queue.Dequeue();
            Assert.Equal(8, result);
        }

        [Fact]
        public void EnqueueAfterResize_Expect_CorrectDequeue()
        {
            var queue = new WsQueue<int>(1);
            queue.Enqueue(7);
            queue.Enqueue(8);

            Assert.Equal(7, queue.Dequeue());
            Assert.Equal(8, queue.Dequeue());
        }

        [Fact]
        public void EnqueueTwo_Expect_CorrectCount()
        {
            var queue = new WsQueue<int>(1);
            queue.Enqueue(7);
            queue.Enqueue(8);

            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void EnqueueTwoDequeueOne_Expect_CorrectCount()
        {
            var queue = new WsQueue<int>(2);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Dequeue();

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void EnqueueAndPeek_Expect_CorrectValue()
        {
            var expected = 7;
            var queue = new WsQueue<int>(2);
            queue.Enqueue(expected);
            var sut = queue.Peek();

            Assert.Equal(expected, sut);
        }

        [Fact]
        public void EnqueueAndPeek_Expect_CountCorrect()
        {
            var queue = new WsQueue<int>(2);
            queue.Enqueue(7);
            queue.Peek();

            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void InitQueueZeroLength_Expect_ArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new WsQueue<int>(0));
        }

        [Fact]
        public void DequeueEmptyQueue_Expect_InvalidOperation()
        {
            var queue = new WsQueue<int>(1);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}