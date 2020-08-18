using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class IntegerArrayExtensionsData
    {
        public static IEnumerable<object[]> GetThreeSumData(){
           
            yield return new object[]{
                new int[] {-1, 0, 1, 2, -1, -4}, 
                new List<IList<int>>
                {
                    new List<int>{-1, 0, 1},
                    new List<int>{-1, -1, 2},
                }
            };
        }
    } 
}
