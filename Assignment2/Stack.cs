using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Stack<Point> 
    {
        /// <summary>
        /// Points to the top node in the stack
        /// </summary>
        public Node<Point> Head { get; set; }

        /// <summary>
        /// Count of the number of nodes in the list, zero when the list is empty
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Constructor, initializes private fields
        /// </summary>
        public Stack(Stack<Point> stack)
        {
            Clear();
        }

        public Stack()
        {
            this.Size = Size;
            this.Head = Head;
        }

        public void Push(Point element)
        {
            //Node<Point> node = new Node<Point>(element);
            //if (this.IsEmpty())
            //{
            //    this.Head = node;
            //} else
            //{
            //    node.Previous = this.Head;
            //    this.Head = node;
            //}
            Head =  new Node<Point>(element, Head);
            this.Size++;
        }

        public Point Top()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            return this.Head.Element;
        }
        public Point Pop()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            var popNode = this.Head;
            //if (this.Size == 1)
            //{
            //    Clear();
            //} else
            //{
                this.Head = this.Head.Previous;
                this.Size--;
            //}

            return popNode.Element;
        }


        public void Clear()
        {
            this.Head = null;
            this.Size = 0;
        }

        public bool IsEmpty()
        {
            return Size == 0;
            //if (Head == null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
