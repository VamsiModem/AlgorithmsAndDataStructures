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
            throw new NotImplementedException();
        }

        protected override void ReCalculateUp()
        {
            throw new NotImplementedException();
        }
    }
}