using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _036_operator3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            int num3 = 30;
            int num4 = 40;

            Console.WriteLine(num1);
            Console.WriteLine(++num1);
            Console.WriteLine(num1++);
            Console.WriteLine(num1);

            Console.WriteLine("\n");
            Console.WriteLine(num2);
            Console.WriteLine(++num2);
            Console.WriteLine(num2++);
            Console.WriteLine(num2);

            Console.WriteLine("\n");
            Console.WriteLine(num3);
            Console.WriteLine(--num3);
            Console.WriteLine(num3--);
            Console.WriteLine(num3);

            Console.WriteLine("\n");
            Console.WriteLine(num4);
            Console.WriteLine(--num4);
            Console.WriteLine(num4--);
            Console.WriteLine(num4);
        }
    }
}
