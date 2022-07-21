using BinaryTreeCol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>(new DirectBinaryEnumerator()) { };
       
        binaryTree.Add(33);
        binaryTree.Add(55);
        binaryTree.Add(44);
        binaryTree.Add(23);
        binaryTree.Add(31);
        binaryTree.Add(5);
        binaryTree.Add(2);
        binaryTree.Add(14);
        binaryTree.Add(8);
        binaryTree.Add(4);

        Console.WriteLine($"Count of elements: {binaryTree.Count}");

        Console.Write("Pre-order: ");
        foreach (var item in binaryTree)
        {
            Console.Write($"{item} ");
        }

        binaryTree.Enumerator = new ReverseBinaryTreeEnumerator();
        Console.Write("\nPost-order: ");
        foreach (var item in binaryTree)
        {
            Console.Write($"{item} ");
        }

        Console.Write("\nUnusualOrder: ");
        foreach (var item in binaryTree.UnusualOrder())
        {
            Console.Write($"{item} ");
        }
        
        Console.WriteLine($"\nContains element 5? - {binaryTree.Contains(5)}");

        binaryTree.Enumerator = new DirectBinaryEnumerator();
        Console.Write($"Binary tree after removing 5 - \"{binaryTree.Remove(5)}\": ");
        foreach (var item in binaryTree)
        {
            Console.Write($"{item} ");
        }

        Console.Write("\nCopy elements from BinaryTree into array: ");
        int[] arr = new int[binaryTree.Count];
        binaryTree.CopyTo(arr, 0);
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }

        Console.Write("\nResult searching: ");
        var resultFilter = binaryTree.Where(item => item > 12).ToBinary<int>();
        foreach (var item in resultFilter)
        {
            Console.Write($"{item} ");
        }

        Console.Write("\nResult ordering: ");
        var resultOrder = binaryTree.OrderBy(i => i).ToBinary<int>();
        foreach (var item in resultOrder)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine($"\nFirst element of BinaryTree: {binaryTree.First()}");

        var resultCasting = binaryTree.ToList();

        Console.Write("Converting any collection to BinaryTree: ");
        var list = new List<int>() {34, 21, 5, 3, 12, 6, 8};
        var resultConverting = list.ToBinary<int>();
        foreach ( var item in resultConverting)
        {
            Console.Write($"{item} ");
        }

        binaryTree.Clear();
        Console.WriteLine($"\nBinaryTree after cleaning: {binaryTree.Count}");
    }
}