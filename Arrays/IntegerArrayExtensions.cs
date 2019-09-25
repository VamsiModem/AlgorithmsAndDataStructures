using System;
using System.Collections.Generic;
using System.Text;

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
    }

    
}