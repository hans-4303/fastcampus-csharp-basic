using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _039_operator6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result;
            int a = 100;
            int b = 1000;

            bool c = false;
            
            // 비교를 위해 만들어봤지만 실행 불가
            // int? d = null;

            // &&, 피연산자 둘 모두가 true인 경우
            result = (a == 100) && (b == 1000);
            Console.WriteLine(result);

            // &&, 피연산자 중 하나가 false인 경우
            result = (a == 100) && (b == 2000);
            Console.WriteLine(result);

            // ||, 피연산자 중 둘 모두가 true인 경우
            result = (a == 100) || (b == 1000);
            Console.WriteLine(result);

            // ||, 피연산자 중 하나라도 true인 경우
            result = (a == 200) || (b == 1000);
            Console.WriteLine(result);

            // ||, 피연산자 모두 false인 경우
            result = (a == 200) || (b == 2000);
            Console.WriteLine(result);

            // false -> !false == true
            result = false;
            result = !result;
            Console.WriteLine(result);

            // c = false를 대입, 
            if (!c)
            {
                Console.WriteLine("c: {0}", c);
            }

            // 실행 불가: nullable은 !으로 실행해볼 수 없음
            // if(!d)
            // {
            //    Console.WriteLine("d: {0}", d);
            // }
        }
    }
}
