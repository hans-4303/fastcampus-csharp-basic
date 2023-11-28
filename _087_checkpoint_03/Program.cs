using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// 배열과 달리기 게임
// 2차원 배열을 활용: 행과 열 내지는 y축과 x축 좌표로 생각할 수 있음
// 게임의 맵 내지 타일 개념과 같다 볼 수 있음

// 공백으로 출력이 아니라 실제 숫자 데이터들을 이동시키는 과정
// 2차원 배열의 인덱스에 값을 할당하고 나머지 요소는 0으로 할당하면 경기 화면과 같게 할 수 있음
// 1 0 0 0 -> 0 1 0 0 ...
namespace _087_checkpoint_03
{
    internal class Program
    {
        const int DELAY_TIME = 300;

        static void UpdateView(char[] _tile, int[,] _map)
        {
            // 2차원 배열 반복
            // 현재는 해당 문자열이 전부 전개되었다 볼 수 있음
            // y축만큼 반복하는 스코프 -> 하위 스코프로 진행
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                // x축만큼 반복하는 스코프
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    // map[i, j] == 0 || 1 || 2 || ... 등 map 요소의 값 하나가 됨
                    int tileIndex = _map[i, j];
                    // tile 배열에 인덱스로 접근하고 콘솔로 작성
                    Console.Write(_tile[tileIndex]);

                    // x축의 인덱스 최대 값까지 왔을 때 띄우기
                    if (j == _map.GetLength(1) - 1) Console.WriteLine();
                }
            }
        }

        // 
        static void ClearView()
        {
            Thread.Sleep(DELAY_TIME);
            Console.Clear();
        }

        /// <summary>
        /// 경기를 진행 시켜주는 함수
        /// </summary>
        /// <param name="_runningPlayers"></param>
        /// <param name="_map"></param>
        static void MatchingView(int[] _runningPlayers, int[,] _map)
        {
            // 반복문을 통해 선수 배열 움직이기
            for (int i = 0; i < _runningPlayers.Length; i++)
            {
                // i + 1 값 대입: 트랙을 제외하기 위해
                int countingPlayer = i + 1;
                // 선수 배열 중 i번째 요소에 접근하기 -> 1 ~ 5번 선수
                int runningPlayer = _runningPlayers[i];

                // 맵에서 트랙을 제외한 다른 차원 및 i번째 선수에 접근하기
                int temp = _map[countingPlayer, runningPlayer];
                _map[countingPlayer, runningPlayer + 1] = temp;
                _map[countingPlayer, runningPlayer] = 0;

                // 반복 조건은 다른 함수에서 정리
                _runningPlayers[i]++;
            }
        }

        static bool IsFinished(int[] _runningPlayers)
        {
            bool trigger = false;
            for (int i = 0; i < _runningPlayers.Length; i++)
            {
                // 플레이어 중 하나가 21과 같거나 커졌다면
                // -> 이 값을 20으로 넘기면 될 거다, 그런데 이유는 모르겠음
                // 이후 결승선 표시를 위해 19까지 변경됨
                if (_runningPlayers[i] >= 19)
                {
                    trigger = true;
                    // 물론 이 break는 for문 스코프에 대한 break임
                    // while문에 대한 break가 아니라서 while문 스코프는 계속 돌 것
                    // 따라서 에러 없이 경기 끝낼 로직이 준비된 건 아님
                    break;
                }
            }
            return trigger;
        }

        static void HeadingPlayerView(Random _rnd, int[] _runningPlayers, int[,] _map)
        {
            int headingPlayer = _rnd.Next(0, 5);
            // 앞서나갈 플레이어의 현재 위치 값, 0 ~ 4 방식으로 쓴 이유
            int headingPlayerPlace = _runningPlayers[headingPlayer];

            // map에서 코스 == map[1, ...]를 제외하고 앞서나갈 플레이어의 타일 반환
            int temp = _map[headingPlayer + 1, headingPlayerPlace];
            // 맵 중 앞서나갈 플레이어가 있는 트랙(== 차원)을 찾고 다음 타일을 플레이어 타일로 대입
            _map[headingPlayer + 1, headingPlayerPlace + 1] = temp;
            // 맵 중 앞서나갈 플레이어가 있는 트랙(== 차원)을 찾고 현재 타일을 0으로 대입
            _map[headingPlayer + 1, headingPlayerPlace] = 0;

            // 전체 플레이어 중 앞서나갈 플레이어 인덱스에 접근해 증가시켜주기
            _runningPlayers[headingPlayer]++;
        }

        static void ReMatching(int[] _runningPlayers, int[,] _map)
        {
            for(int i = 0; i < _runningPlayers.Length; i++)
            {
                int track = i + 1;

                _map[track, _runningPlayers[i]] = 0;
                _runningPlayers[i] = 0;
                _map[track, 20] = 2;
                _map[track, 0] = track + 2;
            }
        }

        static void Main(string[] args)
        {
            // 인스턴스 생성
            Random rnd = new Random();

            // 배열 선언: 요소와 인덱스
            char[] tile = { ' ', '-', '|', '1', '2', '3', '4', '5' };

            // 25 * 7개 맵이 있다 생각할 수 있음
            int[,] map = new int[7, 22]
            {
                // 배열의 요소들은 숫자로 명시했는데, tile 배열의 인덱스와 대조하기 위함
                // 그래서 1, 1, 1, 1, ...는 실제  ------로 바뀔 수 있음
                //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 0
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0}, // 1
                { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0}, // 2
                { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0}, // 3
                { 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0}, // 4
                { 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0}, // 5
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 6
            };

            // 움직일 말들의 인덱스를 알아야 주행한 거리 및 결과 파악 용이
            int[] runningPlayers = { 0, 0, 0, 0, 0 };

            bool matchFinished;

            // 무한 반복 스코프
            while (true)
            {
                MatchingView(runningPlayers, map);
                matchFinished = IsFinished(runningPlayers);
                HeadingPlayerView(rnd, runningPlayers, map);
                UpdateView(tile, map);
                // 스코프 안에서 요소를 움직일 수 있다면 동적으로 값을 바꾸고 있다고도 할 수 있음
                // 하지만 요소 변경 시 인덱스를 저장하지 않으면 어떤 인덱스가 어디로 달려가고 있다 인지하거나 활용하기 어려움
                // 저장, 불변성이 필요해질 수 있다

                // 경기가 끝났을 때 while 스코프 종료
                // 동시에 경기 끝났을 때 결과를 모니터링 해줄 수 있다면?
                if (matchFinished == true)
                {
                    Console.WriteLine();

                    for (int i = 0; i < runningPlayers.Length; i++)
                    {
                        if (runningPlayers[i] >= 19)
                        {
                            Console.Write("달리기 결과: 1등: {0}", (i + 1));
                            break;
                        }
                    }

                    Console.WriteLine("다시 시작하려면 0을 입력");
                    string isReMatch = Console.ReadLine();

                    // 값들 == 타일들을 초기화 시켜주는 로직
                    if(isReMatch == "0")
                    {
                        ReMatching(runningPlayers, map);
                    }
                    else break;
                }
                ClearView();
            }
        }
    }
}