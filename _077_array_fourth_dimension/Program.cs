using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _079_array_fourth_dimension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2x3x4x5 크기의 4차원 배열 선언
            int[,,,] fourDimensionalArray = new int[2, 3, 4, 5];

            // 각 요소에 값 할당 (임의로 1부터 채워 넣음)
            int value = 1;
            for (int w = 0; w < 2; w++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            fourDimensionalArray[w, x, y, z] = value++;
                        }
                    }
                }
            }

            // 표 형식으로 출력
            Console.WriteLine("4차원 배열:");
            for (int w = 0; w < 2; w++)
            {
                Console.WriteLine($"w = {w}");
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int z = 0; z < 5; z++)
                        {
                            Console.Write($"{fourDimensionalArray[w, x, y, z],-4} ");
                        }
                        Console.WriteLine(); // 다음 행으로 이동
                    }
                    Console.WriteLine("X"); // 각 차원 사이에 빈 줄 추가
                }
                Console.WriteLine(); // 각 차원 사이에 빈 줄 추가
            }
        }
    }
}
