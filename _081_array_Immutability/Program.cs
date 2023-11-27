using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _081_array_Immutability
{
    internal class Program
    {
        // 불변성 지키면서 배열 수정하는 함수
        // 파라미터로 수정할 배열, 수정할 요소, 수정할 값 받음
        static int[] ModifyArray(int[] arr, int index, int value)
        {
            // "데이터 타입"[] "복사받을 배열" = ("복사할 배열 데이터 타입"[])"복사할 배열".Clone();
            int[] newArr = (int[])arr.Clone();
            // 복사한 배열에 인덱스로 접근하고 값 대입
            newArr[index] = value;
            // 새 배열 리턴
            return newArr;
        }

        static void Main(string[] args)
        {
            // 원본 배열
            int[] numbers = { 1, 2, 3 };
            // 원본 배열을 파라미터로 쓰지만 복사하기 때문에 현재 스코프에서 call by reference를 우회
            // 결과 값 배열을 변수에 할당해서 사용
            int[] modifyedNumbers = ModifyArray(numbers, 1, 300);
            // 원본 배열 != 수정된 배열
            foreach (int i in numbers) { Console.WriteLine(i); }
            foreach (int i in modifyedNumbers) { Console.WriteLine(i); }
        }
    }
}
