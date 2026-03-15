using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private bool[,] visitedBoard = new bool[50, 50];
    private bool[,] visitedTable = new bool[50, 50];

    public int solution(int[,] game_board, int[,] table)
    {
        var answer = 0;
        var boardList = GetCellList(game_board, visitedBoard, 1);
        var tableList = GetCellList(table, visitedTable, 0);
        var fillBoardIndex = new HashSet<int>();

        foreach (var tableBlock in tableList)
        {
            var localTableBlock = BlockToLocalSpace(tableBlock);
            var rotatedTableBlock = localTableBlock;
            var isMatched = false;

            for (var i = 0; i < 4; i++)
            {
                if (i > 0)
                    rotatedTableBlock = RotateBlock(rotatedTableBlock);

                for (var boardIndex = 0; boardIndex < boardList.Count; boardIndex++)
                {
                    if (fillBoardIndex.Contains(boardIndex))
                        continue;

                    var boardBlock = boardList[boardIndex];
                    var localBoardBlock = BlockToLocalSpace(boardBlock);

                    if (IsSuccess(rotatedTableBlock, localBoardBlock))
                    {
                        fillBoardIndex.Add(boardIndex);
                        answer += boardBlock.Count;
                        isMatched = true;
                        break;
                    }
                }

                if (isMatched)
                    break;
            }
        }

        return answer;
    }

    private bool IsSuccess(int[,] lv, int[,] rv)
    {
        var canvasSize = lv.GetLength(0);

        if (canvasSize != rv.GetLength(0))
            return false;

        for (var x = 0; x < canvasSize; x++)
        {
            for (var y = 0; y < canvasSize; y++)
            {
                if (lv[x, y] != rv[x, y])
                    return false;
            }
        }

        return true;
    }

    private int[,] BlockToLocalSpace(List<KeyValuePair<int, int>> blockList)
    {
        var minX = int.MaxValue;
        var minY = int.MaxValue;
        var maxX = int.MinValue;
        var maxY = int.MinValue;

        foreach (var block in blockList)
        {
            if (minX >= block.Key)
                minX = block.Key;

            if (minY >= block.Value)
                minY = block.Value;

            if (maxX <= block.Key)
                maxX = block.Key;

            if (maxY <= block.Value)
                maxY = block.Value;
        }

        var width = (maxX - minX);
        var height = (maxY - minY);
        var canvasSize = (height > width ? height : width) + 1;
        var canvas = new int[canvasSize, canvasSize];

        foreach (var block in blockList)
            canvas[block.Key - minX, block.Value - minY] = 1;
        return canvas;
    }

    private int[,] RotateBlock(int[,] canvas)
    {
        var canvasSize = canvas.GetLength(0);

        var rotated = new int[canvasSize, canvasSize];
        var offsetX = canvasSize;
        var offsetY = canvasSize;

        for (var i = 0; i < canvasSize; i++)
        {
            for (var j = 0; j < canvasSize; j++)
            {
                rotated[i, j] = canvas[canvasSize - 1 - j, i];

                if (rotated[i, j] == 1)
                {
                    if (offsetX >= i)
                        offsetX = i;
                    if (offsetY >= j)
                        offsetY = j;
                }
            }   
        }

        var moved = new int[canvasSize, canvasSize];

        for (var i = 0; i < canvasSize; i++)
        {
            for (var j = 0; j < canvasSize; j++)
            {
                if (rotated[i, j] == 0)
                    continue;

                moved[i - offsetX, j - offsetY] = rotated[i, j];
            }
        }

        return moved;
    }

    private List<List<KeyValuePair<int, int>>> GetCellList(int[,] grid, bool[,] visited, int wallValue)
    {
        var list = new List<List<KeyValuePair<int, int>>>();

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                var cell = grid[i, j];

                if (visited[i, j])
                    continue;

                if (cell == wallValue) 
                    continue;

                var steps = new List<KeyValuePair<int, int>>();
                Search(i, j, grid, wallValue, steps, visited);
                list.Add(steps);
            }
        }

        return list;
    }

    private void Search(int x, int y, int[,] grid, int wallValue, List<KeyValuePair<int, int>> steps, bool[,] visited)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
            return;

        if (visited[x, y] || grid[x, y] == wallValue)
            return;

        visited[x, y] = true;
        steps.Add(new KeyValuePair<int, int>(x, y));

        Search(x + 1, y, grid, wallValue, steps, visited);
        Search(x - 1, y, grid, wallValue, steps, visited);
        Search(x, y + 1, grid, wallValue, steps, visited);
        Search(x, y - 1, grid, wallValue, steps, visited);
    }
}