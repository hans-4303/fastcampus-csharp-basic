using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _073_check
{
    internal class Program
    {
        // 콘솔에 출력문 남김
        static void Start() { Console.WriteLine("성적 프로그램"); }

        // ref를 통해 메인 함수 스코프에서도 변할 수 있는 파라미터를 받음
        static void Input(ref int ko, ref int ma, ref int en)
        {
            // 입력 로직을 통해 메인 함수 스코프의 변수에 대입
            Console.Write("국어 점수 입력(정수): ");
            ko = Convert.ToInt32(Console.ReadLine());
            Console.Write("수학 점수 입력(정수): ");
            ma = Convert.ToInt32(Console.ReadLine());
            Console.Write("영어 점수 입력(정수): ");
            en = Convert.ToInt32(Console.ReadLine());

            // 점수 입력 끝
            Console.WriteLine("{0} {1} {2}", ko, ma, en);
        }

        // 파라미터 값을 합산
        static int TotalSum(int ko, int ma, int en) { return ko + ma + en; }

        // 총합을 특정 분모로 나누어 out으로 메인 함수 스코프까지 전달함
        static void Average(int total, out float average) { average = (float)total / 3; }

        static void Main(string[] args)
        {
            // ref 키워드 활용 변수라서 선언과 초기화 필수
            int ko = 0;
            int ma = 0;
            int en = 0;
            // 반환 값만 쓰면 되니까 선언만 해도 됨
            int total;
            // out 키워드 활용 변수라서 선언만 해도 됨
            float average;

            // 순서대로 동작
            Start();
            Input(ref ko, ref ma, ref en);
            total = TotalSum(ko, ma, en);
            Average(total, out average);

            Console.WriteLine("{0} {1}", total, average);
        }
    }
}
