using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Models;

namespace Algorithms
{
    public class MinMaxStack {
        private List<MinMaxStackElement> _stack = new List<MinMaxStackElement>();
        public int? Min => this.Peek().Min;
        public int? Max => this.Peek().Max;
        public void Push(int value){
            this._stack.Add(
                new MinMaxStackElement
                {
                    Value = value,
                    Min = this._stack.Count == 0 ? value : (value < Peek().Min ? value : Peek().Min),
                    Max = this._stack.Count == 0 ? value : (value > Peek().Max ? value : Peek().Max),
                }
            );
        }
        public int? Pop(){
            if(this._stack.Count == 0){return null;}
            MinMaxStackElement element = this._stack.ElementAt(this._stack.Count - 1);
            this._stack.RemoveAt(this._stack.Count - 1);
            return element.Value;
        }
        public MinMaxStackElement Peek(){
            if(this._stack.Count == 0){return null;}
            else return this._stack.ElementAt(this._stack.Count - 1);
        }

        public void Print(){
            StringBuilder sb = new StringBuilder("[");
            for(int i = 0; i < this._stack.Count; i++){
                sb.Append(this._stack.ElementAt(i).Value.ToString());
                if(i != this._stack.Count - 1){
                     sb.Append(", ");
                }
            }
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }
}