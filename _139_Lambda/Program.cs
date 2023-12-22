using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _139_Lambda
{
    /// <summary>
    /// <para>예제 대로 만든 delegate들: 당연히 파라미터 타입이 처음부터 정해져있다</para>
    /// </summary>
    /// <param name="str"></param>
    internal delegate void dPrint (string str);
    internal delegate int dAdd (int a);

    /// <summary>
    /// <para>delegate와 람다식 활용</para>
    /// <para>
    ///     물론 메서드들은 파라미터와 리턴형이 맞춰져 있음,
    ///     타입이 맞춰져있기 때문에 대부분 컴파일 단계에서 잡힐 수 있으니 넘어감.
    /// </para>
    /// </summary>
    internal class Program
    {
        static public void CallPrint (string str)
        {
            Console.WriteLine(str);
        }

        static public int CallAdd (int a)
        {
            return a + a;
        }

        /// <summary>
        /// <para>람다식과 클로저를 사용한 팩토리 메서드</para>
        /// <para>1. createAdder Func가 파라미터로 int를 받음</para>
        /// <para>2. createAdder Func가 파라미터와 리턴이 int인 Func를 반환할 수 있다 정의함</para>
        /// <para>3. createAdder를 호출 시에는 a 파라미터를 받음</para>
        /// <para>4. 내부에서는 b를 받는 Func가 생겨서 호출되고 a + b 합한 값을 리턴함</para>
        /// <para>5. 외부에서 받아온 a를 람다식 내부에서 다뤘기 때문에 a와 b 모두를 인지했음</para>
        /// </summary>
        static readonly Func<int, Func<int, int>> createAdder = a => {
            return b => a + b;
        };

        /// <summary>
        /// <para>1. 델리게이트 변수를 생성하고 메서드를 전달한 뒤 호출</para>
        /// <para>2. 델리게이트 변수에 람다식으로 함수를 전달한 뒤 호출</para>
        /// <para>
        ///     메서드를 전달한 것과 새 람다식으로 함수를 전달한 결과가 모두 같음,
        ///     그런데 어떤 상황에서 어떤 방식을 선택하느냐 문제가 있고 차이점도 분명 존재함
        /// </para>
        /// <para>
        ///     a. 람다식(화살표 함수)는 간결한 코드 작성에 도움,
        ///     간단한 로직 경우 델리게이트에 람다식을 사용하는 걸 해볼만 함
        /// </para>
        /// <para>
        ///     b. 람다식으로 메서드를 전달할 수도 있지만 대체로 일회성 로직을 간결히 처리할 때 유용,
        ///     다른 곳에서 재사용하려면 메서드로 정의하는 게 좋을 수 있음.
        /// </para>
        /// <para>
        ///     c. 람다식은 정의된 스코프 안에서 외부 변수를 참조하고 변경할 수 있음(클로저 개념),
        ///     클로저는 외부 변수의 레퍼런스를 유지하면서 사용되므로 클로저를 정의한 시점에서
        ///     외부 변수 상태를 기억했다가 스코프 안에서 변경하고 외부 상태에 다시 반영해줄 수 있음.
        /// </para>
        /// <para>
        ///     d. 메서드의 ref, out 키워드와 클로저가 유사한가 생각했었음,
        ///     클로저는 익명 함수나 람다식에서 외부 변수 상태 유지와 변경에 주로 사용됨.
        ///     ref 및 out 키워드를 사용하면 해당 변수 참조가 직접 전달되고
        ///     변수 수정 시 해당 변경이 반영됨. 수정과 결과 도출에 사용됨.
        ///     ref와 out 키워드끼리는 변수를 초기화 해야한다, 초기화 하지 않아도 된다 차이는 있음.
        /// </para>
        /// <para>3. 클로저 활용처</para>
        /// <para>
        ///     a. 내부 변수가 보존됨:
        ///     람다식 메서드나 함수 내부에서 지역 변수를 선언 시 해당 변수가 계속 유지됨,
        ///     함수가 종료되더라도 변수 값이 보존되어 계속 사용 가능함.
        /// </para>
        /// <para>
        ///     b. 비동기 프로그래밍:
        ///     클로저를 사용하면 비동기 작업에서 외부 변수를 공유하거나 수정할 수 있음.
        /// </para>
        /// <para>
        ///     c. 이벤트 핸들러:
        ///     클로저를 사용해서 이벤트 핸들러에서 외부 변수를 캡처하고 상태 유지 가능,
        ///     UI 프로그래밍에도 자주 나올 개념
        /// </para>
        /// <para>
        ///     d. LINQ:
        ///     LINQ 쿼리에서 클로저를 사용하여 외부 변수를 참조할 수 있음
        ///     예) var result = numbers.Where(n => n > threshold: 외부 변수);
        /// </para>
        /// <para>
        ///     e. 팩토리 메서드:
        ///     클로저를 사용하여 동적으로 메서드를 생성할 수 있음
        /// </para>
        /// </summary>
        private static void Main ()
        {
            dPrint dp = CallPrint;
            dp("CallPrint");

            dp = (str) => { Console.WriteLine(str); };
            dp("Ramdba");

            // dp = (int) => { Console.WriteLine(int); };
            // dp(3);

            dAdd da = CallAdd;
            Console.WriteLine("CallAdd: " + da(10));

            da = (a) => { return a + a; };
            Console.WriteLine("Ramdba: " + da(10));

            var add11 = createAdder(11);
            Console.WriteLine(add11(5));
        }
    }
}
