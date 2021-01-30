using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists
{

    public class SingleLinkedList
    {
        private int _length;
        private SingleLinkedListNode _head;
        public SingleLinkedList()
        {
            _length = 0;
            _head = null;
        }
        public int Length { get => this._length; }


        public override string ToString()
        {
            if (_head is null) { return string.Empty; }
            StringBuilder output = new StringBuilder();
            SingleLinkedListNode current = this._head;
            while (current != null)
            {
                output.Append(current.Data);
                if (current.Next != null)
                {
                    output.Append(" -> ");
                }
                current = current.Next;
            }
            return output.ToString();
        }
        public void Add(int data)
        {
            Console.WriteLine($"Before Add...");
            this.Print();
            SingleLinkedListNode newNode = new SingleLinkedListNode(data);
            SingleLinkedListNode current = this._head;
            if (_head is null)
            {
                this._head = newNode;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                _length++;
            }
            Console.WriteLine($"After Add...");
            this.Print();
        }
        public void Print()
        {
            if (_head is null) { Console.WriteLine("No nodes print."); }
            StringBuilder output = new StringBuilder();
            SingleLinkedListNode current = this._head;
            while (current != null)
            {
                output.Append(current.Data);
                if (current.Next != null)
                {
                    output.Append(" -> ");
                }
                current = current.Next;
            }
            Console.WriteLine(output.ToString());
        }



        public void Reverse()
        {
            SingleLinkedListNode prev = null, current = this._head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            this._head = prev;
            this.Print();
        }

        public void RemoveDuplicates()
        {
            if (this._head is null) { return; }
            HashSet<int> set = new HashSet<int>();
            SingleLinkedListNode current = this._head;
            SingleLinkedListNode previous = null;
            while (current != null)
            {
                if (set.Contains(current.Data))
                {
                    previous.Next = current.Next;
                }
                else
                {
                    set.Add(current.Data);
                    previous = current;
                }
                current = current.Next;
            }
            this.Print();
        }

        public void RemoveDuplicatesFromSortedList()
        {
            if (this._head is null) { return; }
            SingleLinkedListNode current = this._head;
            while (current != null && current.Next != null)
            {
                if (current.Data == current.Next.Data)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
            this.Print();
        }

        

        public int? KthToTheLast(int k)
        {
            if (this._head is null) { return null; }
            SingleLinkedListNode slow = this._head;
            SingleLinkedListNode fast = this._head;
            for (int i = 0; i < k; i++)
            {
                if (fast.Next is null) { return null; }
                fast = fast.Next;
            }
            while (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow.Data;
        }
    }
}