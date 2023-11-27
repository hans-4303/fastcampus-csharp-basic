using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _035_operator2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 3;
            float c = 123.45f, d = 3.1456f;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);

            Console.WriteLine("\n정수 계산");
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a % b);

            Console.WriteLine("\n실수 계산");
            Console.WriteLine(c + d);
            Console.WriteLine(c - d);
            Console.WriteLine(c * d);
            Console.WriteLine(c / d);
            Console.WriteLine(c % d);
        }
    }
}
