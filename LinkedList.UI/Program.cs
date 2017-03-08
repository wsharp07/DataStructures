using System;
using System.Collections.Generic;
using LinkedList.Lib;

namespace LinkedList.UI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var linkedList = new LList();
            linkedList.InsertFirst(2);
            linkedList.InsertFirst(4);

            foreach (var i in linkedList.ToArray())
            {
                Console.WriteLine(i);
            }
        }
    }
}