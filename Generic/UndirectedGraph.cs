using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Generic.Contracts;

namespace Algorithms.Generic{
    public class UndirectedGraph<T> : IGraph<T>
    {
        private int _edgeCount;
        private Dictionary<T, LinkedList<T>> _adjList;
        public int EdgeCount => _edgeCount;
        public UndirectedGraph()
        {
            _adjList = new Dictionary<T, LinkedList<T>>();
        }

        public void Add(T v, T w)
        {
            if(!_adjList.ContainsKey(v)){
                _adjList.Add(v, new LinkedList<T>());
            }
            _adjList[v].Add(w);
            if(!_adjList.ContainsKey(w)){
                _adjList.Add(w, new LinkedList<T>());
            }
            _adjList[w].Add(v);
            _edgeCount += 2;
            Print();
        }

        public int Degree(T v)
        {
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