using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists
{
    public sealed class SingleLinkedListNode
    {
        public int Data { get; set; }
        public int Length
        {
            get
            {
                SingleLinkedListNode current = this;
                int length = 0;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }
                return length;
            }
        }
        public SingleLinkedListNode Next { get; set; }

        public override bool Equals(object obj)
        {
            var node1 = this;
            SingleLinkedListNode node = obj as SingleLinkedListNode;
            while (node1 != null && node != null)
            {
                if (node1.Data != node.Data)
                {
                    return false;
                }
                node1 = node1.Next;
                node = node.Next;
            }
            if (node is null && node1 is null) return true;
            return false;
        }
        public override int GetHashCode() => Data.GetHashCode();

        public SingleLinkedListNode(int data)
        {
            this.Data = data;
        }
    }
}