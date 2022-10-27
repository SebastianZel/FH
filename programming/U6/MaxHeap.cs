using System;
using System.Collections.Generic;

namespace U6
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private List<T> _heap;

        public MaxHeap()
        {
            _heap = new();
        }

        private int Left(int i)
        {
            return 2*i + 1;
        }

        private int Right(int i)
        {
            return 2*i + 2;
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private void MaxHeapify(int i)
        {
            int left = Left(i);
            int right = Right(i);

            int highest = i;
            if (left < _heap.Count && _heap[left].CompareTo(_heap[i]) > 0)
            {
                highest = left;
            }

            if (right < _heap.Count && _heap[right].CompareTo(_heap[highest]) > 0)
            {
                highest = right;
            }

            if (highest != i)
            {
                T tmp = _heap[highest];
                _heap[highest] = _heap[i];
                _heap[i] = tmp;

                MaxHeapify(highest);
            }
        }

        public T ExtractMax()
        {
            if (_heap.Count == 0)
            {
                return default(T);
            }

            T max = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);

            MaxHeapify(0);

            return max;
        }

        public void Insert(T key)
        {
            _heap.Add(key);
            InternalIncreaseKey(_heap.Count - 1, key);
        }

        public void IncreaseKey(int i, T newKey)
        {
            if (!(i >= 0 && i < _heap.Count))
            {
                throw new HeapException("Invalid Index");
            }

            // old key is bigger than new one!
            if (_heap[i].CompareTo(newKey) > 0)
            {
                throw new HeapException("Cannot increase key!");
            }

            InternalIncreaseKey(i, newKey);
        }

        private void InternalIncreaseKey(int i, T newKey)
        {
            _heap[i] = newKey;
            while (i > 0 && _heap[Parent(i)].CompareTo(_heap[i]) < 0)
            {
                T tmp = _heap[Parent(i)];
                _heap[Parent(i)] = _heap[i];
                _heap[i] = tmp;
                i = Parent(i);
            }
        }
    public class HeapException : Exception
    {
        public HeapException(string message) : base(message)
        {

        }
    }
}
}