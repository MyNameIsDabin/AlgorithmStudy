using System;

public class Solution
{
    public int solution(int[,] dots)
    {
        var minX = dots[0, 0];
        var maxX = dots[0, 0];
        var minY = dots[0, 1];
        var maxY = dots[0, 1];

        for (var i = 1; i < dots.GetLength(0); i++)
        {
            var x = dots[i, 0];
            var y = dots[i, 1];

            if (y < minY)
                minY = y;
            if (x < minX) 
                minX = x;
            if (y > maxY) 
                maxY = y;
            if (x > maxX)
                maxX = x;
        }

        return (maxY - minY) * (maxX - minX);
    }
}