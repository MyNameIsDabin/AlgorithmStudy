using System;
using System.Linq;

namespace AlgorithmStudy.JongmanBook.Problems
{
    // 보글 게임, 난이도: 하
    public class Boggle
    {
        public static char[][] Board = new[]
        {
            new[] { 'N', 'N', 'N', 'N', 'S' },
            new[] { 'N', 'E', 'E', 'E', 'S' },
            new[] { 'N', 'E', 'Y', 'E', 'S' },
            new[] { 'N', 'E', 'E', 'E', 'S' },
            new[] { 'N', 'N', 'N', 'N', 'N' }
        };

        // 위에서부터 시계방향으로 검사하기 위한 방향 배열
        private int[] xDirections = new[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        private int[] yDirections = new[] { 1, 1, 0, -1, -1, -1, 0, 1 };

        public bool HasWord(char[][] board, int y, int x, string word)
        {
            var chars = word.ToCharArray();
            var firstCharacter = chars[0];

            if (board[y][x] != firstCharacter)
                return false;

            if (chars.Length == 1
                && board[y][x] == firstCharacter)
                return true;

            for (var i = 0; i < yDirections.Length; i++)
            {
                for (var j = 0; j < xDirections.Length; j++)
                {
                    var yDir = yDirections[i];
                    var xDir = xDirections[j];
                    var nextWord = new string(chars.Skip(1).ToArray());
                    
                     if (HasWord(board, y + yDir, x + xDir, nextWord))
                        return true;
                }
            }

            return true;
        }

        public static void RunTest()
        {
            var solution = new Boggle();
            var hasWord = false;
            var word = "YES";

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    hasWord = solution.HasWord(Board, i, j, word);

                    if (hasWord)
                        break;
                }
                
                if (hasWord)
                    break;
            }

            Console.WriteLine($"'{word}' is in board : {hasWord}");
        }
    }
}