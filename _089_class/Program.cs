using System;

namespace _089_class
{
    public class AA
    {
        // 멤버 변수
        // int num1; 기본적으로 private 속성: class AA 안에서만 접근할 수 있을 것이다
        private readonly int num1;
        public int num2, num3;

        public void Print()
        {
            Console.WriteLine("{0}, {1}, {2}", num1, num2, num3);
            // 역시 현재 클래스 내부에서만 private 메서드를 호출할 수 있었음
            PrintPrivate();
        }

        private void PrintPrivate()
        {
            Console.WriteLine("이 클래스 내부에서만 호출 가능: {0}, {1}, {2}", num1, num2, num3);
        }
    }

    internal class Program
    {
        private static void Main()
        {
            // new AA 생성자를 부른 뒤
            // aa.num2 = 100;
            // aa.num3 = 1000;
            // 대입해도 괜찮지만 {}를 열고 필드 값에 대입해도 같은 문법이 됨
            // 그렇다면 TypeScript의 { [key: string]: value: string | number ... }와 유사한 구조로 생각해도 되려나?
            // 혹은 그런 자료 구조가 따로 있나?
            AA aa = new AA
            {
                // 접근 한정자로서 보호 받게 되어 외부에서 접근이 안 됨(캡슐화라 봐도 되려나?)
                // aa.num1 = 10;
                num2 = 100,
                num3 = 1000
            };

            aa.Print();
            // 역시 접근 한정자로서 보호 받게 되어 외부 접근 불가
            // aa.PrintPrivate();
        }
    }
}
