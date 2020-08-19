using Algorithms.LinkedLists;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class LinkedListExtensionsTests
    {
        [Theory]
        [MemberData(nameof(SingleLinkedListExtensionsData.GetSwapNodesData), MemberType = typeof(SingleLinkedListExtensionsData))]
        public void Test_Swap_Nodes_In_Pairs(SingleLinkedList.Node value, SingleLinkedList.Node expected)
        {
            var result = value.SwapNodePairs();
            Assert.True(result.Equals(expected));
        }
    }
}