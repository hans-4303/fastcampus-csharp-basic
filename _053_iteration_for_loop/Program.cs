using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053_iteration_for_loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int trigger = 0;
            for(; ; )
            {
                trigger++;
                if (trigger == 10) break;
            }
            Console.WriteLine("이번에도 탈출 성공?");
        }
    }
}
