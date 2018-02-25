using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueUsingLinkedList
{
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            //there are no items in the queue 
            if (_list.Count == 0)
            {
                _list.AddFirst(item);
            }
            else
            {
                var current = _list.First; //This is the highest priority item until this point 
                //Below while loop finds an item in list that has lower priority than the item that we are trying to insert 
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                //If we did not find any item with lower priority than the one 
                //we are trying to insert then we actually reached the end of the queue 
                if (current == null)
                {
                    _list.AddLast(item);
                }
                else
                {
                    //if we did find one then add item just before the one that has lower priority 
                    //this is IN-PLACE 
                    _list.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is currently empty");
            }

            T item = _list.First.Value;
            _list.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is currently empty");
            }
            return _list.First.Value;
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
           return  _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
