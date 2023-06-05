using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmStudy.Programmers.Basic
{
    /*
     *  순열이란 원소들의 모든 가능한 배열
     *  예를 들어, "ABC"라는 문자열이 주어진 경우 가능한 모든 순열은 "ABC", "ACB", "BAC", "BCA", "CBA", "CAB"
     *  (위는 순서가 의미가 있는 경우.. 순서가 의미가 없다면, ABC 와 BAC, CBA 는 같다) 
     */
    
    // 순열 재귀 구현
    public class PermutationRecursiveCall
    {
        public List<string> GeneratePermutations(string input)
        {
            var permutations = new List<string>();
            var arr = input.ToCharArray();

            Permute(arr, 0, arr.Length - 1, permutations);
            
            return permutations;
        }
        
        public void Permute(char[] arr, int start, int end, List<string> permutations)
        {
            if (start == end) // 기저 조건 : 순열이 완성된 경우
            {
                permutations.Add(new string(arr));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref arr[start], ref arr[i]); // 선택 : 현재 위치(start)와 다른 위치(i)의 문자 교환
                    Permute(arr, start + 1, end, permutations); // 재귀 호출
                    Swap(ref arr[start], ref arr[i]); // 백 트래킹 (이전 상태로 돌아가기 위해 문자 교환을 원래대로 되돌림)
                }
            }
        }

        private void Swap(ref char a, ref char b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static void RunTest()
        {
            var solution = new PermutationRecursiveCall();

            var permutations = solution.GeneratePermutations("ABC");
            
            Console.WriteLine(permutations.Aggregate((lv, rv) => lv + $"\n{rv}"));
        }
    }
}