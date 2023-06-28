using System;

public class Solution 
{
    public long solution(int balls, int share)
    {
        if (share == 0)
            return 1;

        var result = Factorial(balls) / (Factorial(balls - share) * Factorial(share));

        return (int)Math.Round(result);
    }

    public double Factorial(double n)
        => n <= 1 ? 1 : n * Factorial(n - 1);
}