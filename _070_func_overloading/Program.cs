using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _070_func_overloading
{
    internal class Program
    {
        static int Add(int x, int y) { return x + y; }
        static int Add(int x, int y, int z) { return x + y + z; }
        static double Add(double x, double y) { return x + y; }
        // 디폴트 파라미터를 선언했지만 인수 3개 짜리 함수와 모호성 생길 수 있음
        // 4번째 인수를 생략하면
        static int Add(int v, int x, int y, int z = 5) { return (v + x + y + z) * 2 ; }

        static void Main(string[] args)
        {
            // int 인수 두 개
            Console.WriteLine(Add(10, 100));
            // int 인수 세 개(디폴트 파라미터를 선언한 인수 네 개짜리가 아님)
            Console.WriteLine(Add(10, 100, 1000));
            // int 인수 네 개(네 번째 인수 생략하면 인수 세 개 함수가 호출됨
            // 디폴트 파라미터가 큰 의미 없어짐
            Console.WriteLine(Add(10, 100, 1000, 10000));
            // double 인수 두 개
            Console.WriteLine(Add(10.3, 1.78));
        }
    }
}
