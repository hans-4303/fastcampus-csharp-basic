﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _136_delegateParam
{
    /// <summary>
    /// <para>클래스 바깥에 정의된 delegate, 리턴 없고 파라미터 없다 전제함</para>
    /// <para>
    ///     delegate를 선언할 때는 기본적으로 internal 접근 한정자가 적용됨,
    ///     클래스 외부에서는 접근할 수 없는 상태.
    ///     따라서 클래스가 똑같이 internal 접근 한정자를 적용하지 않는다면
    ///     접근 범위가 맞지 않아 컴파일 오류 발생
    /// </para>
    /// </summary>
    internal delegate void delegateFunc ();

    /// <summary>
    /// <para>메세지 프로세스 클래스</para>
    /// <para>1. 필드에 delegateFunc 타입으로 멤버 대리자를 만듦, 함수를 전달받을 수 있음</para>
    /// <para>2. Message 메서드</para>
    /// <para>
    ///     문자열과 delegate 타입 함수 두 개를 파라미터로 받음,
    ///     파라미터로 받아온 함수를 각각 멤버 대리자에 전달함.
    ///     파라미터로 전달받은 문자열을 띄우고 입력을 기다림,
    ///     조건에 따라 필드에 있는 멤버 대리자를 호출해줌.
    /// </para>
    /// <para>3. 디폴트 파라미터와 멤버 delegate 확인</para>
    /// <para>
    ///     메서드의 디폴트 파라미터로 null을 대입했고
    ///     무조건 멤버 delegate를 호출하면 런타임 에러 발생할 수 있음,
    ///     따라서 멤버 delegate?.Invoke();를 통해 null 아닌지 확인 한 후 호출하도록 함
    /// </para>
    /// <para>
    ///     ?.Invoke를 사용하면 호출할 메서드가 null일 경우 호출하지 않고 무시되어서
    ///     null 때문에 예외 처리할 필요는 없음, 하지만 함수 과정이나 결과 자체가 예외를 만든다면
    ///     try - catch 사용도 생각해볼 것
    /// </para>
    /// </summary>
    internal class MessageProcess
    {
        delegateFunc CallOkFunc;
        delegateFunc CallCancelFunc;

        public void Message (string msg, delegateFunc okFunc, delegateFunc cancelFunc = null)
        {
            CallOkFunc = okFunc;
            CallCancelFunc = cancelFunc;

            Console.WriteLine("Message: " + msg + " (0: ok,  1: cancel)");

            string inputStr = Console.ReadLine();

            if (inputStr.Equals("0"))
            {
                try
                {
                    CallOkFunc?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    CallCancelFunc?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    /// <summary>
    /// <para>delegate와 클래스 간 활용</para>
    /// <para>1. Program 클래스 안에서 Message 메서드의 인수로 갈 수 있는 메서드들 작성</para>
    /// <para>2. 첫번째 케이스는 Program 클래스 안에서 만든 메서드를 인수로 전달</para>
    /// <para>3. 두번째 케이스는 하나만 delegate () {}로 만든 익명 함수를 전달함</para>
    /// <para>
    ///     4. 세번째 네번째 케이스는 화살표 함수로 만든 케이스,
    ///     기본적으로 delegate () {}와 동일한 작동
    /// </para>
    /// <para>
    ///     특정 클래스가 다른 클래스의 메서드를 사용한 시작 케이스라 보면 될 듯,
    ///     메인 메서드 안에서 로컬 함수를 생성해볼 수도 있지만 클래스끼리 주고 받는 내용으로는 굳이
    /// </para>
    /// </summary>
    internal class Program
    {
        static void CallOK ()
        {
            Console.WriteLine("CallOK");
        }

        static void CallCancel ()
        {
            Console.WriteLine("CallCancel");
        }

        private static void Main ()
        {
            MessageProcess msg1 = new MessageProcess();
            msg1.Message("Test Message", CallOK, CallCancel);

            MessageProcess msg2 = new MessageProcess();
            msg2.Message("Test Message",
                delegate ()
                {
                    Console.WriteLine("Call InDelegate");
                }
                , CallCancel);

            MessageProcess msg3 = new MessageProcess();
            msg3.Message("Test Message",
                () => Console.WriteLine("Call InDelegate by Lambda")
                , CallCancel);

            MessageProcess msg4 = new MessageProcess();
            msg4.Message("Test Message",
                CallOK
                , () => { Console.WriteLine("Cancel InDelegate by Lambda"); });

            MessageProcess msg5 = new MessageProcess();
            msg5.Message("Null test message", CallOK);

            MessageProcess msg6 = new MessageProcess();
            msg6.Message("Null test message", () => throw new Exception("OK 부분에 새로운 예외 만들기"), CallCancel);

            MessageProcess msg7 = new MessageProcess();
            msg7.Message("Null test message", CallOK, () => throw new Exception("Cancel 부분에 새로운 예외 만들기"));
        }
    }
}
