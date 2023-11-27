using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _046_handling_switch
{
    internal class Program
    {
        // enum은 메인 메서드가 아니라 클래스 단위에서 생성
        enum DAY_OF_WEEK
        {
            SUN,
            MON,
            TUE,
            WED,
            THU,
            FRI,
            SAT
        }

        static void Main(string[] args)
        {
            // 현재 클래스 안에 있는 enum은 타입으로써 사용할 수 있다
            DAY_OF_WEEK thisDayOfWeek = DAY_OF_WEEK.FRI;
            string dayString = "";

            // 값 사용
            switch(thisDayOfWeek)
            {
                // case thisDayOfWeek == DAY_OF_WEEK.SUN과 같음
                case DAY_OF_WEEK.SUN:
                    dayString = "일";
                    break;
                case DAY_OF_WEEK.MON:
                    dayString = "월";
                    break;
                case DAY_OF_WEEK.TUE:
                    dayString = "화";
                    break;
                case DAY_OF_WEEK.WED:
                    dayString = "수";
                    break;
                case DAY_OF_WEEK.THU:
                    dayString = "목";
                    break;
                case DAY_OF_WEEK.FRI:
                    dayString = "금";
                    break;
                case DAY_OF_WEEK.SAT:
                    dayString = "토";
                    break;
                default:
                    dayString = "적합한 요일이 입력되지 않았습니다.";
                    break;
            }
            Console.WriteLine(dayString);
        }
    }
}
