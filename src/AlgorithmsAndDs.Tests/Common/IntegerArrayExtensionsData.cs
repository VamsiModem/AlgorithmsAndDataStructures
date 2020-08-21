using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDs.Tests
{
    public class IntegerArrayExtensionsData
    {
        public static IEnumerable<object[]> GetThreeSumData()
        {

            yield return new object[]{
                new int[] {-1, 0, 1, 2, -1, -4},
                new List<IList<int>>
                {
                    new List<int>{-1, 0, 1},
                    new List<int>{-1, -1, 2},
                }
            };
        }

        public static IEnumerable<object[]> GetPlusOne()
        {

            yield return new object[]{
                new int[] {1, 2, 3},
                new int[] {1, 2, 4},
            };
            yield return new object[]{
                new int[] {1, 2, 9},
                new int[] {1, 3, 0},
            };
            yield return new object[]{
                new int[] {9,9},
                new int[] {1, 0, 0},
            };
        }

        public static IEnumerable<object[]> GetRangeData()
        {

            yield return new object[]{
                new int[] {1, 2, 2, 3},
                2,
                new int[] {1,2},
            };
            yield return new object[]{
                new int[] {5,7,7,8,8,10},
                8,
                new int[] {3,4},
            };
            yield return new object[]{
                new int[] {5,7,7,8,8,10},
                6,
                new int[] {-1,-1},
            };
        }

        public static IEnumerable<object[]> GetKClosestData()
        {

            yield return new object[]{
                new int[] {1,2,3,4,5},
                4,
                3,
                new int[] {1,2,3,4},
            };
            yield return new object[]{
                 new int[] {1,2,3,4,5},
                4,
                -1,
                new int[] {1,2,3,4},
            };
        }

        public static IEnumerable<object[]> MergeSortIndiciesData()
        {

            yield return new object[]{
                new int[] {5,2,6,1},
                new int[] {2,1,1,0},
            };
        }
    }
}
