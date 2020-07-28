using System;
using System.Collections.Generic;

namespace Algorithms.Heaps
{
    public class MaxHeap : AbstractHeap
    {
        public MaxHeap()
        {
            _elements = new List<int>();
        }

        protected override void ReCalculateDown()
        {
            var index = 0;
            while (HasLeftChild(index))
            {
                var largerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                    largerIndex = GetRightChildIndex(index);
                if (_elements[largerIndex] < _elements[index]) break;
                Swap(largerIndex, index);
                index = largerIndex;
            }
        }

        protected override void ReCalculateUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && _elements[index] > GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}