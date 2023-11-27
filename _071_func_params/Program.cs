using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071_func_params
{
    internal class Program
    {
        // 배열을 반복문으로 순회해서
        static int Total(params int[] values)
        {
            int total = 0;
            for(int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }
            return total;
        }

        // 배열 메서드를 쓰는 케이스
        static int AdvancedTotal(params int[] values) { return values.Sum(x => x);}

        static void Main(string[] args)
        {
            Console.WriteLine(AdvancedTotal(200, 5, 3, 1, 100));
            Console.WriteLine(Total(1, 2, 3, 4, 5));
            Console.WriteLine(AdvancedTotal(10, 1000));
        }
    }
}
