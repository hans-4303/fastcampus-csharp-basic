using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _051_iteration_nested_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 상위 스코프 for문 실행 후 하위 스코프로 반복해서 들어감
            for (int i = 2; i < 10; i++)
            {
                // 그래서 하위 스코프 for문이 먼저 반복됨
                for (int j = 1; j < 10; j++)
                {
                    // 반복 로직, 상위 스코프와 하위 스코프의 지역 변수 모두 사용
                    Console.WriteLine("{0} * {1} = {2}", i, j, (i * j));
                    // 하위 스코프 지역 변수 따져서 호출
                    if (j == 9) Console.WriteLine();
                }
            }
        }
    }
}
