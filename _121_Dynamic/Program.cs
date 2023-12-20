using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _121_Dynamic
{
    /// <summary>
    /// <para>일반화 + dynamic + default VS Object</para>
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// <para>배열을 더해가는 메서드</para>
        /// <para>
        ///     1. dynamic 키워드를 통해 해당 변수는 런타임에 결정된다 알림,
        ///     2. default(T)를 통해 알맞는 T 타입의 기본 값을 할당할 수 있음:
        ///     T가 숫자 타입일 경우 0, 참조 타입일 경우 null
        /// </para>
        /// </summary>
        /// <typeparam name="T">일반화된 타입으로 유연성 확보</typeparam>
        /// <param name="array">어떤 배열이라도 가능함</param>
        /// <returns>알맞는 리턴 값으로 변환</returns>
        static T SumArray<T> (T[] array)
        {
            // T temp = 0; // 암시적으로 int 값을 T 형식 변환할 수 없음
            // object temp = 0; // 박싱 언박싱 발생, 값 연산 불가
            dynamic temp = default(T);
            for(int i = 0; i < array.Length; i++)
            {
                temp += array[i];
            }
            return temp;
        }

        /// <summary>
        /// <para>배열을 빼는 메서드</para>
        /// <para>
        ///     1. T temp = default;를 통해 T 타입으로 기본 값을 할당할 수 있음
        ///     T가 숫자 타입일 경우 0, 참조 타입일 경우 null,
        ///     2. 배열 원소를 temp에서 빼는데 (dynamic)을 통해 해당 원소를 dynamic 타입 캐스팅,
        ///     런타임에 동적인 타입 변환 가능하고 temp는 동적으로 변환된 값 유지
        /// </para>
        /// <para>
        ///     단, 일반화, default, dynamic을 거쳤다고 반드시 실행이 보장되는 것은 아님,
        ///     아래 메서드를 문자열 배열에 적용하면 문자열끼리 계속 빼기 연산하는 상황인데 논리 상 불가능함.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        static T SubtractArray<T> (T[] array)
        {
            // T temp = default(T);
            T temp = default;
            for (int i = 0; i < array.Length; i++)
            {
                temp -= (dynamic) array[i];
            }
            return temp;
        }

        static void PrintArray<T> (T[] array)
        {
            foreach(var data in array)
            {
                Console.WriteLine("print: {0}", data);
            }
        }

        /// <summary>
        /// <para>일반화 함수 실행 및 var, object, dynamic 살펴보기</para>
        /// <para>
        ///     var로 선언한 변수는 컴파일 단계에서도 정확한 클래스와 메서드를 가르키고 있음
        ///     object로 선언한 변수는 박싱이 일어나 object로 취급 -> 언박싱해서 클래스와 사용 가능
        ///     dynamic으로 선언한 변수는 런타임에 타입이 결정 -> 클래스와 메서드를 전혀 가르키지 않음
        /// </para>
        /// </summary>
        private static void Main ()
        {
            int[] intArr = { 1, 2, 3, 4, 5 };
            
            Console.WriteLine("Sum: {0}", SumArray(intArr));
            Console.WriteLine("Subtract: {0}", SubtractArray(intArr));
            PrintArray(intArr);

            float[] floatArr = { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };

            Console.WriteLine("Sum: {0}", SumArray(floatArr));
            Console.WriteLine("Subtract: {0}", SubtractArray(floatArr));
            PrintArray(floatArr);

            string[] strArr = { "a", "b", "c", "d" };
            Console.WriteLine("Sum: {0}", SumArray(strArr));
            // Console.WriteLine("Subtract: {0}", SubtractArray(strArr));
            PrintArray(strArr);

            var aa = "abc";
            aa.Append('d');
            Console.WriteLine(aa);
            object bb = "def";
            Console.WriteLine(bb.ToString());
            // dynamic cc = "ghi";
            // cc.Append('j');
            // Console.WriteLine(cc);
        }
    }
}
