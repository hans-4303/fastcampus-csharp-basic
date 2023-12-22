using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _143_Func
{
    internal class Program
    {
        /// <summary>
        /// <para>Func에 맞춘 메서드, 리턴 형 있을 때 사용 가능하고 aFunc와 매칭</para>
        /// </summary>
        /// <returns>Func는 리턴 값을 가짐</returns>
        static int CallFunc ()
        {
            return 100;
        }

        /// <summary>
        /// <para>Func: delegate의 한 형태</para>
        /// <para>
        ///     리턴 있을 때 사용 가능, 마지막 제네릭은 무조건 리턴 값 타입이 됨,
        ///     파라미터는 넣어도 되고 안 넣어도 됨.
        ///     파라미터와 리턴 모두 컴파일 시 타입을 따져주며 람다식 작성 때도 적용됨
        /// </para>
        /// </summary>
        private static void Main ()
        {
            Func<int> aFunc;
            Func<int, float> aFunc2;
            Func<int, int, int> aFunc3;

            aFunc = CallFunc;
            aFunc2 = (int a) => { return (float) ( a / 2.0f ); };
            aFunc3 = (a, b) =>  a + b ;

            Console.WriteLine("aFunc: " + aFunc());
            Console.WriteLine("aFunc2: " + aFunc2(10));
            Console.WriteLine("aFunc3: " + aFunc3(100, 100));
        }
    }
}
