namespace Algorithms.Strings{
    public class WordDictionary{
        public WordDictionary()
        {
            _root = new WordSearchTrieNode();
        }
        private WordSearchTrieNode _root;
        internal class WordSearchTrieNode{
            private WordSearchTrieNode[] _children;
            private bool _isEnd;
            public bool IsEnd { 
                get =>_isEnd;
                set{
                    _isEnd = value;
                } 
            }
            
            public WordSearchTrieNode()
            {
                _children = new WordSearchTrieNode[26];
            }
            public bool ContainsKey(char c) => _children[c - 'a'] != null;
            public WordSearchTrieNode Get(char c) => _children[c - 'a'];
            public void Set(char c, WordSearchTrieNode t){
                _children[c - 'a'] = t;
            }
        }
        
        public void AddWord(string word){
            WordSearchTrieNode root = _root;
            for(int i = 0 ; i < word.Length; i++){
                if(!root.ContainsKey(word[i]))
                    root.Set(word[i], new WordSearchTrieNode());
                
                root = root.Get(word[i]);
            }
            root.IsEnd = true;
        }

        public bool Search(string word){
            WordSearchTrieNode root = SearchPrefix(word);
            return  root != null && root.IsEnd;
        }
        private WordSearchTrieNode SearchPrefix(string word){
            WordSearchTrieNode root = _root;
            foreach(char c in word){
                if(root.ContainsKey(c)) root = root.Get(c);
                else return null;
            }
            return root;
        }
    }
}