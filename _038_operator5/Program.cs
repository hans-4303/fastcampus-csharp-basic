using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _038_operator5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result;
            int a = 100;
            int b = 1000;

            //  연산자를 이용해 비교하는 걸 반복적으로 하고 있고, 반환 값은 result 변수에 할당
            result = (a == b);
            Console.WriteLine(result);

            result = (a != b);
            Console.WriteLine(result);

            result = (a > b);
            Console.WriteLine(result);

            result = (a < b);
            Console.WriteLine(result);

            result = (a >= b);
            Console.WriteLine(result);

            result = (a <= b);
            Console.WriteLine(result);
        }
    }
}
