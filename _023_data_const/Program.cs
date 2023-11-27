using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _023_data_const
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 100;
            const int MIN = 0;

            Console.WriteLine("{0} {1}", MIN, MAX);

            // 불가, 상수로 선언되었기 때문에
            // MAX = 1000;

            // 하지만 상수 선언과 초기화에서 바꾸면 되니까

            // 하지만 배열이나 컬렉션에서는 달라질 수도 있을까?
        }
    }
}
