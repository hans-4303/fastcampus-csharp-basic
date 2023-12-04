using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025_data_ToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 원본 데이터 선언
            int a = 100;
            float b = 3.14159332132123f;
            decimal c = 3.14159332132123m;

            // ToString 메서드로 형변환
            string strA = a.ToString();
            string strB = b.ToString();
            string strC = c.ToString();
            
            // GetType으로 변한 데이터 타입 알아보기, 불변성 지켜졌음
            Console.WriteLine("{0} {1} {2} {3}", a, a.GetType(), strA, strA.GetType());
            Console.WriteLine("{0} {1} {2} {3}", b, b.GetType(), strB, strB.GetType());
            Console.WriteLine("{0} {1} {2} {3}", c, c.GetType(), strC, strC.GetType());
        }
        private string aaa()
        {
            string sss = string.Format("{0}-{1}-{2}", strA, b, c);
            return sss;
        }
    }
}
