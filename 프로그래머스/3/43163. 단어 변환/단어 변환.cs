using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(string begin, string target, string[] words) 
    {
        var dict = new Dictionary<int, HashSet<char>>();

        foreach (var word in words)
        {
            for (var i = 0; i < word.Length; i++)
            {
                if (!dict.ContainsKey(i))
                    dict.Add(i, new HashSet<char>());
                dict[i].Add(word[i]);
            }
        }

        var answer = Step(begin, target, 0, dict, new HashSet<string>(words));
        return answer == 9999 ? 0 : answer;
    }

    int Step(string word, string target, int step, Dictionary<int, HashSet<char>> dict, HashSet<string> temp)
    {
        if (word == target)
            return step;

        var minStep = 9999;

        for (var i = 0; i < word.Length; i++)
        {
            foreach (var character in dict[i])
            {
                if (character == word[i])
                    continue;

                var front = string.Concat(word.Take(i));
                var end = string.Concat(word.Skip(i + 1));
                var replace = front + character + end;

                if (!temp.Contains(replace)) 
                    continue;

                temp.Remove(replace);

                var next = Step(replace, target, step + 1, dict, new HashSet<string>(temp));
                if (minStep > next)
                    minStep = next;
            }
        }

        return minStep;
    }
}