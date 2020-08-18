using System.Collections.Generic;
using Algorithms.Models;

namespace Algorithms.Trees{
    public class BSTIterator{
        Stack<BSTNode> stack;
        public BSTIterator(BSTNode root)
        {
            stack = new Stack<BSTNode>();
            while(root != null){
                stack.Push(root);
                root = root.Left;
            }
        }
        public bool HasNext() => stack.Count != 0;
        public int Next(){
            BSTNode node = stack.Pop();
            int result = node.Value;
            if(node.Right != null){
                node = node.Right;
                while(node != null){
                    stack.Push(node);
                    node = node.Left;
                }
            }
            return result;
        }
    }
}