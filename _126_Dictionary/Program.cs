using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _126_Dictionary
{
    public class AA
    {
        private int a;

        public AA()
        { 
            a = 1;
        }

        public int getValue()
        {
            return a;
        }

        public void setValue(int value)
        {
            a = value;
        }
    }

    /// <summary>
    /// <para>Dictionary + T 제네릭</para>
    /// <para>
    ///     hashTable과 비슷한 자료형으로 생각됨
    ///     단, key와 value 양쪽에 형식을 정해줄 수 있음.
    ///     key는 대개 값 형식으로 정하는 게 좋지만
    ///     value는 참조형으로도, 또한 직접 만든 클래스 형식으로도 정할 수 있었음.
    /// </para>
    /// <para>
    ///     또한 Dictionary 인스턴스를 만들면서 타입을 보장 받았기 때문인지
    ///     Hashtable을 다룰 때처럼 value에 대한 캐스팅이 필요 없어졌음.
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main ()
        {
            Dictionary<string, int> dictionaryAA = new Dictionary<string, int>();
            dictionaryAA.Add("10", 10);
            dictionaryAA.Add("20", 20);
            dictionaryAA["30"] = 30;

            foreach (var key in dictionaryAA.Keys)
            {
                Console.WriteLine("key: {0}, data: {1}", key, dictionaryAA[key]);
            }

            Console.WriteLine("");

            Dictionary<int, string> dictionaryInit = new Dictionary<int, string>()
            {
                [1] = "Hello",
                [100] = "Dictionary",
                [1000] = "Good!!",
            };

            foreach (var key in dictionaryInit.Keys)
            {
                Console.WriteLine("key: {0}, data: {1}", key, dictionaryInit[key]);
            }

            string getValue = string.Empty;
            dictionaryInit.TryGetValue(1, out getValue);
            Console.WriteLine("\nTryGetValue: " + getValue);

            dictionaryInit.TryGetValue(11, out getValue);
            Console.WriteLine("\nTryGetValue: " + getValue);

            // 키와 직접 만든 클래스를 Dictionary의 제네릭으로 넣을 수 있음
            Dictionary<int, AA> customDictionary = new Dictionary<int, AA>
            {
                [0] = new AA(),
                [1] = new AA(),
                [2] = new AA(),
            };

            int counter = 0;

            foreach (var key in customDictionary.Keys)
            {
                // AA temp = (AA) customDictionary[key]; 이 경우 인스턴스를 만들면서 AA 클래스 형식이 보장된 것으로 보임.
                AA temp = customDictionary[key];
                temp.setValue(50);
                Console.WriteLine("인덱스 {0} 반복: {1}", counter, temp.getValue());
                counter++;
            }
        }
    }
}
