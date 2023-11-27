using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027_data_Convert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "100";
            string b = "3.14159332132123";
            string c = "3.14159332132123";

            // 컨버팅 문법: "데이터 타입" "식별자" = Convert.To***("컨버팅할 데이터")
            // ***는 변환할 데이터에 따라 다르고, CTS를 따름:
            // int -> ToInt32, float -> ToSingle, ...
            int convertedA = Convert.ToInt32(a);
            float convertedB = Convert.ToSingle(b);
            decimal convertedC = Convert.ToDecimal(c);

            // 컨버팅 후에도 불변성은 지켜지고, 리터럴 접미사가 붙지 않았지만 float와 decimal 변환에 문제 없음
            Console.WriteLine("{0} {1} {2} {3}", a, a.GetType(), convertedA, convertedA.GetType());
            Console.WriteLine("{0} {1} {2} {3}", b, b.GetType(), convertedB, convertedB.GetType());
            Console.WriteLine("{0} {1} {2} {3}", c, c.GetType(), convertedC, convertedC.GetType());
        }
    }
}
