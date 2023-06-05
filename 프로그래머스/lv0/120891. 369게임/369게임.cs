using System;
using System.Linq;

public class Solution 
{
    public int solution(int order)
    {
        var toNumber = (char)0 - '0';

        var count = order
            .ToString()
            .Count(x =>
            {
                var number = (x + toNumber);
                return number != 0 && number % 3 == 0;
            });

        return count;
    }
}