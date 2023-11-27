using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_data_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // nullable 형식: 해당 데이터 타입 & null 허용하도록 만듦
            //
            // ==
            // Ts
            // let a: number | null = 3.14;
            // let aDash: number | null = null;
            double? a = 3.14;
            char? b = 'a';

            int num = 10;
            // let c: number | null = num;
            int? c = num;

            // let isFlag: boolean | null = null;
            bool? isFlag = null;

            Console.WriteLine("{0}", a);
            Console.WriteLine("{0}", b);
            Console.WriteLine("{0}", c);

            // bool? 출력 시도
            Console.WriteLine("{0}", isFlag);
            // bool?.HasValue 출력 == 값이 없어서 False
            Console.WriteLine("{0}", isFlag.HasValue);

            // bool?.HasValue에 따라 조건문
            if (isFlag.HasValue) {
                Console.WriteLine("{0}", isFlag.Value);
            } else
            {
                Console.WriteLine("isFlag의 값은 없습니다.");
            }

            // int?.HasValue에 따라 조건문
            if (c.HasValue)
            {
                Console.WriteLine("{0}", c.Value);
            }
        }
    }
}
