using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _064_func4
{
    internal class Program
    {
        // nullable 파라미터를 가지는 함수
        static int TestingFunc(int x, int y, int? z)
        {
            // nullable 파라미터를 받을 로컬 변수
            int valZ;
            // nullable 파라미터 값이 있다면
            if (z.HasValue)
            {
                // 로컬 변수에 대입하고 합산
                valZ = z.Value;
                return x + y + valZ;

            }
            // nullable 파라미터 값이 없다면
            else
            {
                // 있는 파라미터만 합산
                return x + y;
            }
        }

        static void Main(string[] args)
        {
            // 함수 호출 시 (1, 2, null)은 가능함
            // 단 (1, 2)는 불가
            int testVal1 = TestingFunc(1, 2, null);

            // 불가: nullable 파라미터 자리가 아닌데 null 선언해서 
            // int failVal = TestingFunc(null, 1, 2);

            // nullable 파라미터에 값 전달한 경우
            int testVal2 = TestingFunc(4, 5, 6);

            Console.WriteLine(testVal1);
            Console.WriteLine(testVal2);
        }
    }
}
