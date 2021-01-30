using System.Collections.Generic;
using Algorithms.Arrays;
using Algorithms.Strings;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        // [InlineData("1+2+3-2", 4)]
        // [InlineData("1+2+3 (-2)", 4)]
        [InlineData("2147483647", 2147483647)]
        //2147483647
        public void Test_Evaluator(string expression, int expectedValue)
        {
            var result = expression.EvaluateExpression();
            Assert.Equal(expectedValue, result);
        }

        
    }
}
