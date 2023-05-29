using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmStudy
{
    public class Solution
    {
        // public bool hasWord(int y, int x, string word)
        // {
        //     var words = word.ToCharArray();
        //     
        //     if (words[0] )
        // }
        
        public void RecursivePick(List<int> picked, int chance = 2, int cards = 3)
        {
            if (chance == 0)
            {
                Console.WriteLine(string.Join(", ", picked.Select(_ => _.ToString()).ToArray()));
                return;
            }

            var begin = picked.Count == 0 ? 0 : picked.Last() + 1;
            
            for (var i = begin; i < cards; i++)
            {
                picked.Add(i);
                RecursivePick(picked, chance - 1, cards);
                picked.RemoveAt(picked.Count - 1);
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            
            var picks = new List<int>();
            solution.RecursivePick(picks);
        }
    }
}