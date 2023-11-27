using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _084_array_basic_func
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열 선언
            int[] array = new int[3];
            // 초기화를 Array.Clear 메서드로 처리할 수 있음
            Array.Clear(array, 0, array.Length);
            // 배열 요소 대입을 배열의 길이까지
            for(int i = 0; i < array.Length; i++) { array[i] = i; }

            Console.WriteLine("\n-------------------------");

            // 배열 선언
            int[,] multyTwoArray = new int[3, 2];
            // 2차원 배열의 길이: 배열의 전체 요소를 취급하므로 행 3 * 열 2 == 6 출력
            Console.WriteLine(multyTwoArray.Length);
            Console.WriteLine();
            Array.Clear(multyTwoArray, 0, multyTwoArray.Length);

            // GetLength("차원")은 내림차순으로써 해당 차원의 요소 길이를 받음
            // multyTwoArray.GetLength(0) == 3
            for (int i = 0; i < multyTwoArray.GetLength(0); i++)
            {
                // multyTwoArray.GetLength(1) == 2
                for (int j = 0; j < multyTwoArray.GetLength(1); j++)
                {
                    Console.Write(multyTwoArray[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("\n-------------------------");

            // 배열 선언과 초기화
            int[,,] multyThreeArray = new int[,,]
            {
                { 
                    { 0, 1 }, 
                    { 2, 3 }, 
                    { 3, 4 } 
                },
                { 
                    { 4, 5 }, 
                    { 5, 6 }, 
                    { 6, 7 }
                },
                { 
                    { 7, 8 }, 
                    { 8, 9 },
                    { 9, 10 }
                },
                { 
                    { 10, 11 },
                    { 11, 12 },
                    { 12, 13 }
                },
            };

            // 다차원 배열 길이는 최대 차원 길이 * 다음 차원의 행 *  열
            // multyThreeArray.Length == 4 * 
            Console.WriteLine(multyThreeArray.Length);
            Console.WriteLine();

            for (int i = 0; i < multyThreeArray.GetLength(0); i++ )
            {
                for(int j = 0; j < multyThreeArray.GetLength(1); j++)
                {
                    for (int k = 0; k < multyThreeArray.GetLength(2); k++) Console.Write(multyThreeArray[i, j, k]);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
