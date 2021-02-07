using System;

namespace Assignment3
{
    public class Queue<T>
    {
        public int Size { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public Queue()
        {
            Clear();
        }

        public void Enqueue(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (Size != 0) Tail.Next = newNode;
            else Head = newNode;
            Tail = newNode;
            Size++;

        }

        public T Front()
        {
            if (IsEmpty()) throw new ApplicationException();

            return Head.Element;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new ApplicationException();
            T temp = Head.Element;
            Head = Head.Next;
            if (Size == 1)
            {
                Tail = null;
            }
            Size--;

            return temp;
        }

        public void Clear()
        {
            Size = 0;
            Head = null;
            Tail = null;
        }

        public int GetSize()
        {
            return Size;
        }

        public Node<T> GetHead()
        {
            return Head;
        }

        public Node<T> GetTail()
        {
            return Tail;
        }

        public Boolean IsEmpty()
        {
            return (Head == null && Size == 0);
        }

    }
}
