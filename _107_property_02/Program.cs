using System;

namespace _107_property_02
{
    /// <summary>
    /// <para>사실 필드 값은 활용되지 않음</para>
    /// <para>get; set; 키워드만으로도 인스턴스를 작동시킬 수 있음</para>
    /// </summary>
    public class AA
    {
        // private readonly int num;
        // private readonly string name;

        public int NUM { get; set; }
        public string NAME { get; set; } = "NoName";
    }

    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA();
            Console.WriteLine("{0}", aa.NUM);
            Console.WriteLine("{0}", aa.NAME);

            aa.NUM = 100;
            aa.NAME = "Jack";
            Console.WriteLine("{0}", aa.NUM);
            Console.WriteLine("{0}", aa.NAME);
        }
    }
}
