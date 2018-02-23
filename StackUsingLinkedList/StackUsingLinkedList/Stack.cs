﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.List
{
    public class Stack<T> : IEnumerable<T>
    {
        //Using .NET linkedlist 
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public T Pop()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = _list.First.Value;
            _list.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
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
            return _list.GetEnumerator();
        }
    }
}
