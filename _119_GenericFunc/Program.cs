using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _119_GenericFunc
{
    /// <summary>
    /// <para>클래스와 메서드 일반화 가능, 너무 많은 오버로딩 혹은 박싱 언박싱을 피하기 좋음.</para>
    /// <para>이해는 되는데 필드 값을 가지고 있는 클래스는 어떻게 될까?</para>
    /// </summary>
    internal class Program
    {
        static void GenericPrint<T>(T data)
        {
            Console.WriteLine(data);
        }

        static void GenericPrint<T> (T[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        private static void Main ()
        {
            int a = 10;
            float b = 10.3f;
            string c = "hey there?";

            int[] arrA = { 0, 1, 2, 3 };
            string[] arrB = { "A", "B", "C", "D" };

            GenericPrint(a);
            GenericPrint(b);
            GenericPrint(c);
            Console.WriteLine();

            GenericPrint(arrA);
            Console.WriteLine();
            GenericPrint(arrB);
        }
    }
}
