using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _057_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성
            Random rnd = new Random();

            // 데이터 선언 및 초기화
            int answerNum;
            int answeredCount = 0;
            int firstNum;
            int secondNum;
            int trigger = 1;

            while (true)
            {
                // 스코프마다 초기화
                firstNum = rnd.Next(0, 100);
                secondNum = rnd.Next(0, 100);
                // 스코프마다 달라질 값이니까 스코프 내부에서 생성
                int sumNum = firstNum + secondNum;

                // 몇 번째 문제인지를 반복 횟수와 연계
                Console.WriteLine("{0}: 다음 두 수의 합은? (총 5문제)", trigger);
                // 문제 표시와 사용자 입력 로직
                Console.WriteLine("{0} + {1} = ??", firstNum, secondNum);
                answerNum = Convert.ToInt32(Console.ReadLine());

                // 정답 오답 모두 trigger를 올려서 반복문을 제어한다
                // 출제 숫자와 사용자 입력이 같다
                if (sumNum == answerNum)
                {
                    Console.WriteLine("== 정답 ==");
                    answeredCount++;
                    trigger++;
                }
                // 출제 숫자와 사용자 입력이 다르다
                else
                {
                    Console.WriteLine("오답 (정답은: {0})", sumNum);
                    trigger++;
                }

                // trigger == 6이면 제공된 다섯 문제를 풀었다
                if (trigger == 6)
                {
                    Console.WriteLine("수고하셨습니다.");
                    Console.WriteLine("모두 {0}문제를 맞추셨습니다.", answeredCount);
                    break;
                };
            }
        }
    }
}
