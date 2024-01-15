using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _132_delegate
{
    /// <summary>
    /// <para>delegate 익혀보기</para>
    /// <para>
    ///     대리자, 메서드 끼리 참조할 수 있음
    ///     메서드가 이러한 값을 받을 것이고 어떠한 값을 반환한다 틀을 만들어줄 수 있음,
    ///     클래스 간 통신에 활용될 수 있음
    /// </para>
    /// <para>1. degegate 키워드 적기</para>
    /// <para>2. 반환 값 형태 정하기</para>
    /// <para>3. 식별자 정하기(실제 아래 예제에서는 타입처럼 적음)</para>
    /// <para>4. 파라미터 타입과 값 정하기</para>
    /// </summary>
    /// <param name="a">파라미터 타입과 값, 여기서는 int a</param>
    /// <returns>호출되었을 때 반환할 형식, 여기서는 int</returns>
    delegate int DelegateFunc (int a);

    /// <summary>
    /// <para>delegate 활용해보기</para>
    /// <para>1. 간단한 메서드를 작성, 단 리턴과 파라미터는 delegate와 똑같이 준비함.</para>
    /// <para>2. 메인 메서드에서 DelegateFunc thisFunc = Add; 라고 할당함</para>
    /// <para>
    ///     메서드 타입의 변수를 만들고 메서드를 할당했는데
    ///     즉시 호출하거나 사용하는 개념이 아님,
    ///     전달만 해두는 개념에 가까움(예) React에서 이벤트에 함수를 '전달'하는 문법)
    /// </para>
    /// <para>3. 메서드 타입 변수에 적당한 값을 입력해서 실행 == 전달한 메서드 실행</para>
    /// <para>4. 변수를 다루는 것과 비슷하게 생성된 변수에 다른 메서드를 할당하면 바뀐 메서드가 실행</para>
    /// </summary>
    internal class Program
    {
        static int Add (int a)
        {
            Console.WriteLine("Add");
            return a + a;
        }

        static int Square(int a)
        {
            Console.WriteLine("Square");
            return a * a;
        }

        private static void Main ()
        {
            DelegateFunc thisFunc = Add; //thisFunc(Add)
            Console.WriteLine("thisFunc: " + thisFunc(10));

            thisFunc = Square;
            Console.WriteLine("thisFunc: " + thisFunc(10));

            Console.WriteLine("레포지토리 편집");
        }
    }
}
