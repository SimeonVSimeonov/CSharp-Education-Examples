﻿namespace P09LinkedListTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Valie = value;
            }

            public T Valie { get; set; }
            public Node Next { get; set; }
        }

        private Node Head { get; set; }

        private Node Tail { get; set; }

        public int Count { get; set; }

        public void Add(T item)
        {
            if (Count == 0)
            {
                Head = Tail = new Node(item);
            }
            else
            {
                var oldTail = this.Tail;
                oldTail.Next = this.Tail = new Node(item);
            }

            Count++;
        }

        public void Remove(T item)
        {
            if (this.Count == 0)
            {
                return;
            }

            if (this.Head.Valie.CompareTo(item) == 0)
            {
                this.Head = this.Head.Next;
                Count--;
                return;
            }

            Node previous = this.Head;
            var current = this.Head.Next;

            while (current != null)
            {
                if (current.Valie.CompareTo(item) == 0)
                {
                    previous.Next = current.Next;
                    Count--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;

            while (current != null)
            {
                yield return current.Valie;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
