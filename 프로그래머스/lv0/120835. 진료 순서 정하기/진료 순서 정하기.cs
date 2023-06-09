using System;
using System.Linq;

public class Solution 
{
    public int[] solution(int[] emergency)
    {
        var sorted = emergency.OrderByDescending(x => x).ToArray();

        return emergency.Select(x => Array.FindIndex(sorted, _ => _ == x) + 1).ToArray();
    }
}