using System;
namespace Algorithms.LinkedLists.DoubleLinkedList {
    public class DoubleLinkedList {
        internal Node Head { get; set; }
        internal Node Tail { get; set; }
        internal class Node{
            public int Data { get; set; }
            public int Key { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
        public DoubleLinkedList()
        {
            this.Head = new Node();
            this.Tail = new Node();
            this.Head.Next = this.Tail;
            this.Tail.Previous = this.Head;
        }
        internal void Add(Node n){
            n.Previous = this.Head;
            n.Next = this.Head.Next;
            this.Head.Next.Previous = n;                                                                                                                                                                                                                                                                             
            this.Head.Next = n;
            
        }

        internal void Delete(Node n){
            Node previous = n.Previous;
            Node next = n.Next;
            if(previous != null){
                previous.Next = next;
            }
            if(next != null){
                next.Previous = previous;
            }
        }

        internal Node PopTail(){
            Node prev = Tail.Previous;
            Delete(prev);
            return prev;
        }

        internal void MoveToHead(Node n){
            Delete(n);
            Add(n );
        }
    }
}