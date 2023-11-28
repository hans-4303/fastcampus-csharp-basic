using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _092_static
{
    public class AA
    {
        public static int a;
        public static int b;
        public static readonly int c = 200;

        public static void Print()
        {
            Console.WriteLine("{0}, {1}", a, b);
        }
    }

    public class BB
    {
        public int a;
        public int b;

        public void Print()
        {
            Console.WriteLine("{0}, {1}", a, b);
        }
    }

    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA.a = 10;
            AA.b = 100;
            // readonly 이므로 생성자 함수 이외 변경은 안 됨
            // AA.c = 300;
            Console.WriteLine(AA.c);

            AA.Print();

            // static 키워드 없으므로 클래스 자체에 접근하는 개념이 없음
            // BB.a;
            // BB.b;
            // BB.Print();

            // 인스턴스 생성과 필드 값 대입을 한 번에
            BB bb = new BB
            {
                a = 100,
                b = 200
            };

            bb.Print();
        }
    }
}
