using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _054_iteration_loop_break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 반복문 트리거가 될 변수, 반드시 반복문 바깥에 있어야 함
            // 반복문 안에 생성해버리면 스코프마다 선언과 초기화되기 때문에 트리거로써 부적합
            // 반복문이 제어 불가해질 수 있는 점 유의하기
            int inputNum = 0;

            // == for(;;)
            while (true)
            {
                Console.Write("(1) 구구단 ?단 출력 (2) 나가기(0번 입력)");
                // 스코프 바깥의 변수에 값을 입력해서 반환하고 컨버트
                inputNum = Convert.ToInt32(Console.ReadLine());
                // == inputNum = int.Parse(Console.ReadLine());

                // 받은 값이 0일 때
                if(inputNum == 0)
                {
                    // 종료 로직
                    Console.WriteLine("종료합니다.");
                    // break로 빠져나가기 때문에 while문 스코프를 빠져나갈 수 있음
                    break;
                }

                // 받은 값이 0이 아닐 때, * 1부터 * 9까지 진행할 수 있도록 함
                // i == 10일 때 for문이 끝나므로 * 9까지만 출력할 수 있음
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine("{0} * {1} = {2}", inputNum, i, (inputNum * i));
                }
            }
        }
    }
}
