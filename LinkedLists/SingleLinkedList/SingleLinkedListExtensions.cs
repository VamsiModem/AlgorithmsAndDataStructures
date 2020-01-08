using static Algorithms.LinkedLists.SingleLinkedList;
using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithms.LinkedLists
{
    public static class SingleLinkedListExtensions{
        public static Node Reverse(this Node node){
            Node current = node, prev = null, next = null;
            while(current != null){
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static void Print(this Node node){
            if(node is null){Console.WriteLine("No nodes print.");}
            StringBuilder output = new StringBuilder();
            Node current = node;
            while(current != null){
                output.Append(current.Data);
                if(current.Next != null) output.Append(" -> ");
                current = current.Next;
            }
            Console.WriteLine(output.ToString());
        }

        public static Node Add(this Node node1, Node node2){
            Node reversedNode1 = node1.Reverse();
            Node reversedNode2 = node2.Reverse();
            Node dummy = new Node(-1);
            Node sumNode = dummy;
            int carry = 0;
            while(reversedNode1 != null || reversedNode2 != null){
                int sum = (reversedNode1?.Data ?? 0) + (reversedNode2?.Data ?? 0) + carry;
                carry = sum / 10;
                sumNode.Next = new Node(sum % 10);
                sumNode = sumNode.Next;
                reversedNode1 = reversedNode1?.Next;
                reversedNode2 = reversedNode2?.Next;
            }
            if(carry > 0) sumNode.Next = new Node(carry);
            return dummy.Next.Reverse();
        }

        public static Node DeleteDuplicates(this Node node){
            if(node is null){return node;}
            HashSet<int> nums = new HashSet<int>();
            Node current = node, prev = node;
            while(current != null){
                if(nums.Contains(current.Data)){
                    prev.Next = current.Next;
                }else {
                    nums.Add(current.Data);
                    prev = current;
                }
                current = current.Next;
            }
            return node;
        }
    }
}