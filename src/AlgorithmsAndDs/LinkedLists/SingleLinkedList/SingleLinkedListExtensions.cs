using static Algorithms.LinkedLists.SingleLinkedList;
using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithms.LinkedLists
{
    public static class SingleLinkedListExtensions
    {
        public static SingleLinkedListNode ReverseInplace(this SingleLinkedListNode node)
        {
            SingleLinkedListNode current = node, prev = null, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
        public static SingleLinkedListNode Reverse(this SingleLinkedListNode node)
        {
            SingleLinkedListNode newNode = node.Copy();
            SingleLinkedListNode current = newNode, prev = null, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static SingleLinkedListNode Copy(this SingleLinkedListNode node)
        {
            SingleLinkedListNode newNode = new SingleLinkedListNode(node.Data);
            SingleLinkedListNode current = newNode;
            node = node.Next;
            while (node != null)
            {
                SingleLinkedListNode n2 = new SingleLinkedListNode(node.Data);
                current.Next = n2;
                current = n2;
                node = node.Next;
            }
            return newNode;
        }
        public static SingleLinkedListNode Add(this SingleLinkedListNode node1, SingleLinkedListNode node2)
        {
            SingleLinkedListNode reversedNode1 = node1.ReverseInplace();
            SingleLinkedListNode reversedNode2 = node2.ReverseInplace();
            SingleLinkedListNode dummy = new SingleLinkedListNode(-1);
            SingleLinkedListNode sumNode = dummy;
            int carry = 0;
            while (reversedNode1 != null || reversedNode2 != null)
            {
                int sum = (reversedNode1?.Data ?? 0) + (reversedNode2?.Data ?? 0) + carry;
                carry = sum / 10;
                sumNode.Next = new SingleLinkedListNode(sum % 10);
                sumNode = sumNode.Next;
                reversedNode1 = reversedNode1?.Next;
                reversedNode2 = reversedNode2?.Next;
            }
            if (carry > 0) sumNode.Next = new SingleLinkedListNode(carry);
            return dummy.Next.ReverseInplace();
        }

        public static SingleLinkedListNode DeleteDuplicates(this SingleLinkedListNode node)
        {
            if (node is null) { return node; }
            HashSet<int> nums = new HashSet<int>();
            SingleLinkedListNode current = node, prev = node;
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

        public static SingleLinkedListNode ReorderList(this SingleLinkedListNode head)
        {
            if (head is null) return head;
            SingleLinkedListNode current = head;
            SingleLinkedListNode test = head;
            SingleLinkedListNode reversed = current.Reverse();
            int length = head.Length;
            int count = 0;
            current = head;
            while (reversed != null && count < ((length) / 2))
            {
                SingleLinkedListNode rnext = reversed.Next;
                SingleLinkedListNode cnext = current.Next;

                current.Next = reversed;
                reversed.Next = cnext;
                reversed = rnext;
                current = cnext;
                count++;
            }
            return head;
        }

        public static SingleLinkedListNode DeleteNthNodeFromEnd(this SingleLinkedListNode node, int n)
        {
            if (node is null) return node;
            SingleLinkedListNode dummy = new SingleLinkedListNode(-1);
            dummy.Next = node;
            SingleLinkedListNode slow = dummy;
            SingleLinkedListNode fast = dummy;
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

        public static SingleLinkedListNode SwapNodePairs(this SingleLinkedListNode node)
        {
            if (node is null) return node;
            SingleLinkedListNode dummy = new SingleLinkedListNode(-1);
            dummy.Next = node;
            SingleLinkedListNode prev = dummy;

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

        public static SingleLinkedListNode RemoveDuplicatesFromSortedListII(this SingleLinkedListNode head)
        {
            if (head is null) return head; 
            var dummy = new SingleLinkedListNode(-1);
            dummy.Next = head;
            var prev = dummy;

            while(head != null){
                if(head.Next != null && head.Data == head.Next.Data){
                    while(head.Next != null && head.Data == head.Next.Data){
                        head = head.Next;
                    }
                    prev.Next = head.Next;
                }
                else {
                    prev = prev.Next;
                }
                head = head.Next;
            }

            return dummy.Next;
        }
    }
}