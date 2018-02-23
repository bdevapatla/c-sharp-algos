using System;
using System.Collections;
using System.Collections.Generic;

namespace StackUsingArray
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size;

        public void Push(T item)
        {
            if(_size == _items.Length)
            {
                int _newSize = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[_newSize];
                _items.CopyTo(newArray, 0);
                _items = newArray;

            }
            _items[_size++] = item;
            
        }

        public T Pop()
        {
            
            if(_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }           
          
            T item = _items[--_size];

            //This is minor improvement in this process from author's implementation 
            if (_size > 0 && _items.Length <= _size/4)
            {
                int _newSize = _size / 2;
                T[] newArray = new T[_newSize];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            return item;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _items[_size-1];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            /*if (!typeof(T).IsValueType)
            { 
                for (int i = 0; i < _size; i++)
                {
                        _items[i] = default(T);
                }
            }*/
            _size = 0;          
            _items = new T[_size]; 
        }

        public IEnumerator<T> GetEnumerator()
        {
           for(int i=_size-1;i >= 0; --i)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
