using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public string solution(string s)
    {
        var dictionary = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (dictionary.ContainsKey(s[i]) == false)
                dictionary[s[i]] = 0;

            dictionary[s[i]]++;
        }

        var onlyOneCounts = dictionary.Where(x => x.Value == 1);

        if (onlyOneCounts.Count() == 0)
            return "";

        return new string(onlyOneCounts
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToArray());
    }
}