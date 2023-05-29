using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmStudy.JongmanBook.Solving
{
    // 1권 146p 재귀 호출과 완전 탐색
    public class RecursiveCall
    {
        private List<int> picked = new List<int>();
        
        // 중복 없이 순서대로 0번 부터 순서대로 나열된 숫자 카드 (cards)를 chance 만큼 뽑았을때 나올 수 있는 모든 경우의 수 출력 
        public void RecursivePick(List<int> picked, int chance = 2, int cards = 3)
        {
            if (chance == 0)
            {
                Console.WriteLine(string.Join(", ", picked.Select(_ => _.ToString()).ToArray()));
                return;
            }

            var begin = picked.Count == 0 ? 0 : picked.Last() + 1;
            
            for (var i = begin; i < cards; i++)
            {
                picked.Add(i);
                RecursivePick(picked, chance - 1, cards);
                picked.RemoveAt(picked.Count - 1);
            }
        }
    }
}