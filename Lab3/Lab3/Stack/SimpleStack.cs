using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.SimpleStack
{
    public class SimpleStack<T>
    {
        public SimpleStackElement<T> Head { get; set; } // initializing top stack element
        public SimpleStack() // stack constructor
        {
            Head = null;
        }

        // Add element to stack
        public void Push(T value)
        {
            var element = new SimpleStackElement<T>(value);
            element.Next = Head;
            Head = element;
        }

        // Delete element from stack
        public T Pop()
        {
            if (Head == null)
            {
                throw new Exception("Stack is empty");
            }
            var returnElement = Head;
            Head = Head.Next;
            return returnElement.Value;
        }
        // Empty stack element
        public bool Empty()
        {
            return Head == null;
        }
    }
}
