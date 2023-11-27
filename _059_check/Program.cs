using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _059_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 데이터 선언
            // 최대 점수는 0부터 시작, 최소 점수는 100부터 시작
            int maxScore = 0;
            int minScore = 100;
            // 입력 변수
            int inputScore;
            // 반복할 횟수
            int tryedCount = 0;

            for(; ; )
            {
                // 횟수 == 5라면 종료 로직
                if (tryedCount ==  5)
                {
                    Console.WriteLine("최대값: {0}, 최소값: {1}", maxScore, minScore);
                    break;
                }

                // 입력 및 비교 로직
                Console.WriteLine("학생의 성적을 입력하세요: ");
                inputScore = Convert.ToInt32(Console.ReadLine());

                // 삼항 연산자로 비교하고 최대 최소 값에 할당
                maxScore = maxScore < inputScore ? inputScore : maxScore;
                minScore = minScore > inputScore ? inputScore : minScore;

                // 시도 횟수 증가
                tryedCount++;
            }
        }
    }
}
