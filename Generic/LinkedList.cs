using System.Text;
using Algorithms.Generic.Contracts;

namespace Algorithms.Generic{
    public class LinkedList<T> : ILinkedList<T>
    {
        private sealed class Node{
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data) { this.Data = data; }
        }
        public LinkedList()
        {
            _length = 0;
            _head = null;
        }
        private Node _head;
        private int _length;
        public int Length => _length;

        public void Add(T data)
        {
            Node newNode = new Node(data);
            Node current = _head;
            if(_head is null){ 
                _head = newNode; 
            }
            else{                
                while(current.Next != null){
                    current = current.Next;
                }
                current.Next = newNode;
                _length++;
            }
        }
        
        public override string ToString(){
            if(_head is null){ return string.Empty; }
            StringBuilder output = new StringBuilder();
            Node current = _head;
            while(current != null){
                output.Append(current.Data);
                if(current.Next != null){
                    output.Append(" -> ");
                }
                current = current.Next;
            }
            return output.ToString();
        }
    }
}