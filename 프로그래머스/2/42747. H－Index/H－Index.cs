using System;
using System.Linq;

public class Solution 
{
    public int solution(int[] citations)
    {
        for (var h = citations.Length; h > -1; h--)
        {
            var hCount = citations.Count(c => c >= h);
            if (hCount >= h)
                return h;
        }
        
        return 0;
    }
}