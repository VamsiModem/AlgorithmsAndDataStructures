namespace Algorithms.Trees{
    public class BinarySearchTree{
        internal class BinarySearchTreeNode{
            public int Value { get; set; }
            public BinarySearchTreeNode Left { get; set; }
            public BinarySearchTreeNode Right { get; set; }
            public BinarySearchTreeNode(int val)
            {
                Value = val;
            }
        }
        private BinarySearchTreeNode _root;
        public void Add(int value){
            Add(_root, value);
        }

        private BinarySearchTreeNode Add(BinarySearchTreeNode root, int value){
            if(root is null){
                root = new BinarySearchTreeNode(value);
            }else if(value > root.Value){
                root.Right = Add(root, value);
            }else{
                root.Left = Add(root, value);
            }
            return root;
        }
    }
}