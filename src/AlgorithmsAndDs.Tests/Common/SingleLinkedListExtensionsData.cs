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

        public static IEnumerable<object[]> GetNodeLengthData()
        {

            yield return new object[]{
                new int[] {1,2,3,4}.ToSingleLinkedList(),
                4
            };

             yield return new object[]{
                new int[] {}.ToSingleLinkedList(),
                0
            };
        }
        public static IEnumerable<object[]> GetRemoveDuplicatesIIData()
        {

            yield return new object[]{
                new int[] {1,2,3,3,4,4,5}.ToSingleLinkedList(),
                new int[] {1,2,5}.ToSingleLinkedList()
            };
             yield return new object[]{
                new int[] {1,1,1,2,3}.ToSingleLinkedList(),
                new int[] {2,3}.ToSingleLinkedList()
            };
        }

        
    }
}
