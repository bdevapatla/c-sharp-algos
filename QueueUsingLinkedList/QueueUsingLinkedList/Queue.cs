using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.LinkedList
{
    public class Queue<T>: IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            T _item = _list.First.Value;
            _list.RemoveFirst();
            return _item;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
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
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

       
    }
}
