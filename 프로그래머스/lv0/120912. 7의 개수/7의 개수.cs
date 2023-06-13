using System;
using System.Linq;

public class Solution 
{
    public int solution(int[] array) 
        => array.Sum(x => x.ToString().Count(y => y == '7'));
}