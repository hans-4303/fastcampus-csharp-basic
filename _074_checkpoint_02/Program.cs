using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _074_checkpoint_02
{
    // 여러 함수의 집합으로 프로그램을 구성할 때는 class 단을 사용하는 것도 좋음
    internal class Program
    {
        // class 단에서 자주 사용하는 상수 및 변수 선언
        const string TRACK = "---------------------------------";
        const int FINISH_LINE = 28;
        const int DELAY_TIME = 200;

        static int runA = 0;
        static int runB = 0;
        static int runC = 0;
        static int runD = 0;

        // 호출 시 화면을 초기화 해주는 함수 하나로 정리됨
        static void Refresh()
        {
            Thread.Sleep(DELAY_TIME); // 1초 마다 간격 주기
            Console.Clear(); // 반복 시 콘솔 창 내역을 초기화 하기 위해서
        }

        static void PlayersRunning(Random rnd)
        {
            // 진행도 변수를 증감시켜준다면 화면에 반영시켜줄 수 있다
            ++runA;
            ++runB;
            ++runC;
            ++runD;

            // 0 ~ 3까지 랜덤 변수: 스코프마다 선언과 초기화
            int rndNum = rnd.Next(0, 4);

            // 스코프마다 rndNum 값으로 진행도 조작해주기
            switch (rndNum)
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
        }

        static void CurrentMatch()
        {
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
            for (int i = (FINISH_LINE - 2) - runA; i >= 0; i--) Console.Write(" ");
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
        }

        static bool DefineWinnerAndReMatch()
        {
            // 반복 연산된 run 변수들을 결승선 값과 비교하기
            if (runA >= FINISH_LINE || runB >= FINISH_LINE || runC >= FINISH_LINE || runD >= FINISH_LINE)
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

                    return true;
                }
                // 조건에 맞지 않는 값 넣었다면 반복문 전체 스코프 끝내기
                else return false;
            }
            return true;
        }

        // 함수가 승자 결정 하나만 수행할 수 있도록 하기 위해 분리
        // int 형으로 승자 값을 반환하도록 함
        // 승자 값이 결정되지 않았다면 0을 리턴해서 조건으로 활용
        static int DefineWinner()
        {
            if (runA >= FINISH_LINE || runB >= FINISH_LINE || runC >= FINISH_LINE || runD >= FINISH_LINE)
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
                return winnerNum;
            }
            else return 0;
        }

        // 함수가 재경기 여부 하나만 결정지을 수 있도록 분리
        // bool 형으로 재경기 여부를 반환하도록 함
        // 재경기 조건을 위한 입력이 없을 시 false를 리턴해서 조건으로 활용
        static bool IsReMatch()
        {
            Console.WriteLine("다시 시작하려면 0번 입력: ");
            // 조건문에서도 입력 값을 즉시 받을 수 있다
            if ("0" == Console.ReadLine())
            {
                // run 변수 재설정해서 경기 시작 -> 결승선 if문 스코프에 다시 들어올 것
                runA = 0;
                runB = 0;
                runC = 0;
                runD = 0;

                return true;
            }
            // 조건에 맞지 않는 값 넣었다면 반복문 전체 스코프 끝내기
            else return false;
        }

        static void Main(string[] args)
        {
            // 인스턴스 생성
            Random rnd = new Random();            

            // 무한 반복
            while (true)
            {
                // 화면을 일정 간격마다 클리어
                Refresh();

                // 플레이어들이 랜덤하게 주행: 인스턴스 넘겨주기
                PlayersRunning(rnd);

                // 현재 경기 내용
                CurrentMatch();

                // 만약 플레이어들이 결승선에 도착하지 못해 return이 0이면 continue;
                // 반복문 스코프를 끝내지는 않고 다음 반복을 하기 위함
                // 승자 결정되어 return != 0 이라면 if문이 충족되지 않아 else if문으로 전환
                // 반복문 스코프를 끝내지는 않고 continue로 다음 횟수를 반복
                if (DefineWinner() == 0) continue;

                // 위 상황에서 승자 결정과 출력은 끝났고, 재경기를 결정함
                // 입력 로직에서 0을 입력받을 시 재경기 로직이 진행되며 return true로 인해 조건 미충족
                // 0 이외를 입력받을 시 return false로 인해 조건을 충족하고 break;로 반복문 스코프 끝내기
                else if (IsReMatch() == false) break;
            }
        }
    }
}
