using System;
using Algorithms.Arrays;
using Algorithms.Strings;
namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "Hello World!".ReverseWordsInString();
            Console.WriteLine(x);
            // MinMaxStack stack = new MinMaxStack();
            // stack.Push(5);
            // stack.Push(2);
            // stack.Push(3);
            // stack.Push(1);
            // stack.Push(4);

            // stack.Print();
            // Console.WriteLine(stack.Min);
            // Console.WriteLine(stack.Max);
            // Console.WriteLine(stack.Pop());
            // stack.Print();
            // Console.WriteLine(stack.Min);
            // Console.WriteLine(stack.Max);
            // new int[] {2, 7, 11, 15}.TwoSum(9).Print();
            //Console.WriteLine("vamsiv".HasUniqueCharacters());
            Console.WriteLine("vamgsi".IsPermutation("aitsv"));
            Console.ReadLine();
        }
    }
}

public class Rbac{
    public string Source { get; set; }
    public string Cmd { get; set; }
    public string[] Scopes { get; set; }
}
