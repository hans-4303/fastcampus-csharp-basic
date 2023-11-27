using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _069_func_default_params
{
    internal class Program
    {
        static void PrintValue1(int a, int b, int c = 100, int d = 0)
        {
            Console.WriteLine("{0} {1} {2} {3}", a, b, c, d);
        }

        static void PrintValue2(int? a, int b, int c = 100, int d = 0)
        {
            if (a.HasValue) Console.WriteLine("{0} {1} {2} {3}", a.Value, b, c, d);
            else Console.WriteLine("{0} {1} {2}", b, c, d);
            
            // HasValue 조건과 분기 없이 a.Value 접근하는 게 오히려 더 위험한 경우
            // 런타임에서 예외 발생할 수 있음
            // Console.WriteLine("{0} {1} {2} {3}", a.Value, b, c, d);
        }

        static void PrintValue3(int a, int b, int c = 100, int d = 0)
        {
            // 디폴트 파라미터와 값이 같음
            // 디폴트 파라미터와 값을 같게 넣은 경우에도 조건에 걸리고 리턴됨
            if (c == 100 && d == 0)
            {
                Console.WriteLine("c d 값 둘 제외하고 {0} {1}", a, b);
                // 경우에 대해 리턴문을 달지 않으면 동시에 다른 분기까지 조회해버릴 수 있으니 주의
                return;
            }
            else if (c == 100)
            {
                Console.WriteLine("c 값 제외하고 {0} {1} {2}", a, b, d);
                return;
            }
            else if (d == 0)
            {
                Console.WriteLine("d 값 제외하고 {0} {1} {2}", a, b, c);
                return;
            }
            else
            {
                Console.WriteLine("모든 값이 출력 {0} {1} {2} {3}", a, b, c, d);
                return;
            }
        }

        // nullable 데이터를 활용하여 디폴트 파라미터를 만듦
        // 따라서 호출 시에도 디폴트 파라미터에 해당하는 인수는 생략할 수 있음
        static void PrintValue4(int a, int b, int c, int? d = null)
        {
            if (d.HasValue) Console.WriteLine("{0} {1} {2} {3}", a, b, c, d.Value);
            else Console.WriteLine("{0} {1} {2}", a, b, c);
        }

        static void Main(string[] args)
        {
            // 함수 호출
            PrintValue3(1, 2, 3, 4);
            // 일부러 디폴트 파라미터와 값을 맞추고 생략되는지 체크
            PrintValue3(4, 5, 100, 4);
            // 파라미터를 생략해도 디폴트 파라미터를 통해 작동 가능
            // d == 0 이며 생략하도록 분기 잡음
            PrintValue3(100, 2, 1);
            // 디폴트 파라미터에 의해 c == 100, d == 0이며 생략하도록 분기 잡음
            PrintValue3(300, 300);

            Console.WriteLine("");

            // 디폴트 파라미터가 nullable이고 null로 초기화 후 분기
            PrintValue4(1, 2, 3);
            // 파라미터를 다 채웠을 때도 잘 작동함
            PrintValue4(100, 200, 300, 400);
        }
    }
}
