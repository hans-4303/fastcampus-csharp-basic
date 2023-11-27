using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _052_iteration_while_true
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                count++;
                if (count == 10) break;
            }
            Console.WriteLine("반복문 탈출 성공?");
        }
    }
}
