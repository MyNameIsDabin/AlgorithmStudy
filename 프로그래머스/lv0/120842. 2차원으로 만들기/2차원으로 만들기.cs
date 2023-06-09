using System;

public class Solution 
{
    public int[,] solution(int[] num_list, int n)
    {
        var width = n;
        var height = num_list.Length / width;

        var answer = new int[height, width];

        for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                answer[i, j] =  num_list[(i * n) + j];

        return answer;
    }
}