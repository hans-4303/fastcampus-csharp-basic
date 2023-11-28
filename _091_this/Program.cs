using System;

namespace _091_this
{
    public class AA
    {
        // 필드 값 a;
        private int a;

        /// <summary>
        /// 파라미터로 정수 a를 받는 생성자: 필드 값 a에 대입해줌 
        /// </summary>
        /// <param name="a"></param>
        public AA(int a)
        {
            this.a = a;
        }

        /// <summary>
        /// 로컬 변수를 사용하는 메서드, 이때 this.a와 로컬 변수 a는 다르게 취급되므로 중복된 초기화 등 문제 없이 사용 가능
        /// </summary>
        public void Print()
        {
            int a = 100;
            this.a = 1000;

            Console.WriteLine("{0}, {1}", a, this.a);
            if (a != this.a) { Console.WriteLine("로컬 변수와 필드 값은 this 키워드로 구별할 수 있다"); }
        }
    }

    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA(10);
            aa.Print();
        }
    }
}
