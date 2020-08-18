
namespace Algorithms.Tries {
    public class TrieNode{
        private TrieNode[] _children;
        private bool _isEnd;
        const char A = 'a';
        public bool IsEnd{
            get => this._isEnd;
            set{ this._isEnd = value; }
}
        public TrieNode()
        {
            this._children = new TrieNode[26];
        }
        public void Put(char c, TrieNode t){
            this._children[c - A] = t;
        }

        public TrieNode Get(char c){
            return this._children[c - A];
        }

        public bool ContainsKey(char c){
            return this._children[c - A] != null;
        }
    }
}