using System;
using System.Collections.Generic;
using Algorithms.Models;

namespace Algorithms.Trees{
    public class BSTree{
        public BSTNode Insert(BSTNode root, int value){
            if(root is null){ root = new BSTNode(value); }
            else if(value < root.Value){
                root.Left = Insert(root.Left, value);
            }else {
                root.Right = Insert(root.Right, value);
            }
            return root;
        }
        public void InorderTraversalRecursive(BSTNode root){
            if(root is null){return;}
            InorderTraversalRecursive(root.Left);
            Console.WriteLine(root.Value);
            InorderTraversalRecursive(root.Right);
        }
    }
}