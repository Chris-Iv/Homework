using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ReversedList
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] innerCollection;
        private long start;
        private long end;

        public ReversedList(long capacity = 1)
        {
            this.start = 0;
            this.end = 0;
            this.Capacity = capacity;
            this.innerCollection = new T[this.Capacity];
        }

        public long Count { get; private set; }

        public long Capacity { get; private set; }

        public T this[long index]
        {
            get
            {
                if (index < start || index > this.end)
                {
                    throw new ArgumentOutOfRangeException("index", "Index is out of inner collection range.");
                }

                return this.innerCollection[index];
            }
            set
            {
                if (index < start || index > end)
                {
                    throw new ArgumentOutOfRangeException("index", "Index is out of inner collection range.");
                }

                this.innerCollection[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.end >= this.Capacity)
            {
                this.DoubleCapacity();
            }

            this.innerCollection[this.end] = item;
            this.Count++;
            this.end++;
        }

        public T Remove(long index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty list");
            }

            if (index >= this.end)
            {
                throw new InvalidOperationException("Could not remove element from index bigger than or equal to the index of the last added element");
            }

            T removed = this.innerCollection[this.end - index - 1];

            for (long i = this.end - index; i < this.end; i++)
            {
                this.innerCollection[i - 1] = this.innerCollection[i];
            }

            this.end--;
            this.Count--;
            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (long i = this.end - 1; i >= this.start; i--)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleCapacity()
        {
            this.Capacity *= 2;
            T[] tempArr = new T[this.Capacity];
            Array.Copy(this.innerCollection, this.start, tempArr, 0, this.Count);
            this.start = 0;
            this.end = this.Count;
            this.innerCollection = tempArr;
        }
    }
}