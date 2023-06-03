using System;
using System.Linq;

public class Solution 
{
        public string solution(string my_string)
        {
            var test = my_string
                .Select(x => char.ToLower(x))
                .OrderBy(x => (int)x);

            return new string(test.ToArray());
        }
}