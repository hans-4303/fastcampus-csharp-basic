using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _056_iteration_loop_goto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10;  i++)
            {
                if (i == 5)
                {
                    goto AA;
                }
                if (i == 7)
                {
                    goto BB;
                }
                // goto문은 둘 다 실행됐는데, 스코프마다 반복하길 원한 출력문은 무시됐음
                // 이유는 명확히 모르지만 출력문 순서 문제도 아니고, goto문 사용은 피하게 될 것 같음
                Console.WriteLine("{0}번째 스코프", i);
            }

        AA: Console.WriteLine("AA 도착");
        BB: Console.WriteLine("BB 도착");
        }
    }
}
