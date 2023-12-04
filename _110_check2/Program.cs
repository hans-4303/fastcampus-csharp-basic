using System;

namespace _110_check2
{
    public class CSaveNumber
    {
        private int a;
        private int b;

        public CSaveNumber()
        {
            a = 0;
            b = 0;
        }

        public void InputNumber(int count)
        {
            if(count == 0)
            {
                Console.Write("첫번째 수를 입력하세요.");
                a = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("두번째 수를 입력하세요.");
                b = int.Parse(Console.ReadLine());
            }
        }

        public void PrintResult()
        {
            Console.Write("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static bool CheckEnd(int index)
        {
            Console.Write("{0}번째 추가로 계산할까요(1: OK, 0: No, 단 총 10번까지 가능)", (index + 1));

            int temp = int.Parse(Console.ReadLine());
            bool isEnd = temp == 0;

            return isEnd;
        }

        private static void Main(/* string[] args */)
        {
            int indexCount = 0;
            CSaveNumber[] saveNumbers = new CSaveNumber[10];

            while(true)
            {
                saveNumbers[indexCount] = new CSaveNumber();
                saveNumbers[indexCount].InputNumber(0);
                saveNumbers[indexCount].InputNumber(1);

                saveNumbers[indexCount].PrintResult();

                indexCount++;

                if(indexCount >= 10 || CheckEnd(indexCount))
                {
                    for (int i = 0; i < indexCount; i++) saveNumbers[i].PrintResult();
                    break;
                }
            }
        }
    }
}
