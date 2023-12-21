using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 시험 삼아 namespace 바깥에 만들었는데 작동했었음
// delegate void DelegateTest (int a, int b);

namespace _133_delegateDeclare
{
    /// <summary>
    /// <para>delegate로 대리자(타입) 선언</para>
    /// <para>
    ///     두 정수를 파라미터로 받고 반환형은 없는 메서드
    /// </para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    delegate void DelegateTest (int a, int b);

    internal class Program
    {
        /// <summary>
        /// <para>두 정수를 파라미터로 받은 다음 합산하는 메서드</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Sum (int a, int b)
        {
            Console.WriteLine("a + b = " + ( a + b ));
        }

        /// <summary>
        /// <para>델리게이트 선언 방식</para>
        /// </summary>
        private static void Main ()
        {
            //1: 기본 선언
            DelegateTest dt = new DelegateTest(Sum);

            //2: 간략한 선언
            DelegateTest dt2 = Sum;

            //3: 익명 함수 선언
            DelegateTest dt3 = delegate (int a, int b) {
                Console.WriteLine("a + b = " + ( a + b ));
            };

            //4: 람다식 선언
            DelegateTest dt4 = (a, b) => {
                Console.WriteLine("a + b = " + ( a + b ));
            };

            /**
             * 익명함수, 람다식 함수 경우 로컬 함수로 작성하라 권장이 뜸
             * 
             * void dt4 (int a, int b)
            {
                Console.WriteLine("a + b = " + ( a + b ));
            }
             */

            dt(1, 1);
            dt2(2, 2);
            dt3(3, 3);
            dt4(4, 4);

            dt = delegate (int a, int b)
            {
                Console.WriteLine("a - b: " + ( a - b ));
            };

            // 위 로직을 통해서 익명 함수를 참조하도록 바뀜
            dt(2, 1);
        }
    }
}
