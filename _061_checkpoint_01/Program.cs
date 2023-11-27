using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Threading을 사용 == import
using System.Threading;

namespace _060_checkpoint_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성
            Random rnd = new Random();

            // 중복되는 내용을 상수 선언하고 호출
            const string TRACK = "---------------------------------";

            // 게임 끝을 위한 결승선 변수
            const int FINISH_LINE = 28;

            // 각 말의 진행도 변수: 화면에 꾸준히 반영하기 위해서 반복문 스코프 바깥에 선언
            int runA = 0;
            int runB = 0;
            int runC = 0;
            int runD = 0;

            // 무한 반복
            while (true)
            {
                Thread.Sleep(200); // 1초 마다 간격 주기
                Console.Clear(); // 반복 시 콘솔 창 내역을 초기화 하기 위해서

                // 진행도 변수를 증감시켜준다면 화면에 반영시켜줄 수 있다
                ++runA;
                ++runB;
                ++runC;
                ++runD;

                // 0 ~ 3까지 랜덤 변수: 스코프마다 선언과 초기화
                int rndNum = rnd.Next(0, 4);

                // 스코프마다 rndNum 값으로 진행도 조작해주기
                switch(rndNum)
                {
                    case 0:
                        ++runA;
                        break;
                    case 1:
                        ++runB;
                        break;
                    case 2:
                        ++runC;
                        break;
                    case 3:
                        ++runD;
                        break;
                }

                Console.WriteLine(TRACK);

                // 띄워쓰기가 진행이고, 이 진행을 반복적으로 할 수 있다면 된다
                // 각 말마다 반복 횟수가 다르다면 진행도 차이를 나타낼 수 있다
                for (int i = 0; i < runA; i++) Console.Write(" ");
                Console.Write("1");

                // 역으로 for문 반복하기
                // FINISH_LINE(결승선) - run변수(진행도)만큼 반복될 것이고 반복문 스코프마다 갱신될 것
                // i가 0보다 작아질 때까지 i를 감소하고 띄워쓰기
                // 그래서 "진행도""말""결승선까지 간격""결승선"(띄우기)가 성립
                // 조절을 위해서 FINISH_LINE - 2 적용
                for(int i = (FINISH_LINE - 2) - runA; i >= 0; i--) Console.Write(" ");
                // 결승선
                Console.WriteLine("|");

                for (int i = 0; i < runB; i++) Console.Write(" ");
                Console.Write("2");
                for (int i = (FINISH_LINE - 2) - runB; i >= 0; i--) Console.Write(" ");
                Console.WriteLine("|");

                for (int i = 0; i < runC; i++) Console.Write(" ");
                Console.Write("3");
                for (int i = (FINISH_LINE - 2) - runC; i >= 0; i--) Console.Write(" ");
                Console.WriteLine("|");

                for (int i = 0; i < runD; i++) Console.Write(" ");
                Console.Write("4");
                for (int i = (FINISH_LINE - 2) - runD; i >= 0; i--) Console.Write(" ");
                Console.WriteLine("|");

                Console.WriteLine(TRACK);

                // 반복 연산된 run 변수들을 결승선 값과 비교하기
                if(runA >= FINISH_LINE || runB >= FINISH_LINE || runC >= FINISH_LINE || runD >= FINISH_LINE)
                {
                    // 우승 말 변수
                    int winnerNum = 0;
                    // 결과 출력 문자열
                    string strResult = "결과:   !! {0}번 선수 우승 !!";
                    // 조건문에 따라 우승한 말 변수 대입
                    if (runA >= FINISH_LINE) winnerNum = 1;
                    else if (runB >= FINISH_LINE) winnerNum = 2;
                    else if (runC >= FINISH_LINE) winnerNum = 3;
                    else winnerNum = 4;

                    // == "결과:   !!{0} 선수 우승 !!", winnerNum
                    Console.WriteLine(strResult, winnerNum);

                    // 반복문 제어
                    Console.WriteLine("다시 시작하려면 0번 입력: ");
                    // 조건문에서도 입력 값을 즉시 받을 수 있다
                    if ("0" == Console.ReadLine())
                    {
                        // run 변수 재설정해서 경기 시작 -> 결승선 if문 스코프에 다시 들어올 것
                        runA = 0;
                        runB = 0;
                        runC = 0;
                        runD = 0;
                    }
                    // 조건에 맞지 않는 값 넣었다면 반복문 전체 스코프 끝내기
                    else break;
                }
            }
        }
    }
}
