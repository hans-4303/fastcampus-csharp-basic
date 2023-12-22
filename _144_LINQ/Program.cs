using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _144_LINQ
{
    internal class Program
    {
        /// <summary>
        /// <para>LINQ 입문</para>
        /// <para>1. 순회할 수 있는 데이터를 둠</para>
        /// <para>2. Query와 비슷한 문법으로 데이터를 순회함</para>
        /// <para>
        ///     a. var || IEmuerable(데이터 타입) 식별자 : 순회한 데이터들을 담을 변수
        ///     b. from "순회할 요소" in "순회할 데이터" : 순회할 요소에 대해 식별자를 두고,
        ///     어디에서 순회할 지 정함
        ///     c. where "순회할 요소와 관련된 조건" : 요소를 순회할 때 어떤 조건을 기준으로 고를 지 정할 수 있음
        ///     d. select "순회한 요소" : 순회가 끝난 요소들을 지정하고 반환함
        /// </para>
        /// </summary>
        private static void Main ()
        {
            int[] data = new int[] { 0, 54, 98, 102, 332 };

            // IEnumerable<int> QueryData =
            var QueryData = 
                from el in data
                where el < 100 // if (temp < 100)
                select el;

            var test = from temp in data
                       select temp;

            foreach (int n in QueryData)
            {
                Console.WriteLine("QueryData: " + n);
            }

            foreach (int n in test)
            {
                Console.WriteLine("TestData: " + n);
            }

            //람다식 사용과 비교..
            List<int> listData = new List<int>(data);
            List<int> findAllData = listData.FindAll(a => a < 100);

            foreach (int n in findAllData)
            {
                Console.WriteLine("findAllData: " + n);
            }
        }
    }
}
