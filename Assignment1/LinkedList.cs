using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class LinkedList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Return the Head node
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// Return the Tail node
        /// </summary>
        public Node<T> Tail { get; set; }
        /// <summary>
        /// Return the count of the number of nodes in the list
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Constructor, initializes private fields
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Return the element in the Head node
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            try
            {
                return this.Head.Element;
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        /// <summary>
        /// Return the element in the Tail node
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            try
            {
                return this.Tail.Element;

            }
            catch
            {
                throw new ApplicationException();
            }
        }

        /// <summary>
        /// Set Head node element to parameter value
        /// </summary>
        /// <param name="element"></param>
        public T SetFirst(T element)
        {
            try
            {
                T oldElement = this.Head.Element;
                this.Head.Element = element;
                return oldElement;

            }
            catch
            {
                throw new ApplicationException();
            }

        }

        /// <summary>
        /// Set Tail node element to parameter value
        /// </summary>
        /// <param name="element"></param>
        public T SetLast(T element)
        {
            try
            {
                T oldElement = this.Tail.Element;
                this.Tail.Element = element;
                return oldElement;
            }
            catch
            {
                throw new ApplicationException();
            }

        }

        /// <summary>
        /// Creates a new Node with the new element and adds it to the Head of the list.
        /// </summary>
        /// <param name="element"></param>
        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);
            //node.Element = element;
            if (Size == 0) // if empty list
            {
                this.Head = newNode;
                this.Tail = newNode;
                this.Size = 1;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head.Previous = newNode;
                this.Head = newNode;
                this.Size += 1;
            }
        }

        /// <summary>
        /// Return true if the list is empty, else return false
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Size == 0; 
            //if (Tail == null && Head == null)
            //{
            //    return true;
            //}
            //else
            //    return false;
        }


        /// <summary>
        /// Empty all elements from the list
        /// </summary>
        public void Clear()
        {
            this.Tail = null;
            this.Head = null;
            this.Size = 0;
        }

        /// <summary>
        /// Adds new element to the Tail of the list
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(T element)
        {
            AddMiddle(element, Tail, null);
            //Node<T> newNode = new Node<T>(element);
            ////node.Element = element;
            //if (Size == 0) // if empty list
            //{
            //    this.Head = newNode;
            //    this.Tail = newNode;
            //    this.Size = 1;
            //}
            //else
            //{
            //    //Node<T> oldNode = this.Tail;
            //    this.Tail.Next = newNode;
            //    newNode.Previous = this.Tail;
            //    this.Tail = newNode;
            //    this.Size += 1;
            //}
        }


        public T RemoveFirst()
        {
            return RemoveNode(Head);
            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}
            //T tempElement = this.Head.Element;
            //if (this.Size > 1)
            //{
            //    this.Head = Head.Next;
            //    this.Head.Previous = null;
            //    this.Size -= 1;
            //}
            //else
            //{
            //    Clear();
            //}
            
            //return tempElement;
        }

        public T RemoveLast()
        {
            return RemoveNode(Tail);
            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}
            //T tempElement = this.Tail.Element;
            //if (this.Size > 1)
            //{
            //    this.Tail = Tail.Previous;
            //    this.Tail.Next = null;
            //    this.Size -= 1;
            //}
            //else
            //{
            //    this.Head = null;
            //    this.Tail = null;
            //    this.Size = 0;
            //}
            //return tempElement;
        }


        public T Get(int pos)
        {
            return GetNodeByPosition(pos).Element;
        }

        private Node<T> GetNodeByPosition(int pos)
        {
            if (IsEmpty() || pos < 1 || pos > Size)
            {
                throw new ApplicationException();
            }
            Node<T> foundNode = this.Head;
            for (int j = 0; j < pos - 1; j++)
            {
                foundNode = foundNode.Next;
            }
            return foundNode;
            //if (pos < Size / 2)
            //{
            //}
            //else
            //{
            //    Node<T> foundNode = this.Tail;
            //    for (int j = Size; j > pos; j--)
            //    {
            //        foundNode = foundNode.Previous;
            //    }
            //    return foundNode;

            //}
        }

        public void AddAfter(T element, int pos)
        {
            //if (IsEmpty() || pos < 0 || pos > Size)
            //{
            //    throw new ApplicationException();
            //}
            //else
            //{   
            Node<T> toAdd = new Node<T>();
            toAdd.Element = element; //11
            if (pos == Size) //4
            {
                this.Tail.Next = toAdd;
                toAdd.Previous = this.Tail;
                toAdd.Next = default;
                this.Tail = toAdd;
            }
            else
            {
                //Node<T> currNode = this.Head;
                //int currIndex = 1;
                //while (currIndex != pos)
                //{
                //    currNode = currNode.Next;

                //    currIndex++;
                //}
                Node<T> currNode = GetNodeByPosition(pos);
                Node<T> nextNode = currNode.Next;

                toAdd.Next = nextNode;
                toAdd.Previous = currNode;

                currNode.Next = toAdd;
                nextNode.Previous = toAdd;
            }
            Size++;
            //}
        }
        public void AddBefore(T element, int pos)
        {
            //if (IsEmpty() || pos < 0 || pos > Size)
            //{
            //    throw new ApplicationException();
            //}
            //else
            //{
            //Node<T> toAdd = new Node<T>(element);
            //toAdd.Element = element; //11
            if (pos == 1) //4
            {
                AddFirst(element);
                //this.Head.Previous = toAdd;
                //toAdd.Next = this.Head;
                //this.Head = toAdd;
            }
            else
            {
                //Node<T> currNode = this.Head;
                //int currIndex = 1;
                //while (currIndex != pos)
                //{
                //    currNode = currNode.Next;

                //    currIndex++;
                //}
                Node<T> toAdd = new Node<T>(element);
                Node<T> currNode = GetNodeByPosition(pos);
                Node<T> beforeNode = currNode.Previous;

                toAdd.Previous = beforeNode;
                toAdd.Next = currNode;

                currNode.Previous = toAdd;
                beforeNode.Next = toAdd;
                Size++;
            }
            // }
        }

        public T Remove(int pos)
        {
            var currentNode = GetNodeByPosition(pos);
            //if (IsEmpty() || pos < 0 || pos == 0 || pos > Size)
            //{
            //    throw new ApplicationException();
            //}

            //else
            return RemoveNode(currentNode);

        }

        private T RemoveNode(Node<T> currentNode)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            T oldElement = currentNode.Element;
            Node<T> prev = currentNode.Previous;
            Node<T> next = currentNode.Next;

            if (prev == null)
            {
                Head = Head.Next;
            }
            else
            {
                prev.Next = next;
            }

            if (next ==  null)
            {
                Tail = Tail.Previous;
            }
            else
            {
                next.Previous = prev;
            }

            Size--;
                
            //if (Size == 1)
            //{
            //    Clear();
            //}
            //else if (currentNode == Tail)
            //{
            //    Size--;
            //    this.Tail = this.Tail.Previous;
            //    this.Tail.Next = null;
            //}
            //else if (currentNode == Head)
            //{
            //    Size--;
            //    this.Head = this.Head.Next;
            //    this.Head.Previous = null;
            //}
            //else
            //{
            //    Size--;
            //    //var currentNode = this.Head;
            //    //for (int i = 0; i < pos - 1; i++)
            //    //{
            //    //    currentNode = currentNode.Next;
            //    //}
            //    currentNode.Previous.Next = currentNode.Next;
            //    currentNode.Next.Previous = currentNode.Previous;
            //}
            return oldElement;
        }

        public T Set (T element, int pos)
        {
            Node<T> node = GetNodeByPosition(pos);
            T old = node.Element;
            node.Element = element;
            return old;
            //if (IsEmpty() || pos < 0 || pos == 0 || pos > Size)
            //{
            //    throw new ApplicationException();
            //}
            //T oldNode = Get(pos);
            //Node<T> currNode = Head;
            //int currIndex = 1;
            //while (currIndex != pos)
            //{
            //    currNode = currNode.Next;
            //    currIndex++;
            //}
            //currNode.Element = element;
            //return oldNode;

        }

        public T Get(T element)
        {
            return GetNodeByElement(element).Element;
        }

        private Node<T> GetNodeByElement(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            //bool flag = false;
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            for (var currNode = this.Head; currNode != null; currNode = currNode.Next)
            {
                if (currNode.Element.CompareTo(element) == 0) // similar to Equal
                {
                    return currNode;
                }
            }
            throw new ApplicationException();
        }

        public void AddAfter(T element, T oldElement)
        {
            Node<T> node = GetNodeByElement(oldElement);
            AddMiddle(element, node, node.Next);
            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}

            //if (oldElement == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //bool isAdd = false;
            //var currNode = this.Head;
            //while (currNode != null)
            //{
            //    if (currNode.Element.Equals(oldElement))
            //    {
            //        Node<T> toAdd = new Node<T>(element);
            //        if (currNode != this.Tail)
            //        {
            //            var nextNode = currNode.Next;
            //            toAdd.Next = nextNode;
            //            nextNode.Previous = toAdd;

            //            currNode.Next = toAdd;
            //            toAdd.Previous = currNode;
            //        }
            //        else
            //        {
            //            currNode.Next = toAdd;
            //            toAdd.Previous = currNode;

            //            this.Tail = toAdd;
            //        }
            //        this.Size++;
            //        isAdd = true;
            //        break;
            //    }
            //    currNode = currNode.Next;
            //}

            //if (!isAdd)
            //{
            //    throw new ApplicationException();
            //}

        }

        public void AddBefore(T element, T oldElement)
        {
            Node<T> node = GetNodeByElement(oldElement);
            AddMiddle(element, node.Previous, node);

            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}
            //if (oldElement == null) {
            //    throw new ArgumentNullException();
            //}
            //var isAdd = false;
            //for (var currNode = this.Head; currNode != null; currNode = currNode.Next)
            //{

            //    Node<T> toAdd = new Node<T>(element);
            //    if (currNode.Element.Equals(oldElement))
            //    {
            //        if (currNode != this.Head)
            //        {
            //            currNode.Previous.Next = toAdd;
            //            toAdd.Previous = currNode.Previous;

            //            currNode.Previous = toAdd;
            //            toAdd.Next = currNode;
            //        }
            //        else
            //        {
            //            currNode.Previous = toAdd;
            //            toAdd.Next = currNode;

            //            this.Head = toAdd;
            //        }
            //        this.Size++;
            //        isAdd = true;
            //        break;
            //    }
            //}
            //if (!isAdd)
            //{
            //    throw new ApplicationException();
            //}
        }

        public T Remove(T element)
        {
            Node<T> nodeToRemove = GetNodeByElement(element);
            return RemoveNode(nodeToRemove);

            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}
            //for (var currNode = this.Head; currNode != null; currNode = currNode.Next)
            //{
            //    if (currNode.Element.CompareTo(element) == 0)
            //    {
            //        if(Size ==1)
            //        {
            //            Clear();
            //        }

            //        else if (currNode.Element.CompareTo(this.Head.Element) == 0)
            //        {
            //            RemoveFirst();
            //        }
            //        else if (currNode.Element.CompareTo(this.Tail.Element) == 0)
            //        {
            //            RemoveLast();
            //        }
            //        else
            //        {
            //            Size--;
            //            currNode.Previous.Next = currNode.Next;
            //            currNode.Next.Previous = currNode.Previous;

            //        }
            //        return element;                    
            //    }
            //}
            //throw new ApplicationException();
        }

        public T Set(T element, T oldElement)
        {
            Node<T> node = GetNodeByElement(oldElement);
            T returnedElement = node.Element;
            node.Element = element;
            return returnedElement;

            //if (IsEmpty())
            //{
            //    throw new ApplicationException();
            //}

            //if (oldElement == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //Node<T> toSet = new Node<T>(element);
            //for (var currNode = this.Head; currNode != null; currNode = currNode.Next)
            //{
            //    if (currNode.Element.CompareTo(oldElement) == 0)
            //    {

            //        if (currNode.Element.CompareTo(this.Head.Element) == 0)
            //        {
            //            oldElement = this.Head.Element;
            //            this.Head.Element = element;
            //        }
            //        else if (currNode.Element.CompareTo(this.Tail.Element) == 0)
            //        {
            //            oldElement = this.Tail.Element;
            //            this.Tail.Element = element;
            //        }
            //        else
            //        {
            //            currNode.Previous.Next = currNode.Next;
            //            currNode.Next.Previous = currNode.Previous;
            //        }
            //        return oldElement;
            //    }
            //}
            //throw new ApplicationException();
        }
        public void AddMiddle( T element, Node<T> beforeNode, Node<T> afterNode)
        {
            Node<T> newNode = new Node<T>(element, beforeNode, afterNode);
            if(beforeNode == null)
            {
                Head = newNode;
            }
            else
            {
                beforeNode.Next = newNode; 
            }

            if(afterNode == null)
            {
                Tail = newNode;
            }
            else
            {
                afterNode.Previous = newNode;
            }
            this.Size += 1;
        }
        public void Insert(T element)
        {
            Node<T> toAdd = new Node<T>(element);
            Node<T> currNode = this.Head;
            //if (IsEmpty())
            //{
            //    this.Head = toAdd;
            //    this.Tail = toAdd;
            //    this.Size = 1;
            //}
            while (currNode != null && toAdd.Element.CompareTo(currNode.Element) > 0)
            {
                currNode = currNode.Next;
            }
            if(currNode == null)
            { // is empty list OR largest Element:
                this.AddLast(element);
            }
            else
            {
                this.AddMiddle(element, currNode.Previous, currNode);
            }

        }

        public void SortAscending()
        {
            Node<T> node = Head;
            Clear();

            while (node != null)
            {
                Insert(node.Element);
                node = node.Next;
            }

        //    int swapped;
        //    Node<T> currNode;
        //    Node<T> lastNode = null;
        //    if (this.Head == null)
        //    {
        //        IsEmpty();
        //    }
        //    else
        //    {
        //        do
        //        {
        //            swapped = 0;
        //            currNode = this.Head;

        //            while (currNode.Next != lastNode)
        //            {
        //                if (currNode.Element.CompareTo(currNode.Next.Element) == 1)
        //                {
        //                    T t = currNode.Element;
        //                    currNode.Element = currNode.Next.Element;
        //                    currNode.Next.Element = t;
        //                    swapped = 1;
        //                }
        //                currNode = currNode.Next;
        //            }
        //            lastNode = currNode;
        //        }
        //        while (swapped != 0);
        //    }

        }
        //public int GetPositionOfNode(T element)
        //{
        //    int i = 0;
        //    Node<T> currNode = this.Head;
        //    // search for value or end of list, counting along way
        //    while (currNode != null && !currNode.Element.Equals(element))
        //    {
        //        currNode = currNode.Next;
        //        i++;
        //    }
        //    // currNode points to value, i is index
        //    if (currNode == null)
        //    {   // value not found, return indicator
        //        return -1;
        //    }
        //    else
        //    {                
        //        // value found, return index
        //        return i;
        //    }
        //}
    }
}
