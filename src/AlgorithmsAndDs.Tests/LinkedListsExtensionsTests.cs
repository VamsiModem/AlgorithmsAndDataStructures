using Algorithms.LinkedLists;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class LinkedListExtensionsTests
    {
        [Theory]
        [MemberData(nameof(SingleLinkedListExtensionsData.GetSwapNodesData), MemberType = typeof(SingleLinkedListExtensionsData))]
        public void Test_Swap_Nodes_In_Pairs(SingleLinkedListNode value, SingleLinkedListNode expected)
        {
            var result = value.SwapNodePairs();
            Assert.True(result.Equals(expected));
        }

        [Theory]
        [MemberData(nameof(SingleLinkedListExtensionsData.GetNodeLengthData), MemberType = typeof(SingleLinkedListExtensionsData))]
        public void Test_Length(SingleLinkedListNode value, int expected)
        {
            var result = value?.Length ?? 0;
            Assert.True(result == expected);
        }
    }
}