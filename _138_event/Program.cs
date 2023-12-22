using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _138_event
{
    /// <summary>
    /// <para>delegate 생성, 문자열 받고 리턴 없음</para>
    /// </summary>
    /// <param name="msg"></param>
    internal delegate void delegateEvent (string msg);

    /// <summary>
    /// <para>delegate와 이벤트 비교 클래스</para>
    /// </summary>
    internal class InDelegate
    {
        public delegateEvent myDelegate;
        public event delegateEvent MyEvent;

        /// <summary>
        /// <para>메서드는 event로만 작동함</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void DoEvent (int a, int b)
        {
            MyEvent?.Invoke("DoEvent: " + ( a + b )); //== ConsoleFunc("DoEvent: " + (a + b)); //== ConsoleFunc("DoEvent: " + (a + b));
        }
    }

    /// <summary>
    /// <para>Program 클래스와 내부, 메인 메서드</para>
    /// <para>
    ///     파라미터를 가지고 반환 값 없는 내부 메서드를 만듦,
    ///     delegate와 일치함
    /// </para>
    /// </summary>
    internal class Program
    {
        static public void ConsoleFunc (string msg)
        {
            Console.WriteLine("ConsoleFunc: " + msg);
        }

        /// <summary>
        /// <para>메인 메서드에서 event 사용</para>
        /// <para>
        ///     event 멤버 사용 시에는 인스턴스를 만들고 메서드 전달하거나
        ///     += 복합 대입으로 메서드 전달 가능,
        ///     대입 연산자는 사용 불가
        /// </para>
        /// <para>
        ///     delegate만을 지정했을 때는 멤버 대리자를 불러 함수같이 실행 가능,
        ///     event를 지정했을 때는 함수 같이 실행이 불가능
        /// </para>
        /// <para>
        ///     event를 지정했을 때는 해당 event 사용하는 메서드를 호출해서
        ///     간접적으로 event에 대입된 메서드를 실행함
        ///     event를 지정했을 때는 -= 복합 대입으로 이벤트를 제거 가능
        /// </para>
        /// </summary>
        private static void Main ()
        {
            InDelegate id = new InDelegate();
            // id.myEvent += new delegateEvent(ConsoleFunc); 
            id.MyEvent += ConsoleFunc;
            //id.myEvent = ConsoleFunc;

            id.myDelegate = ConsoleFunc;

            id.myDelegate("Test"); //클래스 외부 직접 호출 가능..
            // id.myEvent("Test"); //클래스 외부에서 직접 호출 불가..

            for (int i = 0; i < 10; i++)
            {
                if (i == 9) id.MyEvent -= ConsoleFunc;
                id.DoEvent(i + 1, i + 2); //10, 11
            }
        }
    }
}
