using System;
using System.Collections;

namespace _111_ArrayList
{
    internal class Program
    {
        /// <summary>
        /// <para>ArrayList 다뤄보기</para>
        /// <para>1. ArrayList 인스턴스 생성</para>
        /// <para>2. Add 메서드로 요소 추가</para>
        /// <para>
        ///     요소의 형태로 다양한 타입이 들어갈 수 있고
        ///     배열 길이도 정해지지 않아서 기존 int[] 등과 비교했을 때 상대적으로 동적임
        /// </para>
        /// <para>3. for 혹은 foreach 둘 모두 사용 가능</para>
        /// <para>4. 초기화한 Array 기반으로 새 ArrayList 인스턴스를 만들 수 있음</para>
        /// <para>
        ///     생성된 ArrayList는 원본 배열과 다른 주소 값을 바라보고 있으므로
        ///     서로 편집해도 영향을 주지 않음(불변성 유지됐다 보면 됨)
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            ArrayList arrayList = new ArrayList();

            _ = arrayList.Add("Hello");
            _ = arrayList.Add(10f);

            for (int i = 0; i < 10; i++) { _ = arrayList.Add(i); }
            foreach (object data in arrayList) { Console.WriteLine("arrayList data: {0}", data); }

            Console.WriteLine("배열 데이터로 초기화");
            int[] arrayData = { 100, 200, 300 };
            foreach (object data in arrayData) { Console.WriteLine("arrayData data: {0}", data); }

            Console.WriteLine("배열 기반 새 ArrayList 형성");
            ArrayList arrayCopyList = new ArrayList(arrayData);
            for (int i = 0; i < arrayData.Length; i++) { arrayCopyList.Add(arrayData[i]); }
            foreach (object data in arrayCopyList) { Console.WriteLine("arrCopyList data: {0}", data); }

            Console.WriteLine("원본 배열 출력 시도, 이게 성공한다면 서로 다른 주소 값을 바라보는 게 됨.");
            foreach (object data in arrayData) { Console.WriteLine("arrayData data: {0}", data); }
        }
    }
}
