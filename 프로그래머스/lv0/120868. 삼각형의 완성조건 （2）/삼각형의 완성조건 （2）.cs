using System;

public class Solution
{
    public int solution(int[] sides)
    {
        var min = 0;
        var max = 0;

        if (sides[0] > sides[1])
        {
            max = sides[0];
            min = sides[1];
        }
        else
        {
            min = sides[0];
            max = sides[1];
        }

        var caseA = max - (max - min);
        var caseB = (min + max) - (max + 1);

        return caseA + caseB;
    }
}