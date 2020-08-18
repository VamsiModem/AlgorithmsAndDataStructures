using System;
using System.Collections.Generic;

namespace AlgorithmsAndDs.Tests{
    public static class XUnitDataExtensions
    {
        public static IEnumerable<object[]> ToXUnitData<T1>(this IEnumerable<T1> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2>(this IEnumerable<ValueTuple<T1, T2>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2 };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2, T3>(this IEnumerable<ValueTuple<T1, T2, T3>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2, item.Item3 };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2, T3, T4>(this IEnumerable<ValueTuple<T1, T2, T3, T4>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2, item.Item3, item.Item4 };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2, T3, T4, T5>(this IEnumerable<ValueTuple<T1, T2, T3, T4, T5>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2, item.Item3, item.Item4, item.Item5 };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2, T3, T4, T5, T6>(this IEnumerable<ValueTuple<T1, T2, T3, T4, T5, T6>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6 };
            }
        }

        public static IEnumerable<object[]> ToXUnitData<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<ValueTuple<T1, T2, T3, T4, T5, T6, T7>> values)
        {
            foreach (var item in values)
            {
                yield return new object[] { item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7 };
            }
        }
    }
}