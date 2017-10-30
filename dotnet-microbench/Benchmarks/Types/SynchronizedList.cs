using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks.Types
{
    public class SynchronizedList<T> : IList<T>
    {
        private readonly IList<T> list;
        private object syncRoot = new object();

        public SynchronizedList(IList<T> existingList)
        {
            this.list = new List<T>(existingList.Count);
            foreach (var item in existingList)
            {
                list.Add(item);
            }
        }   

        public SynchronizedList(int capacity = 4)
        {
            this.list = new List<T>(capacity);
        }

        public object SyncRoot
        {
            get { return syncRoot; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) list).GetEnumerator();
        }

        public void Add(T item)
        {
             lock (syncRoot)
                list.Add(item);
        }

        public void Clear()
        {
            lock (SyncRoot)
                list.Clear();
        }

        public bool Contains(T item)
        {
            lock (SyncRoot)
                return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (SyncRoot)
                list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            lock (SyncRoot)
                return list.Remove(item);
        }

        public int Count
        {
            get
            {
                lock (SyncRoot)
                    return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(T item)
        {
            lock (SyncRoot)
                return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            lock (SyncRoot)
                list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            lock (SyncRoot)
                list.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                lock (SyncRoot)
                    return list[index];
            }
            set
            {
                lock (SyncRoot)
                    list[index] = value;
            }
        }
    }
}
