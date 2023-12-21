using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _129_throw
{
    internal class Program
    {
        /// <summary>
        /// <para>메서드 내부의 예외처리</para>
        /// <para>
        ///     조건이 맞지 않다면 예외처리 인스턴스를 만들 수 있음,
        ///     throw 키워드를 통해서 인스턴스를 catch 블록으로 던질 수 있음
        /// </para>
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="Exception"></exception>
        static void ThrowFunc(int data)
        {
            if(data > 0)
            {
                Console.WriteLine(data);
            }
            else
            {
                throw new Exception("data에 0이 입력되었습니다");
            }
        }

        static int ThrowDivision(int a, int b)
        {
            if(a != 0 && b != 0)
            {
                return a / b;
            }
            else
            {
                throw new Exception("분모 혹은 분자에 0이 있으므로 연산할 수 없습니다.");
            }
        }

        /// <summary>
        /// <para>nullable, ??와 삼항 연산자, throw를 통한 예외처리</para>
        /// <para>
        ///     try 블록에서 로직을 실행해보고 조건이 맞지 않으면
        ///     예외처리 인스턴스를 만들 수 있으며 throw를 통해 catch 블록에 던질 수 있음.
        ///     예외처리 인스턴스가 구체적인 타입을 가져도 됨.
        /// </para>
        /// <para>
        ///     단, throw를 통해서 세부 예외를 던졌다가 catch 블록에서 Exception으로 받을 수는 있지만
        ///     역으로 throw를 통해서 Exception을 던졌다가 catch 블록에서 세부 예외로 처리할 수는 없음.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            try
            {
                ThrowFunc(10);
                ThrowFunc(100);
                ThrowFunc(0);
                ThrowFunc(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("100/20: " + ThrowDivision(100, 20));
                Console.WriteLine("10/5: " + ThrowDivision(10, 5));
                Console.WriteLine("10/0: " + ThrowDivision(10, 0));
                Console.WriteLine("100/100: " + ThrowDivision(100, 100));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // ??: 변수가 null인지 체크
            int? a = null;
            try
            {
                int b = a ?? throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            // ? :
            int result = 101;
            try
            {
                int checkNum = ( result < 100 ) ? result : throw new Exception("100 이하만 가능");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
