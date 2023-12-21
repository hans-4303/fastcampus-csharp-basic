using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _127_try_catch
{
    internal class Program
    {
        /// <summary>
        /// <para>오류 상황 만든 후 예외처리 해보기</para>
        /// <para>1. 값 입력받을 변수 만들기</para>
        /// <para>2. try 안에 있는 로직 실행해보기</para>
        /// <para>3. 오류로 인해 진행이 불가능할 시 catch문으로 넘어가기</para>
        /// <para>
        ///     그런데 오류에도 타입을 매치해줄 수 있는 걸로 확인됨,
        ///     모든 오류를 다 알고 잡아줄 수 있는 건 아니지만
        ///     어떤 로직이나 메서드를 실행했을 때 나타날 수 있는 오류를 명시해줄 수 있을 것으로 보임.
        /// </para>
        /// <para>
        ///     어느 정도 생각한 대로 메서드에 나타날 수 있는 
        ///     예외 상황들을 catch문 여러 개로 다룰 수 있었음
        /// </para>
        /// </summary>
        private static void Main ()
        {
            int inputNum = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.WriteLine("입력문자: ");
                string readStr = Console.ReadLine();
                // string readStrDash = null;

                try
                {
                    inputNum = int.Parse(readStr);
                    isCorrect = true;
                }
                catch (ArgumentException e)
                {
                    // null 값을 던졌을 때 ArgumentException 발생
                    Console.WriteLine(e.Message);
                    Console.WriteLine("인수가 유효하지 않습니다.");
                }
                catch (FormatException e)
                {
                    // Parse 불가능한 문자열 던졌을 때 FormatException 발생
                    Console.WriteLine(e.Message);
                    Console.WriteLine("입력문자: " + readStr + " 정수 입력 하세요");
                }
                catch (OverflowException e)
                {
                    // int 범위 벗어났을 때 OverflowException 발생
                    Console.WriteLine(e.Message);
                    Console.WriteLine("입력 숫자가 int 범위를 벗어났습니다.");
                }
            }

            Console.WriteLine("inputNum: " + inputNum);
        }
    }
}
