using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.LinkedLists;

namespace Algorithms.Graphs{
    public class Graph{
        private int _edgeCount;
        private Dictionary<int, SingleLinkedList> _adjList;
        public int EdgeCount {
            get {
                return _edgeCount;
            }
        }
        public Graph()
        {
            _adjList = new Dictionary<int, SingleLinkedList>();
        }
        public void Add(int v, int w){
            if(!_adjList.ContainsKey(v)){
                _adjList.Add(v, new SingleLinkedList());
            }
            _adjList[v].Add(w);
            if(!_adjList.ContainsKey(w)){
                _adjList.Add(w, new SingleLinkedList());
            }
            _adjList[w].Add(v);
            _edgeCount += 2;
            Print();
        }

        public int Degree(int v){
            if(_adjList.TryGetValue(v, out var val)){
                return val.Length + 1;
            }
            return 0;
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            foreach(var kvp in _adjList){
                sb.Append(kvp.Key).Append(" : ").Append(kvp.Value.ToString()).AppendLine();
            }
            return sb.ToString();
        }
        public void Print() => Console.Write(this.ToString());
        
    }
}