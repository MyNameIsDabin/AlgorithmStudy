using System;

public class Solution 
{
    public int solution(int[] array, int n)
    {
        Array.Sort(array);

        var minIndex = 0;
        var minDistance = n - array[minIndex];

        for (var i = 1; i < array.Length; i++)
        {
            var distance = Math.Abs((array[i] - n));

            if (distance == 0)
                return array[i];

            if (minDistance > distance)
            {
                minDistance = distance;
                minIndex = i;
            }
        }

        return array[minIndex];
    }
}