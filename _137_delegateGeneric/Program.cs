using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _137_delegateGeneric
{
    /// <summary>
    /// <para>델리게이트를 제네릭으로 정의한 케이스</para>
    /// </summary>
    /// <typeparam name="T">파라미터의 타입</typeparam>
    /// <typeparam name="TResult">리턴형의 타입</typeparam>
    /// <param name="arg">제네릭으로 정의된 파라미터, 들어오는 건 아무거나 괜찮음</param>
    /// <returns>델리게이트니까 정확한 리턴을 미리 적지는 않는다</returns>
    internal delegate TResult GenericDelegate<T, TResult> (T arg);

    /// <summary>
    /// <para>델리게이트를 오버로딩한 케이스</para>
    /// <para>
    ///     이 경우 리턴형이 없는 함수일 수 있다 void로 지정했음
    /// </para>
    /// </summary>
    /// <typeparam name="T">파라미터의 타입</typeparam>
    /// <param name="arg">제네릭으로 정의된 파라미터, 들어오는 건 아무거나 괜찮음</param>
    internal delegate void GenericDelegate<T> (T arg);

    /// <summary>
    /// <para>제네릭 델리게이트와 사용</para>
    /// <para>
    ///     1. 델리게이트와 매치할 메서드를 만들되 예외 경우를 둘 수 있다 전제했음,
    ///     예외 생길 경우 throw new 예외 처리();를 통해 catch 블록으로 던짐
    /// </para>
    /// <para>
    ///     2. 델리게이트 변수를 생성하고 함수를 전달함,
    ///     파라미터와 리턴형을 적는 케이스 / 파라미터만 적고 리턴 없이 void로 처리하는 두 가지 케이스로 나눔.
    /// </para>
    /// <para>
    ///     3. try 블록에서 델리게이트를 호출하되 예외 발생하는 경우를 다뤘고
    ///     메서드 내부 throw 때문에 catch 블록으로 넘어간 뒤 메시지 출력
    /// </para>
    /// </summary>
    internal class Program
    {
        static int DivideByValue (int value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return 10 / value;
        }

        static string GreetingForUser(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("write your name first.");
            }

            return "Hello, " + username + ". How are you today?";
        }

        static int NameLengthChecker(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("write your name first.");
            }

            return name.Length;
        }

        static void DisplayUser(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("you did not signin");
            }

            Console.WriteLine("{0} is signin now", username);
        }

        private static void Main ()
        {
            GenericDelegate<int, int> divideDelegate = DivideByValue;

            try
            {
                int result = divideDelegate(0);
                Console.WriteLine($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            GenericDelegate<string, string> greetingDelegate = GreetingForUser;

            try
            {
                string result = greetingDelegate(null);
                Console.WriteLine($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            try
            {
                string result = greetingDelegate("Joel");
                Console.WriteLine($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            GenericDelegate<string, int> lengthCheckDelegate = NameLengthChecker;

            try
            {
                int result = lengthCheckDelegate(null);
                Console.WriteLine($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            try
            {
                string inputName = "Joel";
                int result = lengthCheckDelegate(inputName);
                Console.WriteLine($"Length of {inputName}: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            GenericDelegate<string> displayUserDelegate = DisplayUser;

            try
            {
                string inputName = null;
                displayUserDelegate(inputName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }

            try
            {
                string inputName = "Joel";
                displayUserDelegate(inputName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}\n");
            }
        }
    }
}
