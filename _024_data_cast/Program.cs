using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _024_data_cast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 100;
            // 작은 데이터 -> 큰 데이터로는 타입 선언 시 암묵적으로 변환해주기 때문에 캐스팅 괄호 생략하고 할당해도 됨
            double dNum = (double)num;
            Console.WriteLine("{0} {1}", num, dNum);

            double dNum2 = 12345678912;
            // 큰 데이터 형을 작은 데이터로 변경 시 주의해야 함: 실행되지만 이후가 문제될 수 있음
            int num2 = (int)dNum2;
            Console.WriteLine("{0} {1}", dNum2, num2);
        }
    }
}
