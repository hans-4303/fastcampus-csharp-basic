using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _161_Thread03
{
    internal class Program
    {
        static readonly object thisLock = new object();

        static int _index = 0;

        /// <summary>
        /// <para>메서드 내에서 lock 블록 생성 가능</para>
        /// <para>
        ///     지정된 객체에 대한 상호 배제 기능을 제공할 수 있음,
        ///     특정 객체를 기반으로 작동하고 여러 스레드가 동시에 해당 객체에 대한 lock을 얻을 수 없도록 함.
        ///     객체는 단순히 고유한 값을 가지고 있어야 하며 null이 될 수 없음.
        /// </para>
        /// <para>
        ///     객체는 Monitor 클래스의 인스턴스로 사용,
        ///     lock 블록은 해당 객체에 대한 잠금을 생성하고 해제함
        /// </para>
        /// <para>
        ///     thisLock은 잠금을 걸기 위한 객체이고
        ///     아래 케이스는 _index를 공유하는 여러 스레드 간 상호 배제를 위해 사용됨.
        ///     동시에 여러 스레드가 _index를 수정하는 경우를 없도록 함.
        /// </para>
        /// <para>
        ///     thisLock이 object 타입이어야 하는 이유는 lock문이 오직 참조 타입에만 적용,
        ///     Monitor 클래스가 참조 타입에 대해서만 효과적으로 작동하기 때문임.
        ///     thisLock이 어떤 객체이든지 될 수 있지만 참조 타입이어야 함.
        /// </para>
        /// <para>
        ///     thisLock 객체의 실제 내용도 안 중요하고 단순히 잠금을 관리하기 위해
        ///     식별 가능한 참조 타입 객체일 뿐임. 보통 object 타입의 더미 객체를 사용함.
        ///     그러면 잠금을 얻기 위해 사용되는 참조 타입이 되고 잠금 해제에 사용되는 값은 중요치 않음.
        /// </para>
        /// </summary>
        private static void RunThread ()
        {
            var sw = Stopwatch.StartNew();

            // 크리티컬 섹션
            // lock 블록이 끝나기 전까지 다른 쓰레드는 이 코드를 실행X
            lock (thisLock)
            {
                _index++;

                Console.WriteLine(string.Format("RunThread Start"));

                Console.WriteLine("RunThread sec: {0:N2}", sw.ElapsedMilliseconds / 1000.0f);
                Thread.Sleep(100);

                Console.WriteLine(string.Format("RunThreadEnd"));
                Console.WriteLine("_index: " + _index);
            }
        }

        //_index값을 순차적으로 증가..
        private static void Main ()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread aa = new Thread(new ThreadStart(RunThread));
                aa.Start();
            }
        }
    }
}
