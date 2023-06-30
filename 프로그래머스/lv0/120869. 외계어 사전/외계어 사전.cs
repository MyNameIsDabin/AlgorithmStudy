using System;
using System.Linq;

public class Solution
{
    public int solution(string[] spell, string[] dic)
    {
        var spells = spell
            .Select(x => x.ToCharArray()[0])
            .ToArray();

        for (var i = 0; i < dic.Length; i++)
        {
            var count = 0;
            for (var j = 0; j < spells.Length; j++)
            {
                var c = spells[j];
                var findIndex = Array.FindIndex(dic[i].ToArray(), x => x == c);

                if (findIndex >= 0)
                {
                    dic[i] = dic[i].Remove(findIndex, 1);
                    count++;
                }
            }

            if (dic[i].Length == 0 && count == spells.Length)
                return 1;
        }

        return 2;
    }
}