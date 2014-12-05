using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mono
{
    public class ConcurrentStack<T> : IProducerConsumerCollection<T>, IEnumerable<T>,
                                      ICollection, IEnumerable
    {
        class Node
        {
            public T Value = default(T);
            public Node Next = null;
        }

        Node head = null;

        int count;

        public ConcurrentStack()
        {
        }

        public ConcurrentStack(IEnumerable<T> enumerable)
        {
            foreach (T item in enumerable)
                Push(item);
        }

        bool IProducerConsumerCollection<T>.TryAdd(T elem)
        {
            Push(elem);
            return true;
        }

        public void Push(T element)
        {
            Node temp = new Node();
            temp.Value = element;
            do
            {
                temp.Next = head;
            } while (Interlocked.CompareExchange(ref head, temp, temp.Next) != temp.Next);

            Interlocked.Increment(ref count);
        }

        public void PushRange(T[] values)
        {
            PushRange(values, 0, values.Length);
        }

        public void PushRange(T[] values, int start, int length)
        {
            Node insert = null;
            Node first = null;

            for (int i = start; i < length; i++)
            {
                Node temp = new Node();
                temp.Value = values[i];
                temp.Next = insert;
                insert = temp;

                if (first == null)
                    first = temp;
            }

            do
            {
                first.Next = head;
            } while (Interlocked.CompareExchange(ref head, insert, first.Next) != first.Next);

            Interlocked.Add(ref count, length);
        }

        public bool TryPop(out T value)
        {
            Node temp;
            do
            {
                temp = head;
                // The stak is empty
                if (temp == null)
                {
                    value = default(T);
                    return false;
                }
            } while (Interlocked.CompareExchange(ref head, temp.Next, temp) != temp);

            Interlocked.Decrement(ref count);

            value = temp.Value;
            return true;
        }

        public int TryPopRange(T[] values)
        {
            return TryPopRange(values, 0, values.Length);
        }

        public int TryPopRange(T[] values, int startIndex, int count)
        {
            Node temp;
            Node end;

            do
            {
                temp = head;
                if (temp == null)
                    return -1;
                end = temp;
                for (int j = 0; j < count - 1; j++)
                {
                    end = end.Next;
                    if (end == null)
                        break;
                }
            } while (Interlocked.CompareExchange(ref head, end, temp) != temp);

            int i;
            for (i = startIndex; i < count && temp != null; i++)
            {
                values[i] = temp.Value;
                temp = temp.Next;
            }

            return i - 1;
        }

        public bool TryPeek(out T value)
        {
            Node myHead = head;
            if (myHead == null)
            {
                value = default(T);
                return false;
            }
            value = myHead.Value;
            return true;
        }

        public void Clear()
        {
            // This is not satisfactory
            count = 0;
            head = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)InternalGetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InternalGetEnumerator();
        }

        IEnumerator<T> InternalGetEnumerator()
        {
            Node my_head = head;
            if (my_head == null)
            {
                yield break;
            }
            else
            {
                do
                {
                    yield return my_head.Value;
                } while ((my_head = my_head.Next) != null);
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            T[] dest = array as T[];
            if (dest == null)
                return;
            CopyTo(dest, index);
        }

        public void CopyTo(T[] dest, int index)
        {
            IEnumerator<T> e = InternalGetEnumerator();
            int i = index;
            while (e.MoveNext())
            {
                dest[i++] = e.Current;
            }
        }

        bool ICollection.IsSynchronized
        {
            get { return true; }
        }

        bool IProducerConsumerCollection<T>.TryTake(out T item)
        {
            return TryPop(out item);
        }

        object syncRoot = new object();
        object ICollection.SyncRoot
        {
            get { return syncRoot; }
        }

        public T[] ToArray()
        {
            T[] dest = new T[count];
            CopyTo(dest, 0);
            return dest;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }
    }
}
