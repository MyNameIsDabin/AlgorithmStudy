using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution 
{
    public int solution(string my_string)
    {
        var regex = new Regex("[a-zA-Z]");

        return regex
            .Split(my_string)
            .Where(x => !string.IsNullOrEmpty(x))
            .Sum(x => int.Parse(x));
    }
}