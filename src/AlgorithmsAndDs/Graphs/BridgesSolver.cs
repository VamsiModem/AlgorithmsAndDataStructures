using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs{
    public class BridgesSolver{
        private readonly IList<int>[] _graph;
        private readonly int _size;
        private bool[] _visited;
        private int[] _ids;
        private int[] _lows;
        private int _id = 0;
  

        public BridgesSolver(IList<IList<int>> connections, int size)
        {
            _size = size;
            _ids = new int[size];
            _lows = new int[size];
            _visited = new bool[size];
            _graph = BuildGraph(connections);
        }

        private IList<int>[] BuildGraph(IList<IList<int>> connections)
        {
             IList<int>[] graph = new List<int>[_size];
             foreach(var connection in connections){
                if(graph[connection.ElementAt(0)] is null)
                    graph[connection.ElementAt(0)] = new List<int>();
                graph[connection.ElementAt(0)].Add(connection.ElementAt(1));
                if(graph[connection.ElementAt(1)] is null)
                    graph[connection.ElementAt(1)] = new List<int>();
                graph[connection.ElementAt(1)].Add(connection.ElementAt(0));
             }
             return graph;
        }

        public IList<IList<int>> Solve(){
            IList<IList<int>> bridges = new List<IList<int>>();
            for(int i = 0; i < _size; i++){
                if(!_visited[i])
                    Dfs(i, -1, bridges);
            }
            return bridges;
        }

        private void Dfs(int at, int parent, IList<IList<int>> bridges){
            _visited[at] = true;
            _ids[at] = _lows[at] = ++_id;
            foreach(var to  in _graph[at]){
                if (to == parent) continue;
                if(!_visited[to]){
                    Dfs(to, at, bridges);
                    _lows[at] = Math.Min(_lows[at], _lows[to]);
                    if(_ids[at] < _lows[to]){
                        bridges.Add(new List<int>(){at, to});
                    }
                }else{
                    _lows[at] = Math.Min(_lows[at], _ids[to]);
                }
            }
        }
    }
}