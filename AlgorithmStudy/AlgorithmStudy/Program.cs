using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    public class Solution
    {
        public int solution(string[] spell, string[] dic)
        {
            var spells = spell
                .Select(x => x.ToCharArray()[0])
                .ToArray();
            
            for (var i = 0; i < dic.Length; i++)
            {
                var count = 0;
                for (var j = 0; j < spells.Length; j++)
                {
                    var c = spells[j];
                    var findIndex = Array.FindIndex(dic[i].ToArray(), x => x == c);

                    if (findIndex >= 0)
                    {
                        dic[i] = dic[i].Remove(findIndex, 1);
                        count++;
                    }
                }

                if (dic[i].Length == 0 && count == spells.Length)
                    return 1;
            }

            return 2;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            
            Console.WriteLine(solution.solution(new [] {"s", "o", "m", "d"}, new [] {"moos", "dzx", "smm", "sunmmo", "som"}));

            // for (int i = 0; i < 100; i++)
            // {
            //     Console.WriteLine($"----------{i}----------");
            //     Console.WriteLine(string.Join(", ", solution.solution(i).Select(x => x.ToString()).ToArray()));    
            // }

            //Console.WriteLine(string.Join(", ", solution.solution("3 + 4").Select(x => x.ToString()).ToArray()));
        }
    }
}