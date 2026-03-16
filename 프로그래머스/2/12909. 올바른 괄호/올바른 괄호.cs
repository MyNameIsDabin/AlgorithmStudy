using System;
using System.Collections;

public class Solution 
{
    public bool solution(string s)
    {
        var charArray = s.ToCharArray();
        var stack = new Stack();

        foreach (var c in charArray)
        {
            if (c == '(')
            {
                stack.Push(c);   
            }
            else
            {
                if (stack.Count > 0)
                    stack.Pop();
                else
                    return false;
            }
        }

        return stack.Count == 0;
    }
}