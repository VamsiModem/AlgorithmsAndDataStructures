using System;
using System.Collections.Generic;
using Algorithms.LinkedLists.DoubleLinkedList;
using static Algorithms.LinkedLists.DoubleLinkedList.DoubleLinkedList;

namespace Algorithms.Cache{
    public class LRUCache{
        private int _capacity;
        private int _size = 0;
        private DoubleLinkedList _list = new DoubleLinkedList();
        private Dictionary<int, Node> _cache = new Dictionary<int, Node>();
        public LRUCache(int capacity)
        {
            this._capacity = capacity;
        }

        public int Get(int key){
            if(_cache.ContainsKey(key)){
                Node n = _cache[key];
                _list.MoveToHead(n);
                return n.Data;
            }
            return -1;
        }

        public void Put(int key, int value){
            Node n = null;
            if(_cache.ContainsKey(key)){ n = _cache[key]; }
            if(n is null){
                Node newNode = new Node(){Data = value, Key = key};
                _list.Add(newNode);
                _cache.Add(key, newNode);
                _size++;
                if(_size > _capacity){
                    Node deleted = _list.PopTail();
                    _cache.Remove(deleted.Key);
                    _size--;
                }
            }else{
                _cache[key].Data = value;
                _list.MoveToHead(n);
            }
        }
    }
}