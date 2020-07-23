using System.Collections.Generic;

namespace Algorithms.Tries
{
    public class TrieNodeWithSuggestions
    {
        public TrieNodeWithSuggestions[] Children = new TrieNodeWithSuggestions[26];
        public List<string> Suggestions = new List<string>();
    }

    public class TrieWithSuggestions
    {
        public TrieNodeWithSuggestions Root { get; set; }
        public TrieWithSuggestions()
        {
            Root = new TrieNodeWithSuggestions();
        }
        public void Insert(string s)
        {
            TrieNodeWithSuggestions t = Root;
            for (int i = 0; i < s.Length; i++)
            {
                if (t.Children[s[i] - 'a'] == null)
                    t.Children[s[i] - 'a'] = new TrieNodeWithSuggestions();
                t = t.Children[s[i] - 'a'];
                if (t.Suggestions.Count < 3)
                    t.Suggestions.Add(s);
            }
        }

        public List<List<string>> Search(string key)
        {
            TrieNodeWithSuggestions t = Root;
            List<List<string>> res = new List<List<string>>();
            for (int i = 0; i < key.Length; i++)
            {
                if (t.Children[key[i] - 'a'] != null)
                    t = t.Children[key[i] - 'a'];
                res.Add(t is null ? new List<string>() : t.Suggestions);
            }
            return res;
        }
    }
}
