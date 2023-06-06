using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public string solution(string my_string)
        => new string(new HashSet<char>(my_string.ToCharArray()).ToArray());
}