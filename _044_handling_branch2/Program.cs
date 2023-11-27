using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _044_handling_branch2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("정수를 입력하세요: ");
            string strToNum = Console.ReadLine();
            int a = Convert.ToInt32(strToNum);

            if(a > 0)
            {
                Console.WriteLine("양수");
            }
            else if(a < 0)
            {
                Console.WriteLine("음수");
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
