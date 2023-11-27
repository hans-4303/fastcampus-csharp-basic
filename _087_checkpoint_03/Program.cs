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

        static void Main(string[] args)
        {
            // 배열 선언: 요소와 인덱스
            char[] tile = { ' ', '-', '|', '1', '2', '3', '4', '5' };

            // 25 * 7개 맵이 있다 생각할 수 있음
            int[,] map = new int[7, 22]
            {
                // 배열의 요소들은 숫자로 명시했는데, tile 배열의 인덱스와 대조하기 위함
                // 그래서 1, 1, 1, 1, ...는 실제  ------로 바뀔 수 있음
                //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 0
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1
                { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2
                { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3
                { 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4
                { 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 6
            };

            int[] arrIndexX = { 0, 1, 2, 3, 4 };

            // 정적으로 선언한 방법
            map[1, 1] = 3;
            map[1, 2] = 3;

            // 무한 반복 스코프
            while (true)
            {
                UpdateView(tile, map);
                // 스코프 안에서 요소를 움직일 수 있다면 동적으로 값을 바꾸고 있다고도 할 수 있음
                // 하지만 요소 변경 시 인덱스를 저장하지 않으면 어떤 인덱스가 어디로 달려가고 있다 인지하거나 활용하기 어려움
                // 저장, 불변성이 필요해질 수 있다
                map[1, 1] = 3;
                map[1, 2] = 3;
                ClearView();
            }
        }
    }
}
