using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _141_FuncLambda
{
    /// <summary>
    /// <para>간단한 delegate 메서드들</para>
    /// </summary>
    /// <param name="str"></param>
    internal delegate void dPrint (string str);
    internal delegate void dFunc ();

    internal class Program
    {
        /// <summary>
        /// <para>dPrint와 타입 맞춘 메서드</para>
        /// </summary>
        /// <param name="str"></param>
        static public void CallPrint (string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// <para>dFunc와 타입 맞춘 메서드</para>
        /// </summary>
        /// <param name="PrintFunc"></param>
        /// <param name="msg"></param>
        static public void CallBackFunc (dPrint PrintFunc, string msg)
        {
            /**
             * ==
             * if(null != dp) dp("CallBackFunc: " + msg);
             */
            PrintFunc?.Invoke("CallBackFunc: " + msg);
        }

        /// <summary>
        /// <para>메서드와 delegate, 람다식 비교</para>
        /// <para>1. 단순히 메서드를 연결해도 작동할 수는 있음</para>
        /// <para>2. 메서드를 불러오지 않아도 delegate를 통해서 익명함수를 작성하고 타입을 맞출 수도 있음</para>
        /// <para>3. 람다식을 정확하게 푼다면 (T param) => { 로직... }, ... 같이 됨</para>
        /// <para>4. 하지만 간단하게 풀어쓴다면 (param) => 로직... 같이 됨 </para>
        /// <para>
        ///     메서드 호출과 인수가 의아했는데 어느 정도 이해함,
        ///     a. 먼저 CallBackFunc가 호출되어 함수와 문자열을 받음.
        ///     b. CallBackFunc 내부에서는 인수로 받아온 함수가 있는지 살피고 ?.Invoke로 실행함
        ///     c. 이때 두번째 파라미터 문자열을 받아온 함수에 인수로 다시 던짐
        ///     d. 그래서 던지는 값이 어떤 형태인지 인지하고 delegate와 대조하면서 강제할 수 있었음.
        /// </para>
        /// <para>5. 람다식 사용 시 파라미터가 없어도 () => {} 방식으로 작성해주기</para>
        /// </summary>
        private static void Main ()
        {
            CallBackFunc(CallPrint, "Hello"); //함수 연결
            CallBackFunc(delegate (string str) { Console.WriteLine(str); }, "Hello"); //delegate 직접
            CallBackFunc((string str) => { Console.WriteLine(str); }, "Hello"); //람다의 식형태
            CallBackFunc((str) => Console.WriteLine(str), "Hello"); //람다식 기본..
            CallBackFunc(str => Console.WriteLine(str), "Hello");

            dFunc dfunc = () => Console.WriteLine("No Params"); //파라미터가 없는 경우 () 반드시 사용
        }
    }
}
