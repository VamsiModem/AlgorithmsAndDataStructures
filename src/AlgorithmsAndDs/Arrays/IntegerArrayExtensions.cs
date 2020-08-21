using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.LinkedLists;
using Algorithms.Models;
using Algorithms.Trees;
using static Algorithms.LinkedLists.SingleLinkedList;

namespace Algorithms.Arrays
{
    public static class IntegerArrayExtensions
    {
        public static int[] TwoSum(this int[] array, int target)
        {
            if (array.Length == 0) { return new int[] { }; }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                int difference = target - array[i];
                if (map.ContainsKey(difference))
                {
                    return new int[] { map[difference], i };
                }
                if (!map.ContainsKey(array[i]))
                {
                    map.Add(array[i], i);
                }
            }
            return new int[] { };
        }
        public static void Print(this int[] array)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i].ToString());
                if (i != array.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

        public static int GetUniqueNumber(this int[] array)
        {
            //a XOR 0 = a
            //a XOR a = 0
            if (array.Length == 0) { return 0; }
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                num ^= array[i];
            }
            return num;
        }

        public static void MergeSortedArray(this int[] arr1, int m, int[] arr2, int n)
        {
            if (m == 0 && n == 0) { return; }
            int p = m - 1;
            int q = n - 1;
            int length = (m + n) - 1;
            while (p >= 0 && q >= 0)
            {
                arr1[length--] = (arr1[p] < arr2[q]) ? arr2[q--] : arr1[p--];
            }
            Array.Copy(arr2, 0, arr1, 0, q + 1);
            arr1.Print();
        }
        public static void Reverse(this int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;
            while (start <= mid)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
        public static void Rotate(this int[] arr, int rotateBy)
        {
            if (rotateBy > arr.Length) { return; }
            arr.Reverse(0, rotateBy - 1);
            arr.Reverse(rotateBy + 1, arr.Length - 1);
            arr.Reverse(0, arr.Length - 1);
            arr.Print();
        }
        public static int SearchInRotatedArray(this int[] arr, int element)
        {
            if (arr.Length == 0) { return -1; }
            int start = 0;
            int end = arr.Length - 1;
            int mid = 0;
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (arr[mid] == element) return mid;
                if (arr[mid] <= arr[end])
                {
                    if (element > arr[mid] && element <= arr[end]) { start = mid + 1; }
                    else { end = mid - 1; }
                }
                else
                {
                    if (element >= arr[start] && element < arr[mid]) { end = mid - 1; }
                    else { start = mid + 1; }
                }
            }
            return -1;
        }
        public static int FindMinimumInASortedArray(this int[] arr)
        {
            if (arr.Length == 0) { return -1; }
            if (arr.Length == 1) { return arr[0]; }
            int start = 0;
            int end = arr.Length - 1;
            int mid = 0;
            while (start < end)
            {
                mid = (start + end) / 2;
                if (arr[mid] < arr[end])
                {
                    end = mid;
                }
                else if (arr[mid] > arr[end])
                {
                    start = mid + 1;
                }
            }
            return arr[start];
        }
        //[0,1,0,2,1,0,1,3,2,1,2,1]
        public static int TrapRainWater(this int[] arr)
        {
            if (arr.Length == 0) { return 0; }
            int left = 0, right = arr.Length - 1, ans = 0, leftMax = 0, rightMax = 0;
            while (left < right)
            {
                if (arr[left] < arr[right])
                {
                    if (arr[left] >= leftMax)
                    {
                        leftMax = arr[left];
                    }
                    else
                    {
                        ans += (leftMax - arr[left]);
                    }
                    left++;
                }
                else
                {
                    if (arr[right] >= rightMax) { rightMax = arr[right]; }
                    else { ans += (rightMax - arr[right]); }
                    right--;
                }
            }
            return ans;
        }

        public static BSTNode ToBSTree(this int[] arr)
        {
            BSTNode node = null;
            BSTree tree = new BSTree();
            foreach (var a in arr)
            {
                node = tree.Insert(node, a);
            }
            return node;
        }

        public static SingleLinkedListNode ToSingleLinkedList(this int[] arr)
        {
            if (arr.Length == 0) return null;
            SingleLinkedListNode dummy = new SingleLinkedListNode(-1);
            SingleLinkedListNode current = new SingleLinkedListNode(arr[0]);
            dummy.Next = current;
            int i = 1;
            while (i < arr.Length)
            {
                current.Next = new SingleLinkedListNode(arr[i++]);
                current = current.Next;
            }
            return dummy.Next;
        }

        public static int MinSizeSubArraySum(this int[] arr, int s)
        {
            if (arr.Length == 0) return 0;
            int i = 0, result = arr.Length, j;
            for (j = 0; j < arr.Length; j++)
            {
                s -= arr[j];
                while (s <= 0)
                {
                    result = Math.Min(result, j - i + 1);
                    s += arr[i++];
                }
            }
            return result % 3;
        }

        public static IList<IList<int>> ThreeSumUsingTwoSum(this int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                    TwoSum(nums, result, i);
            }
            return result;
        }


        private static void TwoSum(int[] nums, IList<IList<int>> result, int i)
        {
            HashSet<int> set = new HashSet<int>();
            for (int j = i; j < nums.Length; j++)
            {
                var difference = -nums[i] - nums[j];
                if (set.Contains(difference))
                {
                    var list = new List<int> { nums[i], nums[j], difference };
                    list.Sort();
                    result.Add(list);
                    while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                        j++;
                }
                set.Add(nums[j]);
            }
        }

        public static int[] PlusOne(this int[] arr)
        {
            if (arr.Length == 0) return new int[] { };
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 9)
                    arr[i] = 0;
                else
                {
                    arr[i]++;
                    return arr;
                }
            }
            arr = new int[arr.Length + 1];
            arr[0] = 1;
            return arr;
        }

        public static int[] Range(this int[] arr, int target)
        {
            var result = new int[2];
            result[0] = PriorityBasedBinarySearch(arr, target, true);
            result[1] = PriorityBasedBinarySearch(arr, target, false);
            return result;
        }

        // public static int[] FindKClosest(this int[] nums, int k, int target)
        // {

        // }

        private static int PriorityBasedBinarySearch(int[] nums, int target, bool onleft)
        {
            int index = -1;
            int left = 0, right = nums.Length - 1, mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if ((target < nums[mid]) || (nums[mid] == target && onleft))
                    right = mid - 1;
                else
                    left = mid + 1;
                if (nums[mid] == target) index = mid;
            }
            return index;
        }

        public static int[] MergeSortAndReturnIndexes(this int[] arr){
            int[] indices = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
                indices[i] = i;
            MergeSort(arr, indices,0, arr.Length - 1);
            return arr;
        }
        //1,2,3,4,5,6
        private static void MergeSort(int[] arr, int[] indices, int left, int right)
        {
            if(left < right){
                int mid = (left + right )/ 2;
                MergeSort(arr, indices, left, mid);
                MergeSort(arr, indices, mid + 1, right);
                Merge(arr, indices, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int[] indices, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, at = 0;
            while(i <= mid && j <= right){
                if(arr[i] <= arr[j])
                    temp[at] = arr[i++];
                else
                    temp[at] = arr[j++];
                at++;
            }
            while(i <= mid)
                temp[at++] = arr[i++];
            while(j <= right)
                temp[at++] = arr[j++];
            for(i = left; i <= right; i++)
                arr[i] = temp[i - left];
        }
    }
}