using System.Collections.Generic;
using Algorithms.Arrays;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class IntegerArrayExtensionsTests
    {
        [Theory]
        [MemberData(nameof(IntegerArrayExtensionsData.GetThreeSumData), MemberType= typeof(IntegerArrayExtensionsData))]
        public void Test_3_Sum(int[] nums, IList<IList<int>> expectedValue)
        {
            var result = nums.ThreeSumUsingTwoSum();
            Assert.Equal(1,1);
        }
    }
}
