namespace Algorithms.Models{
    public class BSTNode{
        public int Value { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
        public BSTNode(int value)
        {
            this.Value = value;
        }
    }
}