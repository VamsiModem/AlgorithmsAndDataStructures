using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Arrays;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class SingleLinkedListExtensionsData
    {
        public static IEnumerable<object[]> GetSwapNodesData()
        {

            yield return new object[]{
                new int[] {1,2,3,4}.ToSingleLinkedList(),
                new int[] {2,1,4,3}.ToSingleLinkedList()
            };
        }
    }
}
