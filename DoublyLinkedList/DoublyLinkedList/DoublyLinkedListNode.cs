using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class LinkedListNode<T>
    {
        private T item;

        

        public LinkedListNode(T item)
        {
            this.item = item;
        }

        public T Value
        {
            get;set;
        }

        public LinkedListNode<T> Next
        {
            get;
            set;
        }

        public LinkedListNode<T> Previous
        {
            set;
            get;
        }
    }
}
