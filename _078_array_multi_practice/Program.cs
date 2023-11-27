using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _078_array_multi_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arrNum = new int[3, 2];

            arrNum[0, 0] = 1;
            arrNum[0, 1] = 2;

            arrNum[1, 0] = 3;
            arrNum[1, 1] = 4;

            arrNum[2, 0] = 5;
            arrNum[2, 1] = 6;

            // foreach문이 2차원 배열이라도 각 요소를 잘 가져오는 이유?
            foreach (int i in arrNum)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // 중첩 for문을 통해 배열 인덱스를 정확히 짚고 가져오기
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 2; y++) { Console.Write(arrNum[x, y]); }
                Console.WriteLine();
            }
        }
    }
}
