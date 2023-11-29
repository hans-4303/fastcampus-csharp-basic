using System;

namespace _095_inheritance
{
    /// <summary>
    /// 조부모 클래스를 생성해봄
    /// </summary>
    public class ExtraSuper
    {
        /// <summary>
        /// 조부모 클래스에서 필드 값 선언하기
        /// </summary>
        protected int z;
        public ExtraSuper()
        {
            Console.WriteLine("ExtraSuper 생성자 호출");
        }
        ~ExtraSuper()
        {
            Console.WriteLine("ExtraSuper 생성자 소멸");
        }


        /// <summary>
        /// 이 메서드는 간단한 연산을 수행할 것
        /// </summary>
        /// 
        /// param 주석은 name="파라미터 이름" 호버 시 볼 수 있음
        /// <param name="value">파라미터로 받아오는 입력 값</param>
        /// 
        /// <returns>연산 결과가 반환</returns>
        public int SampleMethod(int value)
        {
            // 메서드 구현 부분
            return value * 2;
        }
    }
    /// <summary>
    /// 부모 클래스: 자식 클래스의 부모이자 조부모 클래스의 자식
    /// </summary>
    public class Super: ExtraSuper
    {
        // protected int a;
        public Super()
        {
            // a = 100;
            Console.WriteLine("Super 생성자 호출");
        }
        ~Super()
        {
            Console.WriteLine("Super 소멸자 호출");
        }
    }
    /// <summary>
    /// 부모 클래스의 자식 클래스
    /// </summary>
    public class Sub : Super
    {
        public Sub()
        {
            Console.WriteLine("Sub 생성자 호출");
        }
        ~Sub()
        {
            Console.WriteLine("Sub 소멸자 호출");
        }
    }

    internal class Program
    {
        /// <summary>
        /// 예상 밖:
        /// <para>
        /// Sub 인스턴스를 만들면서 Sub가 호출 및 소멸될 건 생각했는데
        /// 1. Super 생성자가 맨 먼저 호출
        /// 2. Sub 생성자 호출
        /// 3. Sub 소멸자 호출
        /// 4. Super 소멸자가 마지막 호출
        /// 같이 진행되고 있음.
        /// </para>
        /// <para>
        /// 상속이 진행 중: 자식 클래스가 부모 클래스의 무언가를 인지하고 사용하기 위해서
        /// 부모 클래스가 먼저 호출되고 자식 클래스가 작용 후 부모 클래스가 소멸.
        /// 심지어 자식 클래스가 부모 클래스의 어떤 필드 값을 사용하지 않더라도
        /// 부모 클래스가 먼저 호출 후 자식 클래스가 작동함.
        /// </para>
        /// </summary>
        /// 
        /// <remarks>
        /// <para>
        /// 부모 클래스 Case 1.
        /// 부모 클래스에 어떠한 조부모 등이 없다면 자신은 어떤 상속 구조를 갖지 않았기 때문에
        /// 생성과 소멸을 한 번만 하게 됨.
        /// </para>
        /// <para>
        /// 부모 클래스 Case 2.
        /// 부모 클래스에 어떠한 조부모를 두었고 상속 구조를 갖는다 생각해봤음
        /// 그렇다면 부모 클래스가 조부모 클래스에 감싸여있게 됨.
        /// 자식 클래스를 단독으로 호출한다고 해도 부모 클래스와 조부모 클래스 2중으로 감싸여있게 됨.
        /// </para>
        /// <para>
        /// 아래와 같이
        /// </para>
        /// <para>조부모 - 부모 - 자식 - /부모 - /조부모</para>
        /// <para>구조가 대부분의 경우에서 실행됨.</para>
        /// <para>
        /// 설령 조부모나 부모 클래스에서 상속으로 전달해야 할 어떠한 멤버가 없다고 하더라도
        /// 클래스 구조 상 상속을 명시하면 위의 구조로 진행됨.
        /// </para>
        /// </remarks>
        private static void Main(/* string[] args */)
        {
            // 메인 메서드 안에서 생성하는 로컬 변수에 대해서는 XML 주석을 통한 호버 설명이 일반적으로 지원되지 않음
            // 호버 설명은 주로 클래스의 멤버(필드, 속성, 메서드 등)에 대해서만 작동하기 때문이고
            // 코드 자체에 주석을 추가하면 됨
            //_ = new Super();
            _ = new Sub();
        }
    }
}
