using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _063_func3
{
    internal class Program
    {
        // 파라미터로 들어오는 값이 있으며 반환할 데이터를 가짐
        static int Square(int i)
        {
            // 파라미터를 제곱해서 반환할 것
            return i * i;
        }

        static void Main(string[] args)
        {
            // 데이터 선언
            int a = 2;
            int b = 4;

            // 함수 호출과 반환 값 대입
            // 변수를 대입해도 스택 영역 값 2가 들어가기 때문에 작동
            int resultA = Square(a);
            Console.WriteLine(resultA);
            
            int resultB = Square(b);
            Console.WriteLine(resultB);

            // 변수가 아니라 인수를 6으로 넘겨도 작동:
            // 어차피 파라미터 타입은 맞기 때문에
            int resultC = Square(6);
            Console.WriteLine(resultC);

            // 함수의 반환 값을 인수로 넣고, 사칙 연산을 해도 작동
            // 역시 파라미터 타입은 맞기 때문에
            int resultD = Square(resultA * 3);
            Console.WriteLine(resultD);
        }
    }
}
