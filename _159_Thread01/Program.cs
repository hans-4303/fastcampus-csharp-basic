using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _159_Thread01
{
    internal class Program
    {
        private static void RunThread ()
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: 0 Start"));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThread index: {0} sec: {1:N2}", "0", sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("RunThread index: 0 End"));
            Console.WriteLine();
        }

        private static void RunThread (int index)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: {0} Start", index));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThread index: {0} sec: {1:N2}", index, sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine(string.Format("RunThread index: {0} End", index));
            Console.WriteLine();
        }

        private static void RunThreadObject (object index)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThreadObject index: {0} Start", index));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThreadObject index: {0} sec: {1:N2}", index, sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("RunThreadObject index: {0} End", index));
            Console.WriteLine();
        }

        /// <summary>
        /// <para>Thread</para>
        /// <para>
        ///     대개 메인 메서드 안에 모든 로직을 처리할 때는 프로그램,
        ///     즉 프로세스 안에 스레드가 단 한 개만 돌고 있었음.
        ///     그래서 메인 메서드 내에서 실행하는 로직은 순차적으로 실행될 수 있었음.
        /// </para>
        /// <para>
        ///     그런데 Thread 인스턴스를 만들면서 한 프로세스 안에 여러 스레드를 생성해줄 수 있음,
        ///     Thread 인스턴스는 실행할 함수를 인수로 받을 수 있음.
        ///     실행할 함수는 미리 선언하던 delegate로 작성하건 람다식으로 작성하건 문제 없음.
        /// </para>
        /// <para>
        ///     이후 Thread 인스턴스에서 Start(); 메서드를 호출해서 전달했던 함수를 실행해줄 수 있음.
        ///     그런데 각 스레드가 독립적이기 때문에 순차적 실행을 보장하지 않게 됨.
        ///     0, 1, 2, 3, 4 같은 순서가 아니라 3, 1, 4, 2, 0 등 런타임마다 다른 순서와 결과를 갖게 됨.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            // RunThread();        // 기본 함수..
            // RunThread(1);       // 기본 함수..
            // RunThread(2);       // 기본 함수..

            Thread _thread1 = new Thread(RunThread);
            _thread1.Start();

            Console.WriteLine("===================================================");
            Console.WriteLine();

            Thread _thread2 = new Thread(() => RunThread(1));
            _thread2.Start();

            new Thread(() => RunThread(2)).Start();

            Thread _thread3 = new Thread(new ParameterizedThreadStart(RunThreadObject));
            _thread3.Start(3);
            // 매개변수를 갖는 쓰레드 실행하는 방법 (object 매개변수만 넘길수 있다)

            Thread _thread4 = new Thread(delegate ()
            {
                var sw = Stopwatch.StartNew();

                Console.WriteLine(string.Format("RunThread index: 4 Start"));

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("RunThread index: {0} sec: {1:N2}", "0", sw.ElapsedMilliseconds / 1000.0f);
                    Thread.Sleep(100);
                }

                Console.WriteLine();
                Console.WriteLine(string.Format("RunThread index: 4 End"));
                Console.WriteLine();
            });
            _thread4.Start();
        }
    }
}
