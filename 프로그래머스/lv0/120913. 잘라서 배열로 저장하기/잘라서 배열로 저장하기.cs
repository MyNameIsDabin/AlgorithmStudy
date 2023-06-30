using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public string[] solution(string my_str, int n)
    {
        var answer = new List<string>();
        var characters = my_str.ToArray();
        var startIndex = 0;

        for (var i = 0; i < Math.Ceiling((float)characters.Length / n); i++)
        {
            startIndex = (i * n);

            var substring = my_str.Substring(startIndex, Math.Min(characters.Length - startIndex, n));
            
            answer.Add(substring);
        }

        return answer.ToArray();
    }
}