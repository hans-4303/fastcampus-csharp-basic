using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _042_operator_null
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // nullable 타입으로 null 할당된 변수 있음
            int? a = null;
            int b = 10;
            int? c = null;
            int d = 100;
            int result;

            // "식별자" = "null일 수 있는 값(nullable 형식)" ?? "호출될 수 있는 실제 값"
            result = a ?? b;
            Console.WriteLine(result);

            // null ?? null 경우는 컴파일 단계에서 잡힘, 문제 없음
            // result = a ?? c;
            // Console.WriteLine(result);

            result = a ?? c ?? d;
            Console.WriteLine(result);

            // 중간에 a 값 할당한다면 ?? 연산자는 무시되고 할당된 채로 출력
            a = 12345;
            result = a ?? c ?? d;
            Console.WriteLine(result);
        }
    }
}
