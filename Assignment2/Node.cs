using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Node<T>
    {

        /// <summary>
        /// Returns the reference to previous node 
        /// </summary>
        public Node<T> Previous { get; set; }

        ///// <summary>
        ///// Returns the reference to next node
        ///// </summary>
        //public Node<T> Next { get; set; }

        /// <summary>
        /// Returns the element (data)
        /// </summary>
        public T Element { get; set; }

        /// <summary>
        /// Constructor, initializes private fields
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Constructor, initializes only the passed parameter
        /// </summary>
        /// <param name="element"></param>
        public Node(T element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Constructor, initializes private fields using parameter values
        /// </summary>
        /// <param name="element"></param>
        /// <param name="previousNode"></param>
        /// <param name="next"></param>
        public Node(T element, Node<T> previousNode) //
        {
            this.Previous = previousNode;
            //this.Next = nextNode;
            this.Element = element;
        }

    }
}
