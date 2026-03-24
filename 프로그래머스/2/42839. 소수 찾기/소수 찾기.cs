using System;
using System.Collections.Generic;

public class Solution
{
    private HashSet<int> counts = new HashSet<int>();

    public int solution(string numbers) 
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            Search(numbers[i].ToString(), numbers.Substring(0, i) + numbers.Substring(i + 1));
        }

        return counts.Count;
    }

    private void Search(string combine, string extra)
    {
        var number =  int.Parse(combine);

        var isSuccess = number >= 2;

        for (var i = 2; i <= number / 2; i++)
        {
            if (i != number && number % i == 0)
            {
                isSuccess = false;
                break;
            }
        }

        if (isSuccess)
            counts.Add(number);

        for (var i = 0; i < extra.Length; i++)
        {
            var added = combine + extra[i];

            Search(added, extra.Substring(0, i) + extra.Substring(i + 1));
        }
    }
}