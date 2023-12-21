using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _130_finally
{
    internal class Program
    {
        /// <summary>
        /// <para>
        ///     ThrowFunc 메서드는 0을 거르는 if else문,
        ///     따라서 catch문으로 넘어가는 분기는 없음
        /// </para>
        /// </summary>
        /// <param name="data"></param>
        static void ThrowFunc(int data)
        {
            if (data != 0) Console.WriteLine(data);
            else Console.WriteLine("data에 0이 입력되었습니다");
        }

        /// <summary>
        /// <para>finally 학습을 위한 예제</para>
        /// <para>
        ///     첫번째 try 블록에서는 catch 블록 실행하지 않고 finally 블록 실행하는 경우를,
        ///     세번째 try 블록에서는 catch 블록 실행하고 finally 블록 실행하는 경우로 만듦.
        ///     어떤 경우에서도 finally 블록은 실행된다 보면 됨.
        /// </para>
        /// <para>
        ///     return이 붙은 두번째 try 블록에서도 해당 finally까지 도달하는 건 보장되는데,
        ///     메인 메서드 기준으로는 return;을 통해 메인 메서드 자체가 끝나버려서
        ///     남은 세번째 try 블록이 실행되지 않았음.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            try
            {
                ThrowFunc(10);
                ThrowFunc(100);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("finally 무조건 실행\n");
            }

            try
            {
                ThrowFunc(10);
                ThrowFunc(100);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("return이 앞에 붙어도 실행될까?\n");
            }

            int? a = null;

            try
            {
                ThrowFunc(0);
                int b = a ?? throw new ArgumentNullException("null 값 대입을 시도했습니다");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("역시 finally 무조건 실행 \n");
            }
        }
    }
}
