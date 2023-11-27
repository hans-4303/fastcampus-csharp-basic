using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _055_iteration_loop_continue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i == 10일 때 for문 끝나고, 0부터 9까지 10번 호출됨
            for(int i = 0; i < 10; i++)
            {
                // i == 5일 때
                if (i == 5)
                {
                    // 줄은 바꾸고
                    Console.WriteLine();
                    // continue; 로 이번 스코프를 종료함
                    continue;
                }
                // i == 5일 때 조건문과 continue로 인해 실행되지 않음
                // 이미 해당 스코프가 종료되었으니까
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // for문 스코프 바깥에서 대입할 값
            int total = 0;

            // i == 10일 때 종료되고 0부터 9까지 10번 반복
            for (int i = 0; i < 10; i++)
            {
                // 만약 i % 2 == 1, 그래서 홀수라면
                if(i % 2 == 1)
                {
                    // continue로 이번 스코프를 종료함
                    continue;
                }
                // i 값을 total에 계속 더해감
                total += i;
                // i 값을 출력해봄
                Console.WriteLine(i);
            }
            // i % 2 == 0인 값들만 total에 계속 더해지고 있음
            Console.WriteLine(total);
        }
    }
}
