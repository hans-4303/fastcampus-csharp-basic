using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _068_func_out
{
    internal class Program
    {
        // 함수의 파라미터 타입 앞에 out 키워드 명시할 것
        static void OutNum(out int outNum) { outNum = 100; }
        static void RefNum(ref int refNum) { refNum = -100; }

        static void Main(string[] args)
        {
            // 초기화 하지 않은 변수들
            int a;
            int b;

            // out 키워드를 통해 초기화 하지 않은 변수를 레퍼런스 형 인수로 넘길 수 있음
            OutNum(out a);
            // 인수로 넘김 -> 함수 실행 -> 현재 스코프 변수 바꾸기 가능
            Console.WriteLine(a);

            // 초기화 하지 않은 변수를 레퍼런스 형 인수로 넘길 수는 없음
            b = 0;
            RefNum(ref b);
            // 초기화 한 변수를 레퍼런스 형 인수로 넘김 -> 함수 실행 -> 현재 스코프 변수 바꾸기 가능함
            Console.WriteLine(b);
        }
    }
}
