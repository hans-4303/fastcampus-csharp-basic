using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _061_func1
{
    internal class Program
    {
        // static: static void Main(string[] args) 메서드 안에 사용되어야 하기 때문에 붙은 접근 지정자
        static void InitTitle()
        {
            Console.WriteLine("짝수 & 홀수 보여주기(0 ~ 100)");
        }

        static void PrintEven()
        {
            for(int i = 0; i <= 100; i++)
            {
                if (i % 2 == 0) Console.Write(" 짝수: {0} ", i);
                if (i % 10 == 0 && i != 0) Console.WriteLine();
            }
        }
        static void PrintOdd()
        { 
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0) Console.Write(" 홀수: {0} ", i);
                if ((i % 10) == 1 && (i != 1)) Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // 함수로 로직을 분리했음
            // 물론 함수 내용을 메인 메서드에 작성해도 차이점 없이 돌아가겠지만
            // 메인 메서드의 가독성이 좋아지고 유지 보수에 좋아질 것

            // 리턴 형이 없는 함수를 할당하기 부적절
            // object abc = InitTitle();

            InitTitle();
            PrintEven();
            PrintOdd();
        }
    }
}
