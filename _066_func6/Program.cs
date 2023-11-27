using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _066_func6
{
    internal class Program
    {
        // int 파라미터 세 개 받고 int 반환하는 함수
        static int TotalScore(int ko, int en, int ma)
        {
            // 로컬 변수
            int totalScore;
            // 파라미터 합산
            totalScore = ko + en + ma;
            // 합산 값 리턴
            return totalScore;
        }

        static void Main(string[] args)
        {
            // 함수끼리는 사용할 스코프가 달라 변수명이 같아도 괜찮음
            int totalScore = TotalScore(80, 90, 100);
            Console.WriteLine(totalScore);
        }
    }
}
