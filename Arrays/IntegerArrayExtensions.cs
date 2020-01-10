using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Models;
using Algorithms.Trees;
using static Algorithms.LinkedLists.SingleLinkedList;

namespace Algorithms.Arrays{
    public static class IntegerArrayExtensions{
        public static int[] TwoSum(this int[] array, int target){
            if(array.Length == 0) {return new int[]{};}
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < array.Length; i++){
                int difference = target - array[i];
                if(map.ContainsKey(difference)){
                    return new int[]{ map[difference], i};
                }
                if(!map.ContainsKey(array[i])){
                    map.Add(array[i], i);
                }
            }
            return new int[] {};
        }
        public static void Print(this int[] array){
            StringBuilder sb = new StringBuilder("[");
            for(int i = 0; i < array.Length; i++){
                sb.Append(array[i].ToString());
                if(i != array.Length - 1){
                     sb.Append(", ");
                }
            }
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

        public static int GetUniqueNumber(this int[] array){
            //a XOR 0 = a
            //a XOR a = 0
            if(array.Length == 0){ return 0; }
            int num = 0;
            for(int i = 0; i < array.Length; i++){
                num ^= array[i];
            }
            return num;
        }

        public static void MergeSortedArray(this int[] arr1, int m, int[] arr2, int n){
            if(m == 0 && n == 0){ return; }
            int p = m - 1;
            int q = n - 1;
            int length = (m + n) - 1;
            while(p >= 0 && q >= 0){
                arr1[length--] = (arr1[p] < arr2[q]) ? arr2[q--] : arr1[p--];
            }
            Array.Copy(arr2, 0, arr1,0, q+1);
            arr1.Print();
        }
        public static void Reverse(this int[] arr, int start, int end){
            int mid = (start + end) / 2;
            while(start <= mid){
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
        public static void Rotate(this int[] arr, int rotateBy){
            if(rotateBy > arr.Length){ return; }
            arr.Reverse(0, rotateBy - 1);
            arr.Reverse(rotateBy + 1, arr.Length - 1);
            arr.Reverse(0, arr.Length - 1);
            arr.Print();
        }
        public static int SearchInRotatedArray(this int[] arr, int element){
            if(arr.Length == 0){ return -1;}
            int start = 0;
            int end = arr.Length - 1;
            int mid = 0;
            while(start <= end ){
                mid = (start + end)/2; 
                if(arr[mid] == element) return mid;
                if(arr[mid] <= arr[end]){
                    if(element > arr[mid] && element <= arr[end]){ start = mid + 1; }
                    else{ end = mid - 1; }
                }else{
                    if(element >= arr[start] && element < arr[mid]){ end = mid - 1; }
                    else{ start = mid + 1; }
                }
            }
            return -1;
        }
        public static int FindMinimumInASortedArray(this int[] arr){
            if(arr.Length == 0){ return -1;}
            if(arr.Length == 1){ return arr[0];}
            int start = 0;
            int end = arr.Length - 1;
            int mid = 0;
            while(start < end){
                mid = (start + end) / 2;
                if(arr[mid] < arr[end]){
                    end = mid;
                }else if(arr[mid] > arr[end]){
                    start = mid + 1;
                }
            }
            return arr[start];
        }
        //[0,1,0,2,1,0,1,3,2,1,2,1]
        public static int TrapRainWater(this int[] arr){
            if(arr.Length == 0){ return 0; }
            int left = 0, right = arr.Length - 1, ans = 0, leftMax = 0, rightMax = 0;
            while(left < right){
                if(arr[left] < arr[right]){
                    if(arr[left] >= leftMax){ 
                        leftMax = arr[left]; 
                    }
                    else{ 
                        ans += (leftMax - arr[left]); 
                    }
                    left++;
                }else{
                    if(arr[right] >= rightMax){ rightMax = arr[right]; }
                    else{ ans += (rightMax - arr[right]); }
                    right--;
                }
            }
            return ans;
        }

        public static BSTNode ToBSTree(this int[] arr){
            BSTNode node = null;
            BSTree tree = new BSTree();
            foreach(var a in arr){
                node = tree.Insert(node, a);
            }
            return node;
        }

        public static Node ToSingleLinkedList(this int[] arr){
            if(arr.Length == 0) return null;
            Node dummy = new Node(-1);
            Node current = new Node(arr[0]);
            dummy.Next = current;
            int i = 1;
            while(i < arr.Length){
                current.Next = new Node(arr[i++]);
                current = current.Next;
            }
            return dummy.Next;
        }
    }

    
}