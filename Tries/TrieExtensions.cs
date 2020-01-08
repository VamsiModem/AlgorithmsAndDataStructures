using System.Collections.Generic;
namespace Algorithms.Tries{
    public static class TrieExtensions{
        public static List<string> ConcatnatedWords(this Trie trie, string[] strings){
            List<string> concatnatedWords = new List<string>();
            if(strings.Length == 0) return concatnatedWords;
            foreach(string s in strings){
                if(Helper(trie.Root, s, 0, 0)){concatnatedWords.Add(s);}
            }
            return concatnatedWords;
        }

        private static bool Helper(TrieNode root, string s, int index, int count){
            TrieNode node = root;
            for(int i = index; i < s.Length; i++){
                if(!node.ContainsKey(s[i]))return false;
                if(node.Get(s[i]).IsEnd){
                    if(i == s.Length - 1) return count >= 1;
                    if(Helper(root, s, i + 1, count + 1)) return true;
                }
                node = node.Get(s[i]);
            }
            return false;
        }
    }
}