using System;
using Stack.Lib;
using Xunit;

namespace DataStructure.Tests
{
    public class StackTests
    {
        [Fact]
        public void PushToStack_Expect_EqualPop()
        {
            int expected = 1;
            var stack = new WsStack<int>(2);
            stack.Push(expected);
            var sut = stack.Pop();
            Assert.Equal(expected, sut);
        }

        [Fact]
        public void PushOverStack_Expect_Resize()
        {
            var stack = new WsStack<int>(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var sut = stack.Pop();
            Assert.Equal(3, sut);
        }

        [Fact]
        public void InitStackZeroLength_Expect_ArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new WsStack<int>(0));
        }

        [Fact]
        public void PopEmptyStack_Expect_InvalidOperation()
        {
            var stack = new WsStack<int>(1);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
    }
}