using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _048_iteration_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int totalA = 0;
            int totalB = 0;

            while (a <= 10 || b <= 10)
            {
                // 복합 대입으로 줄여주었음
                // 전치와 후치 연산으로 반복 조건(트리거) 값이 변하고 있으므로 while문이 끝날 수 있음
                totalA += a++;
                totalB += ++b;
            }

            Console.WriteLine("a: {0}", totalA);
            Console.Write("b: {0}", totalB);
        }
    }
}
