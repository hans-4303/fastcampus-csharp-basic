using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _160_Thread02
{
    /// <summary>
    /// <para>Thread 중단과 중단 이후 처리</para>
    /// <para>
    ///     Thread 인스턴스는 Abort, Join, Interrupt 메서드를 가질 수 있음.
    /// </para>
    /// <para>
    ///     Thread.Abort();
    ///     인스턴스에서 Start로 호출됐던 메서드를 그 시점에서 중단함,
    ///     어떤 내용이 남았더라도 마저 실행해주지 않음.
    ///     그래서 권장하진 않는다.
    /// </para>
    /// <para>
    ///     Thread.Join();
    ///     인스턴스에서 Start로 호출됐던 메서드를 끝까지 실행 후 중단함.
    /// </para>
    /// <para>
    ///     Thread.Interrupt();
    ///     인스턴스에서 Start로 호출됐던 메서드를 그 시점에서 중단함,
    ///     하지만 Abort와는 달리 ThreadInterruptedException 예외를 던지며
    ///     try catch finally 블록으로 잡을 수 있음.
    /// </para>
    /// <para>
    ///     UI와 연결지어본다면 비상 종료(로그 안 남김), 종료 예약, 비상 종료(로그 남김) 정도로 이해해도 되지 않을까?
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void RunThread (int index)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: {0} Start", index));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("RunThread index: {0} sec: {1:N2}", index, sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);
            }

            Console.WriteLine(string.Format("RunThread index: {0} End", index));
            Console.WriteLine();
        }

        private static void RunExeption (int index)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine(string.Format("RunThread index: {0} Start", index));

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("RunThread index: {0} sec: {1:N2}", index, sw.ElapsedMilliseconds / 1000.0f);
                    Thread.Sleep(100);
                }

                Console.WriteLine(string.Format("RunThread index: {0} End", index));
                Console.WriteLine();
            }
            catch (ThreadInterruptedException e)
            { //System.Threading.ThreadAbortException이라는 예외를 발생
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("====  finally ===");
            }
        }

        private static void Main ()
        {
            Thread aa = new Thread(() => RunThread(0));
            aa.Start();
            Thread.Sleep(300);
            aa.Abort();
            Console.WriteLine(string.Format("Abort"));
            Console.WriteLine();


            Thread bb = new Thread(() => RunThread(1));
            bb.Start();
            Thread.Sleep(300);
            bb.Join();
            Console.WriteLine(string.Format("Join"));
            Console.WriteLine();


            Thread cc = new Thread(() => RunExeption(2));
            cc.Start();
            Thread.Sleep(300);
            //cc.Abort();
            cc.Interrupt();
            Console.WriteLine(string.Format("Interrupt"));
            Console.WriteLine();
        }
    }
}
