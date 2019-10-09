using System;
using Algorithms.Arrays;
using Algorithms.Cache;
using Algorithms.LinkedLists.SingleLinkedList;
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

            Console.WriteLine("aabcccccaaa".CompressString());
            SingleLinkedList list = new SingleLinkedList();
            list.Add(5);
            list.Add(10);
            list.Add(11);
            list.Add(4);
            list.Add(11);
            list.Add(13);
            list.Reverse();
            list.RemoveDuplicates();
            new int[]{2,2,1}.GetUniqueNumber();
            //var perm = "vgamsi".Permute();
            Console.WriteLine(list.KthToTheLast(5));
            LRUCache cache = new LRUCache(3);
            cache.Put(1,858);
            cache.Put(2,8);
            cache.Put(4,558);
            cache.Get(2);
            cache.Put(8,789);
            new int[] {1,2,6,0,0,0}.MergeSortedArray(3, new int[] {2,3,5}, 3);
            new int[] {1}.SearchInRotatedArray(0);
            new int[] {2, 7, 11, 15}.Rotate(2);
            Console.ReadLine();
            
        }
    }
}

public class Rbac{
    public string Source { get; set; }
    public string Cmd { get; set; }
    public string[] Scopes { get; set; }
}
