// using System.Collections; 네임스페이스를 써야 Queue 사용 가능
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _112_Queue
{
    internal class Program
    {
        /// <summary>
        /// <para>Queue 컬렉션</para>
        /// <para>1. Queue 컬렉션은 System.Collections namespace를 사용 시 활용할 수 있음.</para>
        /// <para>2. 인스턴스를 만들어서 활용 가능</para>
        /// <para>
        ///     인스턴스 생성 시 빈 인스턴스로 작성할 수도 있고,
        ///     인수에 배열을 넣어서 생성할 수도 있음.
        /// </para>
        /// <para>
        ///     new 키워드로 새 배열을 생성할 수도 있고,
        ///     생성된 배열을 인수로 넣어도 됨.
        /// </para>
        /// <para>3. Queue 클래스 메서드</para>
        /// <para>
        ///     Queue.Enqueue(object obj):
        ///     queue에 어떠한 데이터를 넣는 메서드임,
        ///     인수 타입은 object이기 때문에 박싱 언박싱은 따르지만 유연성이 보장됨.
        /// </para>
        /// <para>
        ///     Queue.Dequeue();
        ///     queue에 입력된 데이터를 제거하는 메서드임,
        ///     가장 먼저 입력된 데이터가 가장 먼저 제거됨.
        /// </para>
        /// <para>
        ///     Quque.Peek();
        ///     queue의 시작 부분에서 개체를 제거하지 않고 반환해줌.
        ///     반환 타입은 object이기 때문에 박싱 언박싱은 따르지만 유연성 보장.
        /// </para>
        /// <para>4. Queue 클래스 Prop</para>
        /// <para>
        ///     Queue.Count;
        ///     int 타입이며 get;만 가능한 Prop,
        ///     Queue의 요소 개수를 뜻하며
        ///     Enqueue, Dequque 등 동작에 따라 결정되는 Prop이기 때문에
        ///     Set 동작은 불필요함.
        /// </para>
        /// <para>5. Queue 인스턴스와 불변성</para>
        /// <para>
        ///     a. Queue는 인스턴스를 생성해야 하고,
        ///     이 과정에서 다른 배열을 인수로 생성됐다 하더라도 다른 배열과 서로 불변성은 보장됨.
        ///     b. Queue 인스턴스를 생성할 때 이미 작성된 Queue 인스턴스를 인수로 넣을 수도 있음,
        ///     이때 new Queue(Queue 인스턴스)와 같이 작성하면 불변성이 보장됨.
        ///     c. 하지만 queue2 = queue1과 같이 작성하면 불변성이 보장될 수 없음.
        ///     이 경우 두 queue가 같은 주소 값을 바라보고 있기 때문에 queue2를 편집시 queue1까지 변함.
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            Queue queue = new Queue(new int[] { 100, 200, 300 } );

            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            for (int i = 0; i < 10; i++) { queue.Enqueue(i); }

            Console.WriteLine(queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine("current queue element: {0}, current queue count: {1}", queue.Dequeue(), queue.Count);
            }

            if(queue.Count == 0) { Console.WriteLine("Queue 요소가 전부 비었습니다."); }

            Console.WriteLine("배열 데이터를 초기화");
            int[] arrayData = { 1, 2, 3 };
            foreach (int i in arrayData) { Console.WriteLine(i); }

            Console.WriteLine("배열 데이터 기반으로 Queue 생성 후 불변성 체크하기");
            Queue queueCopiedArray = new Queue(arrayData);
            for (int i = 0; i < arrayData.Length; i++) { queueCopiedArray.Enqueue(arrayData[i]); }
            foreach (object data in queueCopiedArray) { Console.WriteLine(data); }

            Console.WriteLine("원본 배열 데이터 출력, 가능하다면 불변성 확인됨");
            foreach (int i in arrayData) { Console.WriteLine(i); }

            Console.WriteLine("기존 Queue를 new로 생성할 수 있는지 확인 및 불변성 체크: 안 깨짐");
            Queue anotherQueue1 = new Queue(queueCopiedArray);
            anotherQueue1.Enqueue("a");
            foreach (object data in queueCopiedArray) { Console.WriteLine(data); }

            Console.WriteLine("기존 Queue를 또 다른 Queue에 new 없이 할당하고 불변성 깨지는 지 확인해보기: 깨짐");
            Queue anotherQueue2 = queueCopiedArray;
            anotherQueue2.Enqueue("a");
            foreach (object data in queueCopiedArray) { Console.WriteLine(data); }
        }
    }
}
