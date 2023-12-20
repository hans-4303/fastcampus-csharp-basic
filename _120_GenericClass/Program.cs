using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120_GenericClass
{
    /// <summary>
    /// <para>클래스 일반화: 멤버 값들과 메서드 전부에 일반화 과정 적용 가능</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericAA<T>
    {
        private T num;
        public T GetNum ()
        {
            return num;
        }
        public void SetNum (T data)
        {
            num = data;
        }
    }


    internal class Program
    {
        private static void Main ()
        {
            GenericAA<int> AA = new GenericAA<int> ();
            AA.SetNum(100);
            Console.WriteLine(AA.GetNum());

            GenericAA<float> AADash = new GenericAA<float> ();
            AADash.SetNum(3.14f);
            Console.WriteLine(AADash.GetNum());
        }
    }
}
