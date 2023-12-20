using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _125_Stack
{
    /// <summary>
    /// <para>Stack + T 제네릭</para>
    /// <para>
    ///     원래 Stack은 제네릭 도입 없었던 시기에 만들어져
    ///     제네릭 없이 인스턴스 생성 가능, 현재는 제네릭을 두고 구별하는 걸 더 권장
    ///     후입 선출 구조 및 Prop 기억하면서 제네릭과 함께 사용하면 됨
    /// </para>
    /// </summary>
    internal class Program
    {
        static void Main ()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Console.WriteLine("stack data: {0}", stack.Peek());

            while (stack.Count > 0)
            {
                Console.WriteLine("stack data: {0}, count: {1}", stack.Pop(), stack.Count);
            }

            //배열데이터로 초기화
            Console.WriteLine("\n배열데이터로 초기화");
            int[] arrData = { 100, 200, 300 };
            Stack<int> stackCopy = new Stack<int>(arrData);

            foreach (object data in stackCopy)
            {
                Console.WriteLine("stackCopy data: " + data);
            }
        }
    }
}
