using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<LinkedListNode<T>>, ICollection<T>
    {

        public LinkedListNode<T> Head
        {
            get;
            private set;
        }

        public LinkedListNode<T> Tail
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public void AddFirst(LinkedListNode<T> node)
        {
           if (Count == 0)
            {
                Head = Tail = node;
               
            }
           else
            {
                LinkedListNode<T> temp = Head;
                Head = node;
                temp.Previous = Head;
                Head.Next = temp;
            }

            Count++;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if(Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                LinkedListNode<T> temp = Tail;
                Tail = node;
                temp.Next = Tail;
                Tail.Previous = temp;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if(Count == 1)
            {
                Clear();
            }
            else if(Count > 1)
            {
                Head = Head.Next;
                Head.Previous = null;
                Count--;
                if(Count == 1)
                {
                    Tail = Head;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                Clear();
            }
            else if (Count > 1)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                Count--;
                if (Count == 1)
                {
                    Head = Tail;
                }
            }
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public void Add(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<LinkedListNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
           //If count > 0
           if(Count > 0)
            {
                LinkedListNode<T> current = Head;
                while(current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        LinkedListNode<T> previous = current.Previous;                        
                        current = current.Next;                       
                        if (current != null)
                        {
                            current.Previous = previous;
                            if(current.Previous == null)
                            {
                                Head = current;
                            }
                            if(current.Next == null)
                            {
                                Tail = current;
                            }
                        }                                           
                        Count--;
                        if(Count == 0)
                        {
                            Head = Tail = null;
                        }
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
