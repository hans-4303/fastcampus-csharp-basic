using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _082_array_func1
{
    internal class Program
    {
        static void SwapArray(int[] array, int oriIndex, int desIndex)
        {
            // 배열의 원본 인덱스를 지정하고 해당 값을 로컬 변수
            int temp = array[oriIndex];
            // 바꿀 인덱스를 지정하고 해당 값을 원본 인덱스에 대입
            array[oriIndex] = array[desIndex];
            // 로컬 변수 값을 바꿀 인덱스에 할당
            array[desIndex] = temp;
        }

        static void Main(string[] args)
        {
            // 원본 배열 선언과 초기화
            int[] arrNum = new int[] { 1, 2, 3, 4 };
            // 원본 그대로 출력
            foreach (int i in arrNum) { Console.WriteLine(i); }

            // 함수 호출하고 배열을 넘겨서 작동
            SwapArray(arrNum, 0, 1);

            Console.WriteLine();

            // 배열을 다시 출력해봤을 때 call by reference가 일어남
            // 불변성은 깨졌다 봐도 됨
            foreach(int i in arrNum) { Console.WriteLine(i);  }
        }
    }
}
