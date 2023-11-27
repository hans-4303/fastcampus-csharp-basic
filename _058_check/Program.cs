using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _058_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성
            Random rnd = new Random();

            // 출제 숫자가 스코프마다 새로 생성되어서는 안 됨
            int questionNum = rnd.Next(0, 100);
            // 데이터 선언 및 초기화
            int answerNum;
            int tryedCount = 1;

            for(; ; )
            {
                // 입력 로직
                Console.WriteLine("0 ~ 99 사이 어떤 숫자일까요? (단 0 입력 시 나가기)");
                answerNum = Convert.ToInt32(Console.ReadLine());

                // 0 입력 시 종료
                if (answerNum == 0)
                {
                    Console.WriteLine("\n게임 종료");
                    break;
                }

                // 문제 로직
                if (answerNum == questionNum)
                {
                    Console.WriteLine("정답입니다");
                    Console.WriteLine("총 {0}번 시도\n", tryedCount);
                    break;
                }
                else if (answerNum > questionNum)
                {
                    Console.WriteLine("입력한 숫자가 더 큽니다.\n");
                    tryedCount++;
                }
                else if (answerNum < questionNum)
                {
                    Console.WriteLine("입력한 숫자가 더 작습니다.\n");
                    tryedCount++;
                }
            }
        }
    }
}
