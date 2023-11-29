using System;

namespace _102_extension
{
    /// <summary>
    /// 기본 클래스 AA, 문자열을 파라미터로 받고 출력하는 메서드가 있음
    /// </summary>
    public class AA
    {
        public void PrintAA(string str)
        {
            Console.WriteLine("PrintAA {0}", str);
        }
    }

    /// <summary>
    /// <para>여러 메서드가 합쳐진 Util 클래스</para>
    /// <para>1. Print 메서드를 호출 시</para>
    /// <para>
    ///     클래스를 호출하고 파라미터로 인스턴스와 문자열을 넘기거나
    ///     인스턴스에서 Print 메서드를 이어 쓰고 문자열을 넘길 수 있음
    /// </para>
    /// <para>2. Sum 메서드를 호출 시</para>
    /// <para>
    ///     클래스를 호출하고 파라미터로 숫자를 넘기거나
    ///     숫자 값에서 메서드를 이어 쓸 수도 있음
    /// </para>
    /// </summary>
    static public class Util
    {
        public static void Print(this AA aa, string str)
        {
            aa.PrintAA(str);
        }

        public static void Sum(this int a)
        {
            Console.WriteLine("{0} + {1} = {0}", a, a, a + a);
        }
    }

    /// <summary>
    /// <para>Print 메서드를 위해서 AA 인스턴스를 만듦</para>
    /// <para>Sum 메서드를 위해서는 인스턴스가 필요 없음</para>
    /// <para>두 가지 방법으로 메서드를 호출할 수 있음</para>
    /// <para>
    ///     Util 클래스 자체와 Print 메서드를 호출하되 인수로 인스턴스와 문자열을 넘긴다 ||
    ///     해당하는 인스턴스에서 Print 메서드를 호출하고 문자열을 넘긴다
    /// </para>
    /// <para>
    ///     Util 클래스 자체와 Sum 메서드를 호출하되 인수로 숫자를 넘긴다 ||
    ///     숫자 값에서 Sum 메서드를 즉시 호출한다
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA();

            Util.Print(aa, "Hello");
            aa.Print("Hello");

            Util.Sum(10);
            10.Sum();
        }
    }
}
