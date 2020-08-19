using static Algorithms.LinkedLists.SingleLinkedList;
using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithms.LinkedLists
{
    public static class SingleLinkedListExtensions
    {
        public static Node ReverseInplace(this Node node)
        {
            Node current = node, prev = null, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
        public static Node Reverse(this Node node)
        {
            Node newNode = node.Copy();
            Node current = newNode, prev = null, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static Node Copy(this Node node)
        {
            Node newNode = new Node(node.Data);
            Node current = newNode;
            node = node.Next;
            while (node != null)
            {
                Node n2 = new Node(node.Data);
                current.Next = n2;
                current = n2;
                node = node.Next;
            }
            return newNode;
        }

        public static void Print(this Node node)
        {
            if (node is null) { Console.WriteLine("No nodes print."); }
            StringBuilder output = new StringBuilder();
            Node current = node;
            while (current != null)
            {
                output.Append(current.Data);
                if (current.Next != null) output.Append(" -> ");
                current = current.Next;
            }
            Console.WriteLine(output.ToString());
        }

        public static Node Add(this Node node1, Node node2)
        {
            Node reversedNode1 = node1.ReverseInplace();
            Node reversedNode2 = node2.ReverseInplace();
            Node dummy = new Node(-1);
            Node sumNode = dummy;
            int carry = 0;
            while (reversedNode1 != null || reversedNode2 != null)
            {
                int sum = (reversedNode1?.Data ?? 0) + (reversedNode2?.Data ?? 0) + carry;
                carry = sum / 10;
                sumNode.Next = new Node(sum % 10);
                sumNode = sumNode.Next;
                reversedNode1 = reversedNode1?.Next;
                reversedNode2 = reversedNode2?.Next;
            }
            if (carry > 0) sumNode.Next = new Node(carry);
            return dummy.Next.ReverseInplace();
        }

        public static Node DeleteDuplicates(this Node node)
        {
            if (node is null) { return node; }
            HashSet<int> nums = new HashSet<int>();
            Node current = node, prev = node;
            while (current != null)
            {
                if (nums.Contains(current.Data))
                {
                    prev.Next = current.Next;
                }
                else
                {
                    nums.Add(current.Data);
                    prev = current;
                }
                current = current.Next;
            }
            return node;
        }

        public static Node ReorderList(this Node head)
        {
            if (head is null) return head;
            Node current = head;
            Node test = head;
            Node reversed = current.Reverse();
            int length = head.Length();
            int count = 0;
            current = head;
            while (reversed != null && count < ((length) / 2))
            {
                Node rnext = reversed.Next;
                Node cnext = current.Next;

                current.Next = reversed;
                reversed.Next = cnext;
                reversed = rnext;
                current = cnext;
                count++;
            }
            return head;
        }

        public static int Length(this Node head)
        {
            Node current = head;
            int length = 0;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length;
        }

        public static Node DeleteNthNodeFromEnd(this Node node, int n)
        {
            if (node is null) return node;
            Node dummy = new Node(-1);
            dummy.Next = node;
            Node slow = dummy;
            Node fast = dummy;
            while (n + 1 >= 1)
            {
                fast = fast.Next;
                n--;
            }
            while (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            if (slow.Next == null)
            {
                slow.Next = null;
            }
            else
            {
                slow.Next = slow.Next.Next;
            }
            return dummy.Next;
        }

        public static Node SwapNodePairs(this Node node)
        {
            if (node is null) return node;
            Node dummy = new Node(-1);
            dummy.Next = node;
            Node prev = dummy;

            while (node != null && node.Next != null)
            {
                var firstNode = node;
                var secondNode = node.Next;

                prev.Next = secondNode;
                firstNode.Next = secondNode.Next;
                secondNode.Next = firstNode;

                prev = firstNode;
                node = firstNode.Next;
            }
            return dummy.Next;
        }
    }
}