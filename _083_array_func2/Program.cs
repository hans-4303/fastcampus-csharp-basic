using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _083_array_func2
{
    internal class Program
    {
        // 배열 길이와 초기 값을 갖는 함수로 작성
        static int[] CreateIntArray(int size, int initValue)
        {
            // 길이만큼 배열 생성
            int[] creArray = new int[size];
            // == i < creArray.Length;
            for(int i = 0; i < size; i++)
            {
                // 배열 순회하면서 초기 값 대입
                creArray[i] = initValue;
            }
            // 배열 리턴
            return creArray;
        }

        // 방식은 위와 같음
        static string[] CreateStrArray(int size, string initValue)
        {
            string[] creArray = new string[size];
            for (int i = 0; i < size; i++)
            {
                creArray[i] = initValue;
            }
            return creArray;
        }

        // 형식은 비슷하나 for문 중첩으로 2차원 배열 생성
        static int[,] CreateTwoDimensionArray(int row, int column, int initValue)
        {
            int[,] array = new int[row, column];
            for(int i = 0; i < row;i++)
            {
                for (int j = 0; j < column; j++) array[i, j] = initValue;
            }
            return array;
        }

        static void Main(string[] args)
        {
            // 함수들 호출하고 반환해서 변수에 할당
            int[] arrNum = CreateIntArray(3, 50);
            string[] strName = CreateStrArray(5, "hello");
            int[,] arrMultyNum = CreateTwoDimensionArray(3, 2, 10);

            // foreach로 출력
            foreach(int i in arrNum) Console.Write(i);
            Console.WriteLine();
            foreach (string str in strName) Console.Write(str);
            Console.WriteLine();
            foreach (int i in arrMultyNum) Console.Write(i);
            Console.WriteLine();

            // 배열 클론 메서드: 불변성 유지에 도움
            // 단 Clone 함수는 다형성 때문에 object 타입으로 반환함
            // 사용을 위해서는 캐스팅 등이 필요함
            int[] clonedArr = (int[])arrNum.Clone();

            // Array.Clear("초기화할 배열", "초기화 시작할 인덱스", "초기화 할 요소 갯수");
            Array.Clear(arrNum, 1, 2);
            foreach (int i in arrNum) Console.Write(i);
            Console.WriteLine();

            // 기대한 대로 특정 시점의 배열 사본이 생성됨
            // 활용 시 불변성도 지킬 수 있음
            foreach (int i in clonedArr) Console.Write(i);
            Console.WriteLine();

            // "선택한 배열".Length;
            // 가르킨 배열 길이 반환 받기
            Console.WriteLine(arrNum.Length);

            // "선택한 배열".GetLength("배열의 차원수(0부터 시작하고 내림차순)")
            Console.WriteLine(arrNum.GetLength(0));
            // 런타임 에러: int 값을 넣을 때 해당 차원 배열이 있어야 함
            // Console.WriteLine(arrNum.GetLength(1));

            // 다차원 배열에서 사용하기 좋음
            // 인덱스 0: 2차원
            Console.WriteLine(arrMultyNum.GetLength(0));
            // 인덱스 1: 1차원
            Console.WriteLine(arrMultyNum.GetLength(1));
        }
    }
}
