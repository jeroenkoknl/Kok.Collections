using System;
using Kok.Collections;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Kok.Collections.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void AddTest()
        {
            LinkedList<int> list = new LinkedList<int> {1, 2, 3};
            CollectionAssert.AreEqual(new [] { 1, 2, 3 }, list);
        }

        [Test]
        public void AddFirstTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            CollectionAssert.AreEqual(new [] { 3, 2, 1 }, list);
        }

        [Test]
        public void RemoveTestMiddle()
        {
            LinkedList<int> list = new LinkedList<int> { 1, 2, 3 };
            list.Remove(2);
            CollectionAssert.AreEqual(new [] { 1, 3 }, list);
        }

        [Test]
        public void RemoveTestLast()
        {
            LinkedList<int> list = new LinkedList<int> { 1, 2, 3 };
            list.Remove(3);
            CollectionAssert.AreEqual(new[] { 1, 2 }, list);
        }

        [Test]
        public void RemoveTestFirst()
        {
            LinkedList<int> list = new LinkedList<int> { 1, 2, 3 };
            list.Remove(1);
            CollectionAssert.AreEqual(new[] { 2, 3 }, list);
        }

        [Test]
        public void RemoveLastAndAdd()
        {
            LinkedList<int> list = new LinkedList<int> { 1, 2, 3 };
            list.Remove(3);
            list.Add(4);
            CollectionAssert.AreEqual(new[] { 1, 2, 4 }, list);
        }

        [Test]
        public void RemoveFirstAndAdd()
        {
            LinkedList<int> list = new LinkedList<int> { 1, 2, 3 };
            list.Remove(1);
            list.AddFirst(0);
            CollectionAssert.AreEqual(new[] { 0, 2, 3 }, list);
        }
    }
}