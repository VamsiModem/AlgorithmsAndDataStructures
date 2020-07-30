using System;
using System.Collections.Generic;

namespace Algorithms.Heaps
{
    public abstract class AbstractHeap
    {
        protected List<int> _elements;
        protected int _size => _elements.Count;
        protected int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        protected int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        protected int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;
        protected bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        protected bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        protected bool IsRoot(int elementIndex) => elementIndex == 0;
        protected int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        protected int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        protected int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];
        protected void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        protected bool IsEmpty() => _size == 0;

        protected int Peek()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException();

            return _elements[0];
        }
        protected int Pop()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _elements.RemoveAt(_size - 1);
            ReCalculateDown();

            return result;
        }

        protected void Add(int element)
        {
            _elements.Add(element);

            ReCalculateUp();
        }
        protected abstract void ReCalculateDown();
        protected abstract void ReCalculateUp();
    }
}