using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _067_func7
{
    internal class Program
    {
        // 스왑 시도 함수, int 파라미터 두 개 받음
        static public void ValueSwap(int a, int b)
        {
            // 로컬 변수 만들고 a 대입, 로컬 변수 == a
            int temp = a;
            // 파라미터 a에 b 대입 시도 -> 된다면 a는 b 값으로 바뀌어야 함
            a = b;
            // b에 로컬 변수 == a 대입 시도 -> 된다면 b는 a 값으로 바뀌어야 함
            b = temp;

            Console.WriteLine("try to swap value");
            Console.WriteLine("{0} {1}", a, b);
        }

        // 함수 로직은 똑같고 파라미터 타입에 ref가 추가로 붙음
        static public void RefSwap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

            Console.WriteLine("actually swaped value");
            Console.WriteLine("{0} {1}", a, b);
        }

        static void Main(string[] args)
        {
            // 데이터 선언 및 초기화
            int num1 = 100;
            int num2 = -100;

            // 함수 내부에서는 파라미터끼리 값 전환됐지만 메인 함수 스코프에 영향 있는 건 아님
            ValueSwap(num1, num2);
            Console.WriteLine("{0} {1}", num1, num2);

            // 함수 내부에서도 파라미터끼리 값 전환됐고 메인 함수 스코프에도 영향을 줬음
            // 인수를 줄 때도 ref라고 선언해야 함
            RefSwap(ref num1, ref num2);
            Console.WriteLine("{0} {1}", num1, num2);
        }
    }
}
