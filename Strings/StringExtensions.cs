using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Models;
using BenchmarkDotNet.Attributes;
using Algorithms.Tries;
using Algorithms.LinkedLists;

namespace Algorithms.Strings
{
    public static class StringExtensions
    {
        public static bool HasUniqueCharacters(this string s)
        {
            if (s.Length == 0) { return true; }
            bool[] asciiChars = new bool[26];
            char[] charArr = s.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (asciiChars[charArr[i] - 'a']) { return false; }
                else { asciiChars[charArr[i] - 'a'] = true; }
            }
            return true;
        }
        public static StringBuilder Reverse(this StringBuilder sb, int start, int end)
        {
            int mid = (start + end) / 2;
            while (start <= mid)
            {
                char temp = sb[start];
                sb[start] = sb[end];
                sb[end] = temp;
                start++;
                end--;
            }
            return sb;
        }
        public static StringBuilder LeftTrim(this StringBuilder sb)
        {
            int counter = 0;
            while (char.IsWhiteSpace(sb[counter])) sb.Remove(counter, 1);
            return sb;
        }
        public static StringBuilder RightTrim(this StringBuilder sb)
        {
            int counter = sb.Length - 1;
            while (char.IsWhiteSpace(sb[counter]))
            {
                sb.Remove(counter, 1);
                counter--;
            }
            return sb;
        }
        public static string ReverseWordsInString(this string s)
        {
            if (s is null || s.Equals(string.Empty)) return s;
            int counter = 0;
            bool didHitTheFirstChar = false;
            StringBuilder sb = new StringBuilder();
            while (counter < s.Length)
            {
                if (char.IsWhiteSpace(s[counter]) && !didHitTheFirstChar)
                {
                    counter++;
                }
                else if (!char.IsWhiteSpace(s[counter]))
                {
                    didHitTheFirstChar = true;
                    sb.Append(s[counter]);
                    counter++;
                }
                else if (char.IsWhiteSpace(s[counter]) && didHitTheFirstChar)
                {
                    if (!char.IsWhiteSpace(sb[sb.Length - 1]))
                    {
                        sb.Append(s[counter]);
                    }
                    counter++;
                }
            }
            if (sb.Length == 0) return string.Empty;
            if (char.IsWhiteSpace(sb[sb.Length - 1])) sb.Remove(sb.Length - 1, 1);
            sb = sb.Reverse(0, sb.Length - 1);
            counter = 0;
            int wordStart = 0;
            while (counter < sb.Length)
            {
                if (char.IsWhiteSpace(sb[counter]))
                {
                    sb.Reverse(wordStart, counter - 1);
                    wordStart = counter + 1;
                }
                counter++;
            }
            sb.Reverse(wordStart, counter - 1);
            return sb.ToString();
        }
        public static bool IsPermutation(this string s1, string s2)
        {
            if (s1.Length != s2.Length) { return false; }
            HashSet<char> set = new HashSet<char>(s1.ToCharArray());
            char[] chars = s2.ToCharArray();
            for (int i = 0; i < s2.Length; i++)
            {
                if (!set.Contains(chars[i])) { return false; }
            }
            return true;
        }

