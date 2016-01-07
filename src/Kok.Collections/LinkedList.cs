using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kok.Collections
{
    public class LinkedList<T> : ICollection<T>
    {
        private Node first;
        private Node last;

        public IEnumerator<T> GetEnumerator()
        {
            return Nodes.Select(node => node.Value).GetEnumerator();
        }

        private IEnumerable<Node> Nodes
        {
            get
            {
                var current = first;
                while (current != null)
                {
                    yield return current;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            var next = first;
            first = new Node(item, null, first);
            if (next == null)
            {
                last = first;
            }
            else
            {
                next.Previous = first;
            }
        }

        public void Clear()
        {
            first = null;
        }

        public bool Contains(T item)
        {
            return Nodes.Any(node => Equals(item, node.Value));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            var enumerator = GetEnumerator();
            for (var i = arrayIndex; i < array.Length && enumerator.MoveNext(); i++)
            {
                array[i] = enumerator.Current;
            }
        }

        public bool Remove(T item)
        {
            Node previous = null;
            var current = first;
            while (current != null)
            {
                var next = current.Next;
                if (Equals(item, current.Value))
                {
                    if (previous == null)
                    {
                        first = current.Next;
                    }
                    else
                    {
                        previous.Next = next;
                        if (next == null)
                        {
                            last = previous;
                        }
                        else
                        {
                            next.Previous = previous;
                        }
                    }
                    return true;
                }
                previous = current;
                current = next;
            }
            return false;
        }

        public int Count => Nodes.Count();

        public bool IsReadOnly => false;

        public void AddLast(T item)
        {
            var previous = last;
            last = new Node(item, last, null);
            if (previous == null)
            {
                first = last;
            }
            else
            {
                previous.Next = last;
            }
        }

        private class Node
        {
            public Node(T value, Node previous, Node next)
            {
                Previous = previous;
                Next = next;
                Value = value;
            }

            public Node Next { get; set; }

            public Node Previous { get; set; }
            public T Value { get; }
        }
    }
}