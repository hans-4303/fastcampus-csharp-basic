using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _037_operator4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 100;

            a %= b;
            // == a = a % b;
            Console.WriteLine(a);

            a += 10;
            // == a = a + 10;
            Console.WriteLine(a);

            a -= b;
            // == a = a - b;
            Console.WriteLine(a);

            a *= b;
            // == a = a * b;
            Console.WriteLine(a);

            a /= b;
            // == a = a / b;
            Console.WriteLine(a);
        }
    }
}
