using System;

public class Solution 
{
    public int solution(int num, int k)
    {
        var index = num.ToString().IndexOf(k.ToString());

        return index >= 0 ? index + 1 : index;
    }
}