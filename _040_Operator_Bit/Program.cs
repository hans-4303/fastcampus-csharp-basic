using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _041_Operator_Bit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // == 0000 0000 0000 0000 0000 0000 0000 1111
            int a = 15;
            // == 0000 0000 0000 0000 0000 0000 0001 0110
            int b = 22;

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 두 값을 비트로 풀어서 자리 수를 비교하고 각 자리 수에 동시에 1이 있다면 새로 할당하여 반환
            // == 0000 0000 0000 0000 0000 0000 0110: 동시에 성립하는 부분은 0110 뿐임
            int c = a & b;
            Console.WriteLine(c);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 두 값을 비트로 풀어서 자리 수를 비교하고 한 값이라도 각 자리 수에 1이 있다면 할당해나가며 반환
            // == 0000 0000 0000 0000 0000 0000 0001 1111
            int d = a | b;
            Console.WriteLine(d);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 두 값을 비트로 풀어서 자리수를 비교하는 데, 두 값의 각 자리 수가 달라야 1을 할당해나가며 반환
            // 0000 0000 0000 0000 0000 0000 0001 1001
            int e = a ^ b;
            Console.WriteLine(e);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 해당 값을 비트로 풀고, << 뒤의 값 만큼 해당 비트 값을 우에서 좌로 밀어내며 공백은 0으로 채움
            // 0000 0000 0000 0000 0000 0000 0011 1100
            int f = a << 2;
            Console.WriteLine(f);

            // 왼쪽으로 1 시프트 하면 2배로 증가하는 것과 같음(곱셈 연산)
            // 0000 0000 0000 0000 0000 0000 0111 1000
            int g = f << 1;
            Console.WriteLine(g);

            // 오른쪽으로 1 시프트 하면 절반으로 감소하는 것과 같음(나눗셈 연산)
            int h = g >> 1;
            Console.WriteLine(h);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 해당 값을 비트로 풀고, >> 뒤의 값 만큼 해당 비트 값을 좌에서 우로 밀어내며 공백은 0으로 채움
            // 0000 0000 0000 0000 0000 0000 0011 1100
            int i = g >> 2;
            Console.WriteLine(i);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 해당 값을 비트로 풀어서 0과 1을 반전 시킴
            // 1111 1111 1111 1111 1111 1111 1110 1001
            int j = (~b);
            Console.WriteLine(j);

            // ???? ???? ???? ???? ???? ???? ???? ????
            // -> 해당 값을 비트로 풀어서 해당 비트 값을 좌에서 우로 밀어내는데, 음수인 경우 밀어낸 공백은 1로 채워짐
            // 1111 1111 1111 1111 1111 1111 1111 1010
            int k = j >> 2;
            Console.WriteLine(k);

            // 비트로 출력하기
            // Convert.ToString("출력할 값", 2(비트가 2진법이기 때문)).PadLeft(왼쪽으로 여백 채우는 메서드)(32(4바이트 정수는 32자리 비트를 갖기 때문), '0');
            string s1 = Convert.ToString(a, 2).PadLeft(32, '0');
            Console.WriteLine(s1);
            string s2 = Convert.ToString(b, 2).PadLeft(32, '0');
            Console.WriteLine(s2);

            // 음수를 비트로 출력 시도
            string s3 = Convert.ToString(j, 2).PadLeft(32, '1');
            Console.WriteLine(s3);
        }
    }
}
