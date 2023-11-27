using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _050_iteration_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                total += i;
                // 스코프에 명시하지 않았지만 i는 반복해서 커지고 있음(적어놓은 i++)
            }

            Console.WriteLine(total);
        }
    }
}
