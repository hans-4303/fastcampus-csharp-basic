using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _076_array_init2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum1 = new int[3];
            int[] arrNum2 = new int[3];

            int[] arrNum3 = new int[] { 0, 1, 2 };
            int[] arrNum4 = new int[3] { 3, 4, 5 };
            int[] arrNum5 = { 0, 1, 2 };

            string[] arrWeek = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            Array.Clear(arrNum1, 0, arrNum1.Length);
            for(int i = 0; i < arrNum1.Length; i++)
            {
                arrNum1[i] = i;
            }

            for(int i = 0; i < arrNum1.Length; i++ )
            {
                Console.Write("{0}", arrNum1[i]);
            }
            Console.WriteLine();

            int tempCount = 0;

            foreach(int val in arrNum3)
            {
                // ref 키워드로 바꿀 수 있을까 시도했지만 불가
                // val = 1000;
                // foreach 구문에서 요소를 사용할 수는 있지만 편집은 힘들다 생각할 수 있음

                // 하지만 해당 배열의 요소가 아닌 다른 배열에 접근하는 등 과정은 다 가능함
                arrNum2[tempCount] = val + 3;
                tempCount++;
            }
            foreach(int val in arrNum2)
            {
                Console.WriteLine("{0}", val); 
            }

            foreach (int val in arrNum3) { Console.WriteLine("{0}", val); }

            foreach (string val in arrWeek) { Console.WriteLine(val); }
        }
    }
}
