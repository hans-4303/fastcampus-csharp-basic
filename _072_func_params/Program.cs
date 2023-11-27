using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _072_func_params
{
    internal class Program
    {
        // 배열 메서드 사용하는 함수
        static void AdvancedCheckValues(params object[] values)
        {
            // Array.ForEach로 호출
            // 순회할 배열과 각각의 요소 명시하고 순회 시 실행할 로직 대입
            Array.ForEach(values, value => Console.WriteLine("{0} {1}", value, value.GetType()));
        }


        static void CheckValues(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("{0} {1}", values[i], values[i].GetType());
            }
        }

        static void Main(string[] args)
        {
            CheckValues(0, 10.2f, 10.41, 1021331231231d, "nice to meet you");
        }
    }
}
