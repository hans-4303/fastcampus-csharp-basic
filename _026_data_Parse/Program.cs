using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_data_Parse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "100";
            string b = "3.14159332132123";
            string c = "3.14159332132123";

            // 파싱 문법: "데이터 타입" "식별자" = "데이터 타입".Parse("변환할 데이터");
            int parsedA = int.Parse(a);
            float parsedB = float.Parse(b);
            decimal parsedC = decimal.Parse(c);

            // 파싱 후에도 불변성은 지켜지고, 리터럴 접미사가 붙지 않았지만 float와 decimal 변환에 문제 없음
            Console.WriteLine("{0} {1} {2} {3}", a, a.GetType(), parsedA, parsedA.GetType());
            Console.WriteLine("{0} {1} {2} {3}", b, b.GetType(), parsedB, parsedB.GetType());
            Console.WriteLine("{0} {1} {2} {3}", c, c.GetType(), parsedC, parsedC.GetType());
        }
    }
}
