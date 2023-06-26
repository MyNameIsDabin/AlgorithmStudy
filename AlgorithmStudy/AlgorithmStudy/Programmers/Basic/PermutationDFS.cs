using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmStudy.Programmers.Basic
{
    public class PermutationDFS
    {
        public void Permute(int[] arr, bool[] visited, int[] output, int depth)
        {
            if (depth == arr.Length)
            {
                Console.WriteLine(string.Join(",", output.Select(x => x.ToString()).ToArray()));
                return;
            }
            
            for (var i = 0; i < arr.Length; i++)
            {
                if (visited[i])
                    continue;

                visited[depth] = true;
                output[depth] = arr[i];
                Permute(arr, visited, output, depth + 1);
                visited[depth] = false;
            }
        }
        
        public static void RunTest()
        {
            var solution = new PermutationDFS();

            var visited = default(bool[]);
            
            solution.Permute(new [] { 1, 2, 3 }, visited, new int[3], 0);
        }
    }
}