using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            string b = "AAA";
            float c = 0.123f;
            char d = 'A';

            Console.WriteLine("{0} {1}", a, a.GetType());
            Console.WriteLine("{0} {1}", b, b.GetType());
            Console.WriteLine("{0} {1}", c, c.GetType());
            Console.WriteLine("{0} {1}", d, d.GetType());
        }
    }
}
