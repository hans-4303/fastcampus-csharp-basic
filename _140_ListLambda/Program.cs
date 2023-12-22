using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _140_ListLambda
{
    internal class Program
    {
        /// <summary>
        /// <para>메서드 호출 시 또 다른 메서드로 처리하는 실험: 일단 성공</para>
        /// </summary>
        /// <param name="num">FindAll을 통해서 호출되는 각 요소들</param>
        /// <param name="listStandard">기준으로 잡은 숫자, 변수로 대입하거나 혹은 작성해서</param>
        /// <returns>기준보다 낮은 값이 맞는지 아닌지를 따짐</returns>
        private static bool IsLessThanStandard (int num, int listStandard)
        {
            return num < listStandard;
        }

        /// <summary>
        /// <para>List와 메서드 안의 내부 함수 + 람다식</para>
        /// <para>
        ///     특정 메서드의 내용을 입력받아서 조건을 입력하고 결과 값을 돌려받을 때
        ///     delegate 함수 개념이 나옴, 이 함수를 delegate로 직접 작성할 수도 있지만
        ///     람다식을 써서 클로저를 명시하고 간단한 작성을 할 수 있음.
        /// </para>
        /// <para>
        ///     List의 메서드 중 일부도 람다식으로 처리할 수 있음,
        ///     delegate를 통해 양식에 맞는 익명 함수를 전달하는 것과 비슷한 작용을 할 순 있음.
        ///     단, 익명 메서드는 외부 변수를 참조할 때 this 키워드를 통해 현재 인스턴스를 참조함,
        ///     클로저를 명시적으로 선언하진 않는다.
        /// </para>
        /// <para>
        ///     아래의 FindAll을 뜯어본다면 PredicateT match 메서드를 인수로 가지고,
        ///     Predicate 메서드는 조건 집합을 정의하고 조건을 만족하는지 그렇지 않는지를 bool 형식 리턴
        ///     그래서 해당 bool 값을 돌려줄 조건 혹은 메서드가 있다면 작동 시켜줄 수 있음.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            // public List<T> FindAll(Predicate<T> match);
            // public delegate bool Predicate<in T>(T obj);

            List<int> listData = new List<int> { 1, 2, 3, 100, 200, 300 };

            int listStandard = 200;
            List<int> listfindAll1 = listData.FindAll((num) => { return num < listStandard; });
            // == List<int> listfindAll1 = listData.FindAll((num) => num < listStandard; );

            // delegate를 통해 익명 함수로 맞춰본 방식, 작동됨
            // List<int> listfindAll2 = listData.FindAll(delegate (int num) { return num < listStandard; });

            // 함수에서 활용할 로직을 또 다른 메서드로 빼서 작성한 케이스
            // List<int> listfindAll3 = listData.FindAll((num) => IsLessThanStandard(num, listStandard));

            Console.WriteLine("200보다 작은 모든 수:");
            foreach (int a in listfindAll1)
            {
                Console.WriteLine("a: " + a);
            }

            int evenStandard = 2;
            int findNum = listData.Find((num) => num % evenStandard == 0);
            Console.WriteLine("첫번째 짝수: " + findNum);
        }
    }
}
