using System;

namespace _103_struct
{
    /// <summary>
    /// <para>struct 만들어보기</para>
    /// <para>클래스와 유사한 점들 있음</para>
    /// <para>1. 필드 값을 줄 수 있음</para>
    /// <para>2. 생성자를 만들 수 있음</para>
    /// <para>3. 메서드를 만들 수 있음, 메서드는 파라미터와 필드 값 모두 접근 가능 </para>
    /// <para>다른 점들 있음</para>
    /// <para>1. struct의 생성자는 파라미터 없이 만들 수 없다</para>
    /// <para>2. struct는 call by value 형식, 스택 영역에 대입되고 다른 주소 값을 보고 있으므로 참조 현상이 일어나지 않음</para>
    /// </summary>
    public struct AA
    {
        public int x;
        public int y;

        // public AA() {} // X, 파라미터 없이 생성자 만들 수 없음

        public AA(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine("{0}, {1}", x, y);
        }

        public void PrintDash1(int a, int b)
        {
            Console.WriteLine("{0}, {1}", a, b);
        }

        public void PrintDash2(int a, int b)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", x, y, a, b);
        }
    }

    /// <summary>
    /// <para>struct 호출해보기</para>
    /// <para>
    ///     인스턴스와 유사하게 new로 생성자 함수를 불러도 되고
    ///     반환 및 할당 과정 없이 struct 타입과 식별자만 적어도 됨
    /// </para>
    /// <para>
    ///     인수를 대입해도 되고 대입하지 않아도 됨(메서드 형태에 맞출 것)
    ///     call by value를 따름
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA(10, 20)
            {
                x = 100
            };
            aa.Print();

            AA aaDash;
            aaDash.x = 100;
            aaDash.y = 200;
            aaDash.Print();
            aaDash.PrintDash1(30, 40);
            aaDash.PrintDash2(50, 60);

            AA copyAA = aa;
            copyAA.x = 1000;

            aa.Print();
            copyAA.Print();
        }
    }
}
