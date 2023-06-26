using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    public class Solution 
    {
        public void Permutation(int[] arr, int depth)
        {
            if (depth == arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr.Select(x => x.ToString()).ToArray()));
                return;
            }

            for (var i = depth; i < arr.Length; i++)
            {
                Swap(ref arr[depth], ref arr[i]);
                Permutation(arr, depth + 1);
                Swap(ref arr[depth], ref arr[i]);
            }
        }

        public void Swap(ref int lv, ref int rv)
        {
            var temp = lv;
            lv = rv;
            rv = temp;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();

            solution.Permutation(new [] { 1, 2, 3 }, 0);
        }
    }
}