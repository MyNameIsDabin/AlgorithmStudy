using System;

public class Solution 
{
    public int solution(string my_string)
    {
        var inputs = my_string.Split(' ');

        var result = int.Parse(inputs[0]);
        var operation = inputs[1];
        var isNumber = true;

        for (var i = 2; i < inputs.Length; i++)
        {
            var input = inputs[i];

            if (isNumber)
            {
                var number = int.Parse(input);

                if (operation == "+")
                    result += number;
                else
                    result -= number;
            }
            else
            {
                operation = input;
            }

            isNumber = !isNumber;
        }

        return result;
    }
}