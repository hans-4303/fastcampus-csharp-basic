using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _065_func5
{
    internal class Program
    {
        // 한 함수가 파라미터를 아주 많이 갖게 할 수도 있음
        // 대개 너무 많은 파라미터를 가진다면 좋은 함수가 아닐 가능성이 있음
        // 작용과 책임이 명확한 지, 분할 할 수 없는지 등 체크해볼 것
        static bool JustExample(int a, bool b, float c, decimal d)
        {
            return false;
        }

        // int x, y 받고 로직 실행한 뒤 bool 반환 값 리턴하는 함수
        // (실행하는 로직이 어떤 타입이나 반환에 얽매이지는 않음)
        static bool PrintDot(int x, int y)
        {
            // x나 y가 0보다 작거나 같다면 도형 그리기가 안 되니 false 반환하고 함수 종료
            if(x <= 0 || y <= 0) return false;
            // 함수 실행 가능할 때
            // i == x일 때 for문 종료하고 진행 중일 때는 하위 스코프 진입
            for (int i = 0; i < x; i++)
            {
                // j == y일 때 for문 종료하고 스코프 내 로직 반복
                for (int j = 0; j < y; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            // 실행 성공 시 true 반환
            return true;
        }
        static void Main(string[] args)
        {
            // 인수 타입과 리턴 타입이 다를 수 있음: 자연스럽게 사용하기
            bool printVal1 = PrintDot(5, 7);
            if (printVal1 == true)
            {
                Console.WriteLine("result: {0}", printVal1);
            }
            else Console.WriteLine("result: {0}", printVal1);

            bool printVal2 = PrintDot(5, 0);
            if (printVal2 == true)
            {
                Console.WriteLine("result: {0}", printVal2);
            }
            else Console.WriteLine("result: {0}", printVal2);
        }
    }
}
