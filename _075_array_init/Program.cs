using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _075_array_init
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int 타입 배열 선언, 길이만 가짐
            int[] arrNum = new int[3];

            // GetType()을 호출하지 않았지만 요소가 없기 때문인지 System.Int32[] 출력
            Console.WriteLine(arrNum);
            // 3으로 길이 출력, 즉 길이 3 배열이 선언된 건 맞음
            Console.WriteLine(arrNum.Length);

            // 배열에서 인덱스로 접근 == 각각의 요소에 접근하고 수동으로 값 대입한다면
            arrNum[0] = 1;
            arrNum[1] = 2;
            arrNum[2] = 3;

            for (int i = 0; i < arrNum.Length; i++)
            {
                arrNum[i] = i + 3;
                Console.WriteLine(arrNum[i]);
            }

            // 생각 외로 요소 대입 후에도 arrNum은 타입만 반환
            Console.WriteLine(arrNum);
            Console.WriteLine(arrNum.GetType());

            // string.Join("구분 기호", "출력할 배열");
            // 배열을 순회하면서 각 요소를 출력하되, 구분 기호와 함께 출력함
            Console.WriteLine(string.Join(", ", arrNum));
        }
    }
}
