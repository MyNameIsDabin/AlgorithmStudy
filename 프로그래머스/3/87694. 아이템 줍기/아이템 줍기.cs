using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    private Dictionary<string, bool> validPoints;
    private int targetX;
    private int targetY;

    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY) 
    {
        validPoints = new Dictionary<string, bool>();
        targetX = itemX * 2;
        targetY = itemY * 2;

        for (var i = 0; i < rectangle.GetLength(0); i++) 
        {
            var leftBottomX = rectangle[i, 0] * 2;
            var leftBottomY = rectangle[i, 1] * 2;
            var rightTopX = rectangle[i, 2] * 2;
            var rightTopY = rectangle[i, 3] * 2;

            for (var x = leftBottomX; x <= rightTopX; x++)
            {
                AddValidPoint(x, rightTopY, true);
                AddValidPoint(x, leftBottomY, true);

                if (x == leftBottomX || x == rightTopX)
                    continue;

                AddValidPoint(x, rightTopY - 1, false);
                AddValidPoint(x, leftBottomY + 1, false);
            }

            for (var y = leftBottomY; y <= rightTopY; y++) 
            {
                AddValidPoint(leftBottomX, y, true);
                AddValidPoint(rightTopX, y, true);

                if (y == leftBottomY || y == rightTopY)
                    continue;

                AddValidPoint(leftBottomX + 1, y, false);
                AddValidPoint(rightTopX - 1, y, false);
            }
        }

        var result = Search(characterX * 2, characterY * 2, 0);
        return result / 2;
    }

    private void AddValidPoint(int x, int y, bool value) 
    {
        var key = x + "," + y;
        bool flag;
        if (validPoints.TryGetValue(key, out flag) == false || flag) 
        {
            validPoints[key] = value;
        }
    }

    private int Search(int x, int y, int step) 
    {
        if (x == targetX && y == targetY)
            return step;

        var key = x + "," + y;
        bool value;
        if (!validPoints.TryGetValue(key, out value) || !value)
            return int.MaxValue;

        validPoints.Remove(key);

        step++;

        var distances = new [] 
        {
            Search(x, y + 1, step),
            Search(x, y - 1, step),
            Search(x + 1, y, step),
            Search(x - 1, y, step)
        };

        return distances.Min();
    }
}