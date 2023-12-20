using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _116_Indexer02
{
    /// <summary>
    /// <para>Prop을 가지는 인덱서</para>
    /// <para>1. Private 등으로 캡슐화된 멤버를 만듦</para>
    /// <para>
    ///     2. this[int index]를 통해 인스턴스가 호출됐을 때 동작 정의,
    ///     index가 0보다 크거나 같고 arrayList.Count보다 작은지 따짐
    ///     (arrayList.Count는 배열의 길이와 같음, 인덱스 아님)
    /// </para>
    /// <para>
    ///     get 동작:
    ///     멤버 ArrayList[index] 요소를 string 캐스팅해서 반환,
    ///     조건 안 맞으면 null 반환
    /// </para>
    /// <para>
    ///     set 동작:
    ///     멤버 ArrayList[index] 요소에 value 값을 할당,
    ///     만약 arrayList.Count와 같은 인덱스라면 새로 요소를 추가해서 작동함.
    /// </para>
    /// <para>3. 클래스에서 Prop을 정의</para>
    /// <para>
    ///     AA.Count:
    ///     get 동작으로 현재 멤버 ArrayList의 Count를 반환함.
    ///     어차피 ArrayList는 set 동작으로 변해야 하므로 AA.Count에 대한 Set 동작은 필요 없음.
    /// </para>
    /// </summary>
    public class AA
    {
        private readonly ArrayList arrayList = new ArrayList();

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < arrayList.Count)
                    return (string) arrayList[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < arrayList.Count)
                    arrayList[index] = value;
                else if (index == arrayList.Count)
                    arrayList.Add(value);
            }
        }

        public int Count
        {
            get { return arrayList.Count; }
        }
    }

    /// <summary>
    /// <para>Prop을 가지는 인덱서</para>
    /// <para>1. 인스턴스 생성</para>
    /// <para>2. 형식에 맞추어서 set 동작으로 값 대입, for문을 통한 반복 || 인덱스를 통한 할당</para>
    /// <para>3. get 동작으로 값 호출, 호출 시 string 타입으로 캐스팅</para>
    /// </summary>
    internal class Program
    {
        private static void Main ()
        {
            AA aa = new AA();
            for (int i = 0; i < 10; i++)
            {
                // aa[i] = i;
                aa[i] = string.Format("{0}", i);
            }

            aa[0] = "Hello";
            aa[1] = "World";

            for (int i = 0; i < aa.Count; i++)
            {
                Console.WriteLine("aa: " + aa[i]);
            }
        }
    }
}
