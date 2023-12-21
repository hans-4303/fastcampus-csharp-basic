using System;

namespace _128_Exception
{
    internal class Program
    {
        /// <summary>
        /// <para>예외를 일반화 처리해보는 케이스</para>
        /// <para>
        ///     발생할 수 있는 오류들은 모두 Exception 클래스를 상속한 서브 클래스임,
        ///     그래서 모든 오류들은 Exception을 통해서 잡아낼 수 있지만
        ///     오류 각각에 대한 세밀한 처리를 Exception에 해당하는 catch 블록에서 처리하기 어려우므로
        ///     세부 예외 처리에 대한 catch 블록을 먼저 만들고 Exception catch 블록은 가장 마지막에 만드는 걸 권장.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            int maxNum = 10;

            try
            {
                checked
                {
                    maxNum += Int32.MaxValue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch (OverflowException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.Source);
            //}
            finally { Console.WriteLine(maxNum); }
        }
    }
}
