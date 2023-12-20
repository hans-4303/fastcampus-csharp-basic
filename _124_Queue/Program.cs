using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124_Queue
{
    /// <summary>
    /// <para>Queue + T 제네릭</para>
    /// <para>
    ///     원래 Queue는 제네릭 도입 없었던 시기에 만들어져
    ///     제네릭 없이 인스턴스 생성 가능, 현재는 제네릭을 두고 구별하는 걸 더 권장
    ///     선입 선출 구조 및 Prop 기억하면서 제네릭과 함께 사용하면 됨
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main ()
        {
            Queue<int> queueAA = new Queue<int>();
            queueAA.Enqueue(1);
            queueAA.Enqueue(2);

            for (int i = 0; i < 10; i++)
            {
                queueAA.Enqueue(i);
            }

            Console.WriteLine("queue data: {0}", queueAA.Peek());

            while (queueAA.Count > 0)
            {
                Console.WriteLine("queue data: {0}, count: {1}", queueAA.Dequeue(), queueAA.Count);
            }

            //배열데이터로 초기화
            Console.WriteLine("\n배열데이터로 초기화");
            string[] arrData = { "AA", "BB", "CC" };
            Queue<string> queueArr = new Queue<string>(arrData);

            foreach (var data in queueArr)
            {
                Console.WriteLine("queueArr data: " + data);
            }
        }
    }
}
