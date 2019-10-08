using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings{
    public static class StringExtensions{
        public static bool HasUniqueCharacters(this string s){
            if(s.Length == 0){ return true; }
            bool[] asciiChars = new bool[26];
            char[] charArr = s.ToCharArray();
            for(int i = 0; i < charArr.Length; i++){
                if(asciiChars[charArr[i] - 'a']){ return false; }
                else{ asciiChars[charArr[i] - 'a'] = true; }
            }
            return true;
        }
        public static void Reverse(this StringBuilder sb, int start, int end){
            int mid = (start + end)/2;
            while(start <= mid){
                char temp = sb[start];
                sb[start] = sb[end];
                sb[end] = temp; 
                start++;
                end--;
            }
        }
        public static string ReverseWordsInString(this string s){
            int length = s.Length;
            if(length == 0){return s;}
            StringBuilder sb = new StringBuilder(s);
            sb.Reverse(0, length - 1);
            int start = 0;
            for(int i = 0; i < length; i++){
                if(sb[i] == ' '){
                    sb.Reverse(start, i - 1);
                    start = i + 1;
                }
            }
            sb.Reverse(start, length - 1);
            return sb.ToString() ;
        }
        public static bool IsPermutation(this string s1, string s2){
            if(s1.Length != s2.Length){ return false; }
            HashSet<char> set = new HashSet<char>(s1.ToCharArray());
            char[] chars = s2.ToCharArray();
            for(int i = 0; i < s2.Length; i++){
                if(!set.Contains(chars[i])){ return false; }
            }
            return true;
        }

        public static string LongestSubstringWithoutRepeatingChars(this string s){
            if(s.Length == 0){ return s; }
            int[] asciiChars = new int[256];
            char[] chars = s.ToCharArray();
            int start = 0, end = 0, result = 0;
            while(start < s.Length){
                if(asciiChars[chars[end]] > 0){
                    start = Math.Max(start, asciiChars[chars[end]]);
                }
                asciiChars[chars[end]]++;
            }
            return s.Substring(start, result);
        }
        public static bool IsPalindromePermutation(this string s){
            if(s.Length == 0){ return false; }
            char[] chars = s.ToCharArray();
            Dictionary<char, int> map = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++){
                if(map.ContainsKey(chars[i])){ map[chars[i]]++; }
                else{ map.Add(chars[i], 1); }
            }
            int numberOfOdds = 0;
            foreach(var kvp in map){
                if((kvp.Value % 2) != 0){ numberOfOdds++; }
            }
            return numberOfOdds <= 1;
        }

        public static string CompressString(this string s){
            if(s.Length == 0){ return s; }
            StringBuilder sb = new StringBuilder();
            char[] chars = s.ToCharArray();
            int count = 0;
            for(int i = 0; i < s.Length; i++){
                count++;
                if(i + 1 >= s.Length || chars[i] != chars[i + 1]){
                    sb.Append(chars[i]);
                    sb.Append(count);
                    count = 0;
                }
            }
            return sb.ToString();
        }

        public static List<string> Permute(this string s){
            List<string> output = new List<string>();
            if(s.Length == 0){ return output; }
            char[] chars = s.ToCharArray();
            var counts = new Dictionary<char, int>();
            for(int i = 0; i < chars.Length; i++){
                if(counts.ContainsKey(chars[i])){ counts[chars[i]]++; }
                else{ counts.Add(chars[i], 1);}
            }
            PermuterHelper(chars, output, counts, 0, new char[s.Length]);
            return output;
        }

        private static void PermuterHelper(char[] chars, List<string> output, Dictionary<char, int> counts, int level, char[] result){
            if (level == result.Length) { output.Add(new String(result)); }
            for (int i = 0; i < chars.Length; i++)
            {
                if (counts[chars[i]] == 0) { continue; }
                result[level] = chars[i];
                counts[chars[i]]--;
                PermuterHelper(chars, output, counts, level + 1, result);
                counts[chars[i]]++;
            }
        }
    }
}