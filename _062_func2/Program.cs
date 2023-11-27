using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _062_func2
{
    internal class Program
    {
        // 리턴형을 갖는 함수
        static int Add()
        {
            int a = 0;
            // 외부 파라미터 값을 쓰든, 스코프 내에서 변수를 생성하든 리턴형에 맞게 리턴해줘야 함
            return ++a;
        }

        static int PrintSeven()
        {
            int a = 7;
            return a;
        }

        static int PrintImmidiately() { return 100; }

        static int InputNum()
        {
            Console.Write("정수를 넣어주세요. ");
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        static void Main(string[] args)
        {
            int num = 2;
            // Add() -> local int a = 0; return ++a; -> num == 2 + a == 1
            num += Add();
            // 결과 값 3
            Console.WriteLine(num);

            // 반환 값 있는 함수들도 단독으로 호출할 수는 있음
            PrintSeven();

            // 하지만 함수를 호출해서 반환 값을 변수에 할당하는 게 적절함
            // 로컬 변수 생성하고 반환
            int numSeven = PrintSeven();
            Console.WriteLine(numSeven);

            // 리턴에서 반환 값 즉시 달아주기도 가능
            int numImmidiately = PrintImmidiately();
            Console.WriteLine(numImmidiately);

            Console.WriteLine("입력하신 정수는 {0}", InputNum());
        }
    }
}
