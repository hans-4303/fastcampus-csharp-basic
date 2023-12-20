using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _113_Stack
{
    internal class Program
    {
        /// <summary>
        /// <para>Stack 자료형 알아보기</para>
        /// <para>1. Stack 활용: 인스턴스 생성해야 하며 System.Collections namespace 활용해야 함.</para>
        /// <para>2. Stack 클래스 메서드</para>
        /// <para>
        ///     Stack.Peek();
        ///     Stack의 맨 위에 있는 개체를 제거하지 않고 반환하는 메서드
        ///     반환 타입은 object이기 때문에 박싱 언박싱은 따르지만 유연성 보장
        /// </para>
        /// <para>
        ///     Stack.Push(object obj);
        ///     Stack의 맨 위에 개체를 삽입하는 메서드
        ///     탑을 쌓 듯 생각해볼 수 있겠음, 가장 먼저 놓는 돌이 바닥에 깔림
        /// </para>
        /// <para>
        ///     Stack.Pop();
        ///     Stack의 맨 위에서 개체를 제거하는 메서드
        ///     가장 나중에 놓은 돌이 먼저 들려나감
        /// </para>
        /// </summary>
        private static void Main ()
        {
            Stack stack = new Stack();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            for (int i = 0; i < 10; i++) { stack.Push(i); }

            Console.WriteLine("first stack data: {0}", stack.Peek());

            while (stack.Count > 0) { Console.WriteLine("current stack data: {0}, current stack count: {1}", stack.Pop(), stack.Count); }

            Console.WriteLine("배열 선언하고 stack을 출력, LIFO 방식 적용됨");
            int[] values = { 100, 200, 300 };
            Stack valuesToStack = new Stack(values);

            foreach(object value in valuesToStack) { Console.WriteLine(value); }
        }
    }
}
