using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _047_handling_switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            // 참조 형식은 null 값으로 초기화할 수 있음
            // 스택 영역에는 참조 형식의 주소 값이 들어가며 힙 영역에는 값이 없는 상태
            string strGrade = null;

            // 입력 로직
            Console.Write("점수를 입력하세요: ");
            num = int.Parse(Console.ReadLine());

            // 등급 컷 변수
            int gradeCut = num / 10;

            // switch문
            switch(gradeCut)
            {
                // == case gradeCut == 10:
                case 10:
                case 9:
                    strGrade = "A";
                    break;
                case 8:
                    strGrade = "B";
                    break;
                case 7:
                    strGrade = "C";
                    break;
                case 6:
                    strGrade = "D";
                    break;
                default:
                    strGrade = "F";
                    break;
            }
            Console.Write("{0}", strGrade);
        }
    }
}
