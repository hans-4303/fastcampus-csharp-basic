using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _118_Check
{
    public class CSaveNumber
    {
        private int a;
        private int b;

        public CSaveNumber ()
        {
            a = 0;
            b = 0;
        }

        public void InputNumber (int count)
        {
            if (count == 0)
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

        public void PrintResult ()
        {
            Console.Write("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static bool CheckEnd (int hashtableCount)
        {
            Console.Write("{0}번째 추가로 계산할까요(1: OK, 0: No)", ( hashtableCount ));

            int temp = int.Parse(Console.ReadLine());
            bool isEnd = temp == 0;

            return isEnd;
        }

        /// <summary>
        /// <para>Hashtable을 사용한 케이스</para>
        /// <para>
        ///     카운트 변수 만드는 건 같으며 Hashtable을 생성
        ///     while문 스코프 안에서 인스턴스를 생성하고 메서드를 호출하되,
        ///     스코프 바깥 Hashtable에 키와 인스턴스를 대입함.
        /// </para>
        /// <para>
        ///     saveNumbersTable[0 == key] = CSaveNumber(a, b, methods)
        ///     saveNumbersTable[1 == key] = CSaveNumber(a, b, methods)
        ///     과 같이 누적됨.
        /// </para>
        /// <para>
        ///     CheckEnd 메서드의 인수는 Hashtable의 Count가 되어 크게 의미는 없음,
        ///     foreach문 안에서 Hashtable의 Keys를 순회하면서
        ///     각 인스턴스를 받아오고 캐스팅 -> 메서드를 사용해줌
        ///     * 캐스팅 과정이 들어가야 클래스와 메서드를 인지할 수 있는 걸로 보임.
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            int indexCount = 0;
            Hashtable saveNumbersTable = new Hashtable();

            while (true)
            {
                CSaveNumber temp = new CSaveNumber();
                temp.InputNumber(0);
                temp.InputNumber(1);

                temp.PrintResult();
                saveNumbersTable.Add(indexCount, temp);

                indexCount++;

                if (CheckEnd(saveNumbersTable.Count))
                {
                    foreach (object key in saveNumbersTable.Keys)
                    {
                        CSaveNumber saveNumbers = (CSaveNumber) saveNumbersTable[key];
                        saveNumbers.PrintResult();
                    }
                    break;
                }
            }
        }

        /**
         * ArrayList를 사용한 케이스
         * ArrayList는 키 외의 인덱스를 가지지 않으니까 이쪽이 더 간결함
         * static void Main(string[] args) {
            ArrayList saveNumbers = new ArrayList();//CSaveNumber[] saveNumbers = new CSaveNumber[10];

            while(true) {
                CSaveNumber temp = new CSaveNumber();
                temp.InputNumber(0);
                temp.InputNumber(1);

                temp.PrintResult();

                saveNumbers.Add(temp);

                if(CheckEnd(saveNumbers.Count)) {
                    foreach(CSaveNumber data in saveNumbers) {
                        data.PrintResult();
                    }
                    break;
                }
            }
        }
         */
    }
}
