using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034_operator1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 18;
            int b = 6;

            // +
            int c = a + b;
            Console.WriteLine(c);

            // -
            int d = 100 - 10;
            Console.WriteLine("100 - 10 = " + (d));

            // /
            int e = a / b;
            Console.WriteLine(e);

            // a * (b + c), (b + c) -> 1. a * -> 2.
            int f = a * (b + c);
            Console.WriteLine(f);

            // (a + b) % 2, (a + b) -> 1. % 2 -> 2.
            int g = (a + b) % 2;
            Console.WriteLine(g);
        }
    }
}
