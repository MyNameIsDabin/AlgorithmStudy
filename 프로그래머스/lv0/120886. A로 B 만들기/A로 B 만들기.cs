using System;
using System.Linq;

public class Solution 
{
    public int solution(string before, string after)
    {
        if (before.Length != after.Length)
            return 0;

        var beforeWords = before.OrderBy(x => x).ToArray();
        var afterWords = after.OrderBy(x => x).ToArray();

        for (var i = 0; i < beforeWords.Length; i++)
        {
            if (afterWords[i] != beforeWords[i])
                return 0;
        }

        return 1;
    }
}