using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {

        T[] _items = new T[0];
        int _size = 0;
        int _head = 0;
        int _tail = -1;


        public void Enqueue(T item)
        {
            if(_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : 2 * _size;
                T[] newArray = new T[newLength];
                //Copy back from original array 
                if (_size > 0)
                {
                    int targetIndex = 0;
                    if(_tail < _head)
                    {
                        for(int i=_head; i < _size; i++)
                        {
                            newArray[targetIndex++] = _items[i];
                        }
                        for(int i=0;i < _head; i++)
                        {
                            newArray[targetIndex++] = _items[i];
                        }
                    }
                    else
                    {
                        for (int i = _head; i <= _tail; i++, targetIndex++)
                        {
                            newArray[targetIndex] = _items[i];
                        }
                    }
                    /*for (int i = 0; i < _size; i++)
                    {
                        if (_head + i < _size)
                        {
                            newArray[i] = _items[_head + i];
                        }
                        else
                        {
                            newArray[i] = _items[_head + i - _size - 1];
                        }
                    }*/
                    _head = 0;
                    _tail = targetIndex-1;                   
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                _items = newArray;
            }

            if(_tail == _items.Length - 1)
            {
                _tail = 0;
            }

            _items[_tail++] = item;           
            
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _items[_head];

            if(_head == _items.Length - 1)
            {
                //IMPORTANT: since the head is already at the end of of array
                //dequeue should take the head back to index-0
                //This is called wrapping around 
                _head = 0;
            }
            else
            {
                _head++;
            }
            _size--;
            return value;
        }

        public T Peek()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _items[_head];
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
            _size = 0;
            _head = 0;
            _tail = -1;
        }


        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                int targetIndex = 0;
                if (_tail < _head)
                {
                    for (int i = _head; i < _size; i++)
                    {
                        yield return _items[i];
                    }
                    for (int i = 0; i < _head; i++)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _head; i <= _tail; i++, targetIndex++)
                    {
                        yield return _items[i];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
