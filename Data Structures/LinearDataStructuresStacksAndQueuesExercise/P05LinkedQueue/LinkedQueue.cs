using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count==0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var oldTail = this.tail;
            this.tail = new QueueNode<T>(element);
            this.tail.PrevNode = oldTail;
            oldTail.NextNode = this.tail;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        T item;
        if (this.Count==0)
        {
            throw new InvalidOperationException();
        }
        else if(this.Count==1)
        {
            item = this.head.Value;
            this.head = this.tail = null;
        }
        else
        {
            item = this.head.Value;
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return item;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var currentNode = this.head;
        int index = 0;

        while (currentNode != null)
        {
            array[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;

    }


    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }
}

