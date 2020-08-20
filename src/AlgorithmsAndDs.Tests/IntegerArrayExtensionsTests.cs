using System.Collections.Generic;
using Algorithms.Arrays;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class IntegerArrayExtensionsTests
    {
        [Theory]
        [MemberData(nameof(IntegerArrayExtensionsData.GetThreeSumData), MemberType = typeof(IntegerArrayExtensionsData))]
        public void Test_3_Sum(int[] nums, IList<IList<int>> expectedValue)
        {
            var result = nums.ThreeSumUsingTwoSum();
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [MemberData(nameof(IntegerArrayExtensionsData.GetPlusOne), MemberType = typeof(IntegerArrayExtensionsData))]
        public void Test_PlusOne(int[] nums, int[] expectedValue)
        {
            var result = nums.PlusOne();
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [MemberData(nameof(IntegerArrayExtensionsData.GetRangeData), MemberType = typeof(IntegerArrayExtensionsData))]
        public void Test_Range(int[] nums, int target, int[] expectedValue)
        {
            var result = nums.Range(target);
            Assert.Equal(expectedValue, result);
        }

        // [Theory]
        // [MemberData(nameof(IntegerArrayExtensionsData.GetKClosestData), MemberType = typeof(IntegerArrayExtensionsData))]
        // public void Test_KClosest(int[] nums, int k, int target, int[] expectedValue)
        // {
        //     var result = nums.FindKClosest(k, target);
        //     Assert.Equal(expectedValue, result);
        // }
    }
}
