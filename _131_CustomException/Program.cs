using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _131_CustomException
{
    /// <summary>
    /// <para>사용자 정의 예외 클래스를 위한 인터페이스</para>
    /// <para>
    ///     어차피 사용자 정의 예외 클래스는 ApplicationException을 상속받는다 인지하고,
    ///     다중 클래스 상속은 불가능한 대신 인터페이스 상속은 가능한지 알아보기 위함이었음.
    ///     인터페이스 자체는 void Print(); 메서드를 간단하게 명세함.
    /// </para>
    /// </summary>
    interface IMyException
    {
        void Print ();
    }

    /// <summary>
    /// <para>사용자 정의 예외 클래스</para>
    /// <para>
    ///     ApplicationException을 상속 받아 만들 수 있는 클래스,
    ///     ApplicationException은 Exception 클래스를 상속받은 클래스이기 때문에
    ///     Exception 클래스의 메서드들을 오버라이딩 하는 것도 가능했음
    ///     대신 다중 클래스 상속은 안 되니까 인터페이스 추가 상속만 가능한 상태 맞나?: 맞음
    /// </para>
    /// <para>
    ///     인터페이스 상속이 가능했고, 상속받은 Print 메서드를 구현해봄.
    ///     간단히 Console.WriteLine에서 Prop Num을 get 동작으로 출력해줌.
    /// </para>
    /// </summary>
    public class MyException : ApplicationException, IMyException
    {
        public int Num { get; set; }

        public MyException () : base() {}

        public MyException (int a) { Num = a; }

        public override string ToString ()
        { 
            return "Num: " + Num;
        }

        public void Print ()
        {
            Console.WriteLine("인터페이스를 상속받은 사용자 정의 예외 클래스: {0}", Num);
        }
    }

    /// <summary>
    /// <para>사용자 정의 예외 클래스 -> 인스턴스를 사용한 케이스</para>
    /// <para>1. 변수 입력 부분과 try, catch 블럭으로 구성됨.</para>
    /// <para>2. try 블럭</para>
    /// <para>
    ///     조건에 따라 throw new MyException(num)으로
    ///     예외 인스턴스를 생성하고 catch 블럭으로 넘어감
    /// </para>
    /// <para>
    ///     물론 try문 안에서도 예외 인스턴스 생성과 접근이 가능하긴 한데,
    ///     try문 안에서 처리할 이유가 없기 때문에 catch문으로 넘긴다 이해할 수 있음.
    /// </para>
    /// <para>3. catch 블럭</para>
    /// <para>
    ///     catch문의 파라미터 타입을 사용자 정의 예외 클래스로
    ///     파라미터 값은 받아올 사용자 정의 예외 인스턴스로 작성할 수 있음,
    /// </para>
    /// <para>
    ///     클래스의 설계를 따라 인스턴스에서 멤버들(필드, Prop, 메서드)에 접근할 수 있음.
    ///     (물론 필드 값의 접근 권한을 public으로 정했다면 필드 값에도 접근할 수 있겠지만
    ///     보통 그렇게는 작성 안할 것)
    ///     이 접근을 통해 when 키워드에 세부 조건을 정할 수도 있고,
    ///     클래스에 정의한 메서드에 접근할 수도 있었음.
    /// </para>
    /// <para>
    ///     ApplicationException 클래스를 상속 받았으므로
    ///     Exception 클래스의 Prop을 사용할 수 있으며
    ///     인스턴스.StackTrace; Prop 에도 접근 가능함.
    /// </para>
    /// <para>
    ///     StackTrace Prop:
    ///     호출 스택의 직접 실행 문자열을 가져온다고 되어 있는데
    ///     "위치: 인스턴스가 호출된 네임스페이스.클래스.메서드(),
    ///     파일: 현재 파일이 존재하는 경로"
    ///     정보를 표시해줌.
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main ()
        {
            Console.WriteLine("사용자 정의 예외 클래스: 0 혹은 10 입력 시 예외 클래스를 호출합니다.");
            string readStr = Console.ReadLine();
            try
            {
                int num = int.Parse(readStr);

                if (num == 0 || num == 10)
                {
                    Console.WriteLine("try 블록에서 인스턴스 호출과 메서드 작동이 될 지 확인");
                    MyException temp = new MyException(num);
                    temp.Print();
                    Console.WriteLine("{0}", temp.StackTrace);
                    Console.WriteLine("catch 블록으로 넘어감");
                    throw new MyException(num);
                }
            }
            catch (MyException e) when (e.Num == 0)
            {
                Console.WriteLine("when(e.Num == 0)");
                Console.WriteLine("MyException: " + e.Num);
                Console.WriteLine("MyException: " + e.StackTrace);
            }
            catch (MyException e) when (e.Num == 10)
            {
                Console.WriteLine("when(e.Num == 10)");
                Console.WriteLine("MyException: " + e.Num);
                Console.WriteLine("MyException: " + e.ToString());
                e.Print();
                Console.WriteLine("MyException: " + e.StackTrace);
            }
        }
    }
}
