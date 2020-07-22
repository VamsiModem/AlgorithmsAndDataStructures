using System.Text;
using Algorithms.Models;

namespace Algorithms.Trees
{
    public static class BSTNodeExtensions
    {
        public static string Serialize(this BSTNode node)
        {
            if (node is null) return "X";
            return new StringBuilder(node.Value.ToString())
            .Append(',')
            .Append(node.Left.Serialize())
            .Append(',')
            .Append(node.Right.Serialize()).ToString();
        }

        public static BSTNode LCA(this BSTNode root, int val1, int val2)
        {
            if (root is null) return root;
            if (val1 < root.Value && val2 < root.Value)
                return root.Left.LCA(val1, val2);
            else if (val1 > root.Value && val2 > root.Value)
                return root.Right.LCA(val1, val2);
            else
                return root;
        }

        public static int Distance(this BSTNode root, int val)
        {
            if (root is null) return 0;
            if (root.Value == val) return 0;
            if (val < root.Value) return 1 + root.Left.Distance(val);
            else return 1 + root.Right.Distance(val);
        }

        public static int DistanceBetweenNodes(this BSTNode root, int nodeVal1, int nodeVal2)
        {
            if (root is null) return 0;
            var lca = root.LCA(nodeVal1, nodeVal2);
            if (lca != null)
            {
                return lca.Distance(nodeVal1) + lca.Distance(nodeVal2);
            }
            return -1;
        }
    }
}