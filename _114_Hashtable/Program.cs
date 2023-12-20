using System;
using System.Collections;

namespace _114_Hashtable
{
    internal class Program
    {
        /// <summary>
        /// <para>HashTable 다뤄보기</para>
        /// <para>1. 사용을 위해서는 System.Collections namespace 부르기</para>
        /// <para>2. 키와 값으로 이루어진 데이터들을 입력 가능, 대개 문자열을 키로, 값을 필요한 데이터 형으로 하는 케이스가 많음.</para>
        /// <para>3. 키와 값 입력:</para>
        /// <para>
        ///     a. 인스턴스 생성 시 키와 값을 입력해도 됨,
        ///     { "pos", 10 } || ["pos"] = 10 어느 문법이든 내용은 같음.
        ///     b. hashtable["생성할 키"] = "값"과 같이 작성해도 됨.
        /// </para>
        /// <para>4. 실제 다룰 때</para>
        /// <para>
        ///     foreach로 순회가 가능함,
        ///     단 hashtable 인스턴스 자체를 순회하면 각 키에 대한 타입 정보가 뜨며 정확한 값은 출력 안 됨
        ///     따라서 hashtable.Keys를 순회하는 게 좋음.
        ///     그래서 foreach 반복 문 안에서는 key == "pos", hashtable1[key] == 10
        ///     과 같이 순회할 것
        /// </para>
        /// <para>5. 유의사항</para>
        /// <para>
        ///     a. new Hashtable("기존 hashtable 인스턴스"); 와 같이 생성하면 불변성 보장됨,
        ///     하지만 hashtable2 = hashtable1과 같이 생성하면 같은 주소 값을 보기 때문에 불변성 보장 안 됨.
        ///     b. Hashtable은 키들의 순서를 보장하지 않음,
        ///     만약 순서가 중요하다면 Dictionary, SortedDictionary, LinkedDictionary 등 고려할 수 있음.
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            Hashtable hashtable1 = new Hashtable
            {
                { "pos", 10 },
                { "name", "Jack" }
            };
            hashtable1["weight"] = 10.8f;

            foreach (object key in hashtable1) { Console.WriteLine("key: {0}, data: {1}", key, hashtable1[key]); }
            foreach (object key in hashtable1.Keys) { Console.WriteLine("key: {0}, data: {1}", key, hashtable1[key]); }
            Console.WriteLine("");

            Hashtable hashtable2 = new Hashtable()
            {
                ["grade"] = 3,
                ["group"] = "B",
                ["teacher"] = "Joel",
            };

            foreach (object key in hashtable2) { Console.WriteLine("key: {0}, data: {1}", key, hashtable2[key]); }
            foreach (object key in hashtable2.Keys) { Console.WriteLine("key: {0}, data: {1}", key, hashtable2[key]); }
            Console.WriteLine("");

            Hashtable hashtable3 = new Hashtable(hashtable2);
            hashtable3["name"] = "Jack";

            foreach (object key in hashtable3.Keys) { Console.WriteLine("key: {0}, data: {1}", key, hashtable3[key]); }
            Console.WriteLine("");

            foreach (object key in hashtable2.Keys) { Console.WriteLine("key: {0}, data: {1}", key, hashtable2[key]); }
            Console.WriteLine("");

            Hashtable hashtable4 = hashtable3;
            hashtable4["pos"] = 10;
            foreach (object key in hashtable3.Keys) { Console.WriteLine("key: {0}, data: {1}", key, hashtable3[key]); }
        }
    }
}
