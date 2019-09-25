using System;
using Algorithms.Arrays;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = StringProblems.ReverseWordsInString("Hello World!");
            Console.WriteLine(x);
            MinMaxStack stack = new MinMaxStack();
            stack.Push(5);
            stack.Push(2);
            stack.Push(3);
            stack.Push(1);
            stack.Push(4);

            stack.Print();
            Console.WriteLine(stack.Min);
            Console.WriteLine(stack.Max);
            Console.WriteLine(stack.Pop());
            stack.Print();
            Console.WriteLine(stack.Min);
            Console.WriteLine(stack.Max);
            new int[] {2, 7, 11, 15}.TwoSum(9).Print();
        }
    }
}
