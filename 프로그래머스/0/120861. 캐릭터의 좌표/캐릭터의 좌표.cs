using System;

public class Solution
{
    public int[] solution(string[] keyinput, int[] board)
    {
        var position = (x: 0, y: 0);
        var boundary = (x: board[0] / 2, y: board[1] / 2);

        foreach (var key in keyinput)
        {
            switch (key)
            {
                case "left":
                    position.x--;
                    break;
                case "right":
                    position.x++;
                    break;
                case "up":
                    position.y++;
                    break;
                case "down":
                    position.y--;
                    break;
            }

            position.x = Math.Min(Math.Max(-boundary.x, position.x), boundary.x);
            position.y = Math.Min(Math.Max(-boundary.y, position.y), boundary.y);
        }

        return new int[] { position.x, position.y };
    }
}