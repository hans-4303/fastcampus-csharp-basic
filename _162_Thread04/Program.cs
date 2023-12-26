using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _162_Thread04
{

    internal class Program
    {
        private static void TaskMethod ()
        {
            Thread.Sleep(500);
            Console.WriteLine("TaskMethod");
        }

        /// <summary>
        /// <para>Task.Result == Task 인스턴스 생성 시 전달했던 함수의 리턴 값</para>
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int TaskMethodParam (object num)
        {
            Thread.Sleep(200);
            Console.WriteLine("TaskMethod num: " + num);
            return (int) num * 10;
        }

        /// <summary>
        /// <para>Task, Task: TResult, Wait(); - 병행할 수 있는 비동기 함수와 제어</para>
        /// <para>Task 인스턴스에 Action 혹은 Func delegate를 전달해줄 수 있음. 물론 직접 작성도 할 수는 있음.</para>
        /// <para>
        ///     Task들을 병행할 수 있었고 Start();로 함수 호출한 뒤
        ///     다른 Task를 만들어서 Start();로 호출할 수 있음.
        /// </para>
        /// <para>
        ///     그런데 왜인지 bb.Wait();를 걸지 않아도 결과 도출했지만
        ///     aa.Wait();는 걸지 않으면 실행이 보장되지 않았음.
        ///     실행 보장 되냐 안 되냐는 인지했는데 원인이 궁금.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            Console.WriteLine("Main Thread Start");

            Task aa = new Task(TaskMethod);
            aa.Start(); // 500ms 대기 발생

            Task<int> bb = new Task<int>(TaskMethodParam, 10);
            // TaskMethodParam(10);
            bb.Start();
            bb.Wait();
            // 200ms 만에 결과 도출, 그런데 생략해도 됨.
            // 실행이 비동기적이지만 반환 값을 bb.Result에서 대기하고 있기 때문에 메인 스레드가 실행을 보장함
            Console.WriteLine("Result: " + bb.Result);

            aa.Wait(); // 대기하지 않으면 비동기 TaskMethod 종료: Wait로 실행을 보장받을 수 있었음

            Console.WriteLine("Main Thread End");
        }
    }
}
