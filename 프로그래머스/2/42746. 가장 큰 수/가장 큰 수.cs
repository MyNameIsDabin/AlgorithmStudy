using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string solution(int[] numbers)
    {
        var arr = numbers.Select(n => n.ToString()).ToArray();
        
        Array.Sort(arr, (x, y) =>
        {
            var xy = x + y;
            var yx = y + x;
            return yx.CompareTo(xy);
        });
        
        if (arr[0] == "0")
        {
            return "0";
        }
        
        return string.Join("", arr);
    }
}