using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int[] solution(int n)
    {
        var answer = new HashSet<int>();

        for (var i = 2; i <= n; i++)
        {
            if (n % i == 0)
            {
                n /= i;
                answer.Add(i);
                i = 1;
            }
        }

        return answer.OrderBy(x => x).ToArray();
    }
}