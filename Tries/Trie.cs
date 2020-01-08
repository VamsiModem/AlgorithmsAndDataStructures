
namespace Algorithms.Tries{
    
    public class Trie{
        private TrieNode _root;
        public Trie()
        {
            this._root = new TrieNode();
        }
        public TrieNode Root { 
            get => this._root;
         }
        public void Insert(string word){
            TrieNode root = this._root;
            foreach(char c in word){
                if(!root.ContainsKey(c)) root.Put(c, new TrieNode());
                root = root.Get(c);
            }
            root.IsEnd = true;
        }

        public TrieNode SearchPrefix(string word){
            TrieNode root = this._root;
            foreach(char c in word){
                if(root.ContainsKey(c)) root = root.Get(c);
                else return null;
            }
            return root;
        }

        public bool Search(string word){
            TrieNode node = this.SearchPrefix(word);
            return  node != null && node.IsEnd;
        }

        public bool StartsWith(string prefix) => this.SearchPrefix(prefix) != null;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}