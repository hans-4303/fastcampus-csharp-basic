using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _040_operator7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            bool result;

            result = (num == 0) ? true: false;
            Console.WriteLine(num);
            Console.WriteLine(result);

            result = (num > 10) ? true : false;
            Console.WriteLine(result);

            // 그건 리액트를 경험하신 분들의 기준인 거고요.
            // !result ? num++ : num--;

            // C#에서 삼항 연산자는 값 또는 변수에 할당되거나 메서드 인자로 전달되어야 함
            int resultValue = !result ? ++num : --num;

            //  물론 할당되거나 전달된 값도 존재함, 원시형이라 참조 현상은 없을 것
            Console.WriteLine(resultValue);
            // 미리 있던 변수도 값이 증가됨
            Console.WriteLine(num);

            someIntMethod(!result ? ++num : --num);
            someBoolToStringMethod(result ? "true" : "false");
        }

        // static 메서드로 변경하거나 클래스의 인스턴스를 생성하고 메서드를 호출해야 해서
        public static void someIntMethod(int value)
        {
            Console.WriteLine("파라미터로 전달된 값: {0}", value);
        }

        public static void someBoolToStringMethod(string value)
        {
            Console.WriteLine(value);
        }
    }
}
