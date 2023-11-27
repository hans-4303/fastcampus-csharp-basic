using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _049_iteration_do_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int num;
            int total = 0;

            Console.Write("0부터 n까지 더해보기");
            num = int.Parse(Console.ReadLine());

            do
            {
                // 트리거 조작에 주의할 것
                // 스코프 안에서 트리거를 충분히 조작하지 않으면 while문이 무한 반복될 수 있음
                total += a++;
                // a가 num보다 커져야 반복이 중지되므로, 스코프 안에서 a를 조작해야 함
            } while (a <= num);

            Console.WriteLine("{0}", total);
        }
    }
}
