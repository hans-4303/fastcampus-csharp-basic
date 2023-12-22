using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142_Action
{
    internal class Program
    {
        /// <summary>
        /// <para>Action에 맞춘 메서드, 리턴형 없고 파라미터 없이 aFunc와 매칭</para>
        /// </summary>
        static void CallAction ()
        {
            Console.WriteLine("CallAction");
        }

        /// <summary>
        /// <para>Action: delegate의 한 형태</para>
        /// <para>
        ///     리턴 없을 때 사용 가능,
        ///     파라미터는 넣어도 되고 안 넣어도 되지만 제네릭으로 넣어주면
        ///     컴파일 시 타입을 따져주며 람다식 작성 때도 적용됨
        /// </para>
        /// </summary>
        private static void Main ()
        {
            Action aFunc;
            Action<int> aFunc2;
            Action<float, int> aFunc3;

            aFunc = CallAction;
            aFunc2 = (num) => Console.WriteLine("num:" + num);
            aFunc3 = (a, b) => {
                float result = b / a;
                Console.WriteLine("a: " + a + " b:" + b + " result: " + result);
            };

            aFunc();
            aFunc2(100);
            aFunc3(6.0f, 10);
        }
    }
}
