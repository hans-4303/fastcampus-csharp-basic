using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Collections.immutable; : C# 9.0부터 사용 가능

namespace _028_advanced_data_reference
{
    internal class Program
    {
        // 배열 등 참조형 데이터의 불변성을 지키고 싶다할 경우
        static void Main(string[] args)
        {
            // 배열 선언과 초기화
            int[] arrNum = { 100, 200 };

            // 배열 복사 방법 1. ("데이터 타입")"복사될 배열".Clone();
            int[] arrIsItRefNum1 = (int[])arrNum.Clone();
            
            // 배열 복사 방법 2. 빈 배열 생성 및 Array.Copy 메서드 호출
            // 이때 복사 받을 배열은 new를 통해 복사될 배열 길이만큼 생성이 끝나야 함
            int[] arrIsItRefNum2 = new int[arrNum.Length];
            // Array.Copy 메서드는 단독으로 호출되고, 반환 등 하지 않음
            Array.Copy(arrNum, arrIsItRefNum2, arrNum.Length);
            
            // 배열 복사 방법 3. LINQ를 활용한 복사
            // "복사할 배열".ToArray();
            int[] arrIsItRefNum3 = arrNum.ToArray();

            // 배열 복사 방법 4. LINQ의 Select를 사용한 변환
            int[] arrIsItRefNum4 = arrNum.Select(x => x).ToArray();

            // 배열 복사 방법 5. LINQ의 Where 사용한 생성
            // 조건부로 배열을 복사할 때 사용됨
            int[] arrFiltered = arrNum.Where(x => x != 300).ToArray();

            // 배열 각각 인덱스에 접근해서 다른 값 대입
            arrIsItRefNum1[0] = 1000;
            arrIsItRefNum2[0] = 2000;
            arrIsItRefNum3[0] = 3000;
            arrIsItRefNum4[0] = 4000;
            arrFiltered[0] = 5000;

            // 원본 배열 != 복사된 배열 성립, 불변성 보존
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrIsItRefNum1[0], Object.ReferenceEquals(arrNum, arrIsItRefNum1));
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrIsItRefNum2[0], Object.ReferenceEquals(arrNum, arrIsItRefNum2));
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrIsItRefNum3[0], Object.ReferenceEquals(arrNum, arrIsItRefNum3));
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrIsItRefNum4[0], Object.ReferenceEquals(arrNum, arrIsItRefNum4));
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrFiltered[0], Object.ReferenceEquals(arrNum, arrFiltered));

            // 복사된 배열 1 != 복사된 배열 2, 역시 불변성 보존
            Console.WriteLine("{0} {1} {2}", arrIsItRefNum1[0], arrIsItRefNum2[0], Object.ReferenceEquals(arrIsItRefNum1, arrIsItRefNum2));
        }
    }
}
