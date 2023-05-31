using System;

public class Solution 
{
    public int solution(int n)
    {
        var i = 1; 
        for (; ((6 * i) % n != 0); i++) { }
        return i;
    }
}