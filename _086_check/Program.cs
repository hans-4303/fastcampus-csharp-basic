using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _086_check
{
    // 무한 반복 스코프 안에서 해결하는 프로그램
    internal class Program
    {
        // 함수 호출 당 몇 번째 입력인지 확인하고 입력 값은 반환
        static int InputNumber(int inputCount)
        {
            int temp = 0;
            if(inputCount == 0) { Console.Write("첫번째 수를 입력해주세요."); }
            else { Console.Write("두번째 수를 입력해주세요."); }
            temp = int.Parse(Console.ReadLine());
            return temp;
        }

        // 각 단계의 결과 출력
        static void PrintResult(int a, int b)
        {
            // 더하기와 숫자 등 모든 데이터를 담고 출력하는 게 아님
            // 간단히 출력문으로 끝낼 수 있음
            Console.Write("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine();
        }

        // 연산 끝낼 지 확인하는 함수
        static bool CheckEnd()
        {
            // 끝낼지 결정하는 로컬 변수
            bool isEnd = false;
            // 입력 값 받을 변수
            int temp = 0;

            // 입력 로직
            Console.Write("추가로 계산할까요(1: OK, 0: NO, 단 총 10번까지)");
            temp = int.Parse(Console.ReadLine());

            // temp 값이 0이라면 isEnd == true
            isEnd = (temp == 0);

            // true || false 값에 따라 계산을 끝내거나 스코프 진행 시키기
            return isEnd;
        }

        static void Main(string[] args)
        {
            // 요소 10개 짜리 함수
            int[] inputA = new int[10];
            int[] inputB = new int[10];

            // 각 배열의 인덱스를 담당할 변수
            int indexCount = 0;

            // 무한 반복
            while(true)
            {
                // 배열에 인덱스로 접근하고 값 입력 받기
                inputA[indexCount] = InputNumber(0);
                // 단 인수를 통해 첫번째 값인지 두번째 값인지 알아냄
                inputB[indexCount] = InputNumber(1);

                // a + b 결과, 문자열과 숫자 등 복잡하게 저장하진 않음
                PrintResult(inputA[indexCount], inputB[indexCount]);

                // 인덱스 증가하여 스코프 진행 시 반영됨
                indexCount++;

                // 인덱스 == 10 이거나(인덱스 == 9가 최대)
                // Checkend() 반환 값으로 true를 받았다면
                if(indexCount >= 10 || CheckEnd())
                {
                    // 현재 스코프의 인덱스만큼 반복
                    for(int i = 0; i < indexCount; i++)
                    {
                        // a + b 결과 출력
                        PrintResult(inputA[i], inputB[i]);
                    }
                    // 반복 스코프 종료
                    break;
                }
            }
        }
    }
}
