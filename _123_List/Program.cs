using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123_List
{
    internal class Program
    {
        /// <summary>
        /// <para>List: T(제네릭)을 사용하는 컬렉션 중 하나</para>
        /// <para>
        ///     List: int, float, string 등을 적고 있어서 몰랐지만
        ///     List는 실제로 제네릭을 사용하고 있는 자료 구조라 볼 수 있음
        ///     한 List에 여러 형식을 저장할 수는 없고,
        ///     다른 컬렉션을 만들거나 다수의 List: T를 만드는 게 일반적임
        /// </para>
        /// </summary>
        private static void Main ()
        {
            List<int> ListAA = new List<int>();
            ListAA.Add(1);
            ListAA.Add(2);

            for (int i = 0; i < 10; i++)
            {
                ListAA.Add(i);
            }

            foreach (var data in ListAA)
            {
                Console.WriteLine("data: " + data);
            }

            Console.WriteLine("\n배열데이터로 초기화");
            string[] arrData = { "AA", "BB", "CC" };
            List<string> listArr = new List<string>(arrData);

            for (int i = 0; i < arrData.Length; i++)
            {
                Console.WriteLine("arrData: " + arrData[i]);
            }
        }
    }
}
