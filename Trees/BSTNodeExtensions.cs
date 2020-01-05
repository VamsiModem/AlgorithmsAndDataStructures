using System.Text;
using Algorithms.Models;

namespace Algorithms.Trees{
    public static class BSTNodeExtensions{
        public static string Serialize(this BSTNode node){
            if(node is null) return "X";
            return new StringBuilder(node.Value.ToString())
            .Append(',') 
            .Append(node.Left.Serialize()) 
            .Append(',') 
            .Append(node.Right.Serialize()).ToString();
        }
    }
}