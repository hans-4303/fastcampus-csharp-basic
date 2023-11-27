using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _080_array_flex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2차원 가변 배열 초기화:
            // 2차원 배열의 길이 == row는 초기화
            // 2차원 배열 속 요소 배열의 길이 == column은 초기화 X
            int[][] arrNum1 = new int[3][];

            arrNum1[0] = new int[2] { 0, 1 };
            arrNum1[1] = new int[4] { 0, 1, 2, 3 };
            arrNum1[2] = new int[] { 0, 1, 2 };

            Console.WriteLine("=== arrNum1 ===");

            // n차원 배열도 n - 1차원 배열을 읽는다고 지정하면
            // foreach로도 n차원 배열 상태로 다룰 수 있음

            // 단 이 경우 배열을 선형 자료로 읽을 수는 없었음:
            // 각 행의 길이를 명시하지 않아서
            // 차라리 중첩 for문 혹은 foreach로 처리하는 게 좋음
            // 케이스 1.
            foreach(int[] arr in arrNum1)
            {
                foreach (int i in arr) Console.Write(i);
                Console.WriteLine();
            }

            // 케이스 2. 중첩된 for 루프를 사용하여 2차원 배열 선형 자료로 펼치기
            for (int i = 0; i < arrNum1.Length; i++)
            {
                for (int j = 0; j < arrNum1[i].Length; j++)
                {
                    int value = arrNum1[i][j];
                    Console.Write(value);
                }
                Console.WriteLine();
            }

            // 2차원 가변 배열 초기화하는 다른 경우
            // 2차원 배열의 길이 == 행 길이 초기화
            // 2차원 배열의 요소 배열 == 열 배열 초기화
            int[][] arrNum2 = new int[2][]
            {
                // 요소 배열의 길이를 초기화할 필요는 없음
                new int[] { 0, 1},
                // 하지만 요소 배열의 길이를 초기화했다면 꼭 양식을 맞출 것
                // new int[3] { 2, 3, 4, 5 } X
                new int[3] { 2, 3, 4 } // O
            };

            foreach (int[] arr in arrNum2)
            {
                foreach(int i in arr) Console.Write(i);
                Console.WriteLine();
            }
        }
    }
}