        public static bool IsPalindromePermutation(this string s)
        {
            if (s.Length == 0) { return false; }
            char[] chars = s.ToCharArray();
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(chars[i])) { map[chars[i]]++; }
                else { map.Add(chars[i], 1); }
            }
            int numberOfOdds = 0;
            foreach (var kvp in map)
            {
                if ((kvp.Value % 2) != 0) { numberOfOdds++; }
            }
            return numberOfOdds <= 1;
        }

        public static string CompressString(this string s)
        {
            if (s.Length == 0) { return s; }
            StringBuilder sb = new StringBuilder();
            char[] chars = s.ToCharArray();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count++;
                if (i + 1 >= s.Length || chars[i] != chars[i + 1])
                {
                    sb.Append(chars[i]);
                    sb.Append(count);
                    count = 0;
                }
            }
            return sb.ToString();
        }
        //This doesn't handle duplicates
        public static List<string> Permute(this string s)
        {
            List<string> output = new List<string>();
            if (s.Length == 0) { return output; }
            char[] chars = s.ToCharArray();
            var counts = new Dictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (counts.ContainsKey(chars[i])) { counts[chars[i]]++; }
                else { counts.Add(chars[i], 1); }
            }
            PermuterHelper(chars, output, counts, 0, new char[s.Length]);
            return output;
        }

        private static void PermuterHelper(char[] chars, List<string> output, Dictionary<char, int> counts, int level, char[] result)
        {
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
        public static string LongestCommonSubSequence(this string s1, string s2)
        {
            int string1Length = s1.Length;
            int string2Length = s2.Length;
            if (string1Length < string2Length) return s2.LongestCommonSubSequence(s1);
            StringBuilder result = new StringBuilder();
            int[] memo = new int[string2Length + 1];
            for (int row = 1; row <= string1Length; row++)
            {
                int prev = 0;
                for (int col = 1; col <= string2Length; col++)
                {
                    int temp = memo[col];
                    if (s1[row - 1] == s2[col - 1])
                    {
                        memo[col] = prev + 1;
                        result.Append(s1[row - 1]);
                    }
                    else
                    {
                        memo[col] = Math.Max(memo[col], memo[col - 1]);
                    }
                    prev = temp;
                }
            }
            return result.ToString();
        }

        public static string LexicographicallySmallestString(this string s)
        {
            if (s.Length == 0) return s;
            StringBuilder result = new StringBuilder(s);
            const int MAX_DELETIONS_POSSIBLE = 1;
            int deletedCount = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if ((s[i] > s[i + 1]) && deletedCount < MAX_DELETIONS_POSSIBLE)
                {
                    result.Remove(i, 1);
                    deletedCount++;
                }
            }
            if (deletedCount < MAX_DELETIONS_POSSIBLE)
            {
                result.Remove(result.Length - 1, 1);
            }
            return result.ToString();
        }

        public static int MinMovesToObtainStringWithaAandBWithOut3ConsecutiveLetters(this string s)
        {
            char[] charArr = s.ToCharArray();
            int minMoves = 0;
            if (s.Length < 3) { return minMoves; }
            int charCount = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == s[i])
                {
                    charCount++;
                    if (3 == charCount)
                    {
                        charCount = 1;
                        minMoves++;
                    }
                }
                else
                {
                    charCount = 1;
                }
            }
            return minMoves;
        }

        public static BSTNode Deserilize(this string s)
        {
            Queue<string> queue = new Queue<string>();
            s.Split(',').ToList().ForEach(x => queue.Enqueue(x));
            return DeserilizeHelper(queue);
        }

        private static BSTNode DeserilizeHelper(Queue<string> queue)
        {
            string nodeValue = queue.Dequeue();
            if (nodeValue.Equals("X")) return null;
            BSTNode node = new BSTNode(Convert.ToInt32(nodeValue));
            node.Left = DeserilizeHelper(queue);
            node.Right = DeserilizeHelper(queue);
            return node;
        }

        public static Trie ToTrie(this string[] arr)
        {
            Trie trie = new Trie();
            foreach (string s in arr)
            {
                trie.Insert(s);
            }
            return trie;
        }

        public static int ToInteger(this string s)
        {
            if (s.Length == 0) return 0;
            int result = 0;
            bool isNegative = false, readSign = false, firstNumberRead = false;
            for (int i = 0; i < s.Length; i++)
            {
                bool nospecialCharsAllowed = (!firstNumberRead && !readSign);
                if (s[i] == ' ' && nospecialCharsAllowed) continue;
                else if (s[i] == '-' && nospecialCharsAllowed)
                {
                    isNegative = true;
                    readSign = true;
                }
                else if (s[i] == '+' && nospecialCharsAllowed)
                {
                    isNegative = false;
                    readSign = true;
                }
                else if (s[i] >= '0' && s[i] <= '9')
                {
                    firstNumberRead = true;
                    var num = s[i] - '0';
                    if (!isNegative)
                    {

                        if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && num > 7)) return int.MaxValue;
                        else
                        {
                            result = (result * 10) + num;
                        }
                    }
                    else
                    {
                        if (-result < int.MinValue / 10 || (-result == int.MinValue / 10 && -num < -8)) return int.MinValue;
                        else
                        {
                            result = (result * 10) + num;
                        }
                    }
                }
                else
                    return (isNegative ? -1 * result : result);
            }
            if (isNegative) result = -1 * result;
            if (result > int.MaxValue) return int.MaxValue;
            if (result < int.MinValue) return int.MinValue;
            return (int)result;
        }

        public static string LongestPalindromicSubString(this string s)
        {
            if (s is null || s.Length == 0) return s;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int evenLength = ExpandAroundCenter(s, i, i + 1);
                int oddLength = ExpandAroundCenter(s, i, i);
                int len = Math.Max(evenLength, oddLength);
                if (len > (end - start))
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }
            return s.Substring(start, end - start);
        }
        private static int ExpandAroundCenter(string s, int start, int end)
        {
            if (s is null || start > end) return 0;
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }
            return end - start - 1;
        }

        public static bool IsValidParenthesis(this string s)
        {
            if (s.Length == 0) return true;
            Dictionary<char, char> brackets = new Dictionary<char, char>{
                {'}','{'},{')','('},{']','['}
            };
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    char currentChar = s[i];
                    bool isClosedBracket = brackets.ContainsKey(currentChar);
                    if (isClosedBracket)
                    {
                        char poppedChar = stack.Pop();
                        if (poppedChar != brackets[currentChar])
                            return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        public static List<int> PartitionLabels(this string s)
        {
            if (s.Length == 0) return new List<int>();
            List<int> partitions = new List<int>();
            int[] lastIndexes = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                lastIndexes[s[i] - 'a'] = i;
            }
            int cur = 0;
            while (cur < s.Length)
            {
                int end = lastIndexes[s[cur] - 'a'];
                int next = cur;
                while (next < end)
                {
                    end = Math.Max(end, lastIndexes[s[next++] - 'a']);
                }
                partitions.Add(next - cur + 1);
                cur = next + 1;
            }
            return partitions;
        }

        public static List<List<string>> Suggestions(this string key, string[] products)
        {
            Array.Sort(products);
            TrieWithSuggestions trie = new TrieWithSuggestions();
            for (int i = 0; i < products.Length; i++)
            {
                trie.Insert(products[i]);
            }
            return trie.Search(key);
        }

        public static string Add(this string s1, string s2){
            var node1 = s1.ToLinkedList();
            var node2 = s2.ToLinkedList();
            var sumString = new StringBuilder();
            int carry = 0;
            int value = 0;
            while(node1 != null || node2 != null){
                int sum = 0;
                if(node1 != null){
                    sum += node1.Data;
                    node1 = node1.Next;
                }
                if(node2 != null){
                    sum += node2.Data;
                     node2 = node2.Next;
                }
                sum += carry;
                value = sum % 10;
                carry = sum /10;
                sumString.Append(value);
                
               
            }
            return sumString.Reverse(0,sumString.Length -1).ToString();
        }
        public static int NumSplits(this string s) {
            if(s.Length == 0) return 0;
            int splitCount = 0;
            for(int i = 1; i < s.Length ; i++){
                if(IsGoodSplit(s,i))
                    splitCount++;
            }
            return splitCount;
        }
        
        public static bool IsGoodSplit(string s, int splitAt){
            return GetUniqueCharCount(s, 0, splitAt) == GetUniqueCharCount(s, splitAt, s.Length);
        }
        
        public static int GetUniqueCharCount(string s, int start, int end){
            bool[] chars = new bool[26];
            int unique = 0;
            for(int i = start; i < end; i++){
                if(!chars[s[i] - 'a']){
                    chars[s[i] - 'a'] = true;
                    unique++;
                }
            }
            return unique;
        }
    }
}