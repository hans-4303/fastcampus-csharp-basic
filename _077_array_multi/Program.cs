using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _077_array_multi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] twoDimensionalArray = new int[2, 3];

            int value = 1;
            for (int x = 0; x < 2; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    twoDimensionalArray[x, y] = value++;
                }
            }

            Console.WriteLine("이차원 배열:");
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(twoDimensionalArray[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
