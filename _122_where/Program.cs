using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _122_where
{
    /// <summary>
    /// <para>where를 통한 형식 제한</para>
    /// </summary>
    public class Ref { }
    /// <summary>
    /// <para>일반화 사용하지만 데이터 값 형식으로 제한해서 인스턴스 생성 가능</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class AA<T> where T : struct // 값 형식 제한
    {
        private T structValue;
        public AA()
        {
            structValue = default(T);
        }
        public void Print()
        {
            Console.WriteLine(structValue);
        }
    }
    /// <summary>
    /// <para>일반화 사용하지만 참조 형식으로 제한해서 인스턴스 생성 가능</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BB<T> where T : class // 참조 형식으로 제한
    {
        private T referenceValue;
        public BB ()
        {
            referenceValue = default(T);
        }
        public void Print ()
        {
            if (referenceValue == null) { Console.WriteLine("referenceValue is Null"); }
            else Console.WriteLine(referenceValue);
        }
    }
    /// <summary>
    /// <para>상속으로 구현해줄 인터페이스</para>
    /// </summary>
    interface II
    {
        void IIPrint ();
    }
    /// <summary>
    /// <para>
    ///     일반화 사용하지만 특정 인터페이스로 제한해서 인스턴스 생성 가능,
    ///     멤버에 일반화가 들어가긴 했지만 사실 인터페이스로 제한한 내용과 같음.
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CC<T> where T : II
    {
        public T _interface;
    }
    /// <summary>
    /// <para>
    ///     인터페이스 상속해서 구현한 클래스,
    ///     요구 받은 대로 멤버를 구현함
    /// </para>
    /// </summary>
    class DD : II
    {
        public void IIPrint ()
        {
            Console.WriteLine("DDbase: ");
        }
    }

    /// <summary>
    /// <para>한정자를 통해 명시된 대로 인스턴스 생성하는 모습</para>
    /// <para>
    ///     대부분은 이해, 일반화와 where로 인터페이스 한정을 동시에 진행했을 때
    ///     결국 인터페이스 상속을 강제한 것과 같음
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main (/* string[] args */)
        {
            AA<int> aa = new AA<int>();
            aa.Print();
            // AA<Ref> aaDash = new AA<Ref>(); // 데이터 값 형식으로 사용하라 제한했으므로
            // AA<float> aaDash = new AA<float>(); string 외의 다른 값 형식이 가능하긴 함

            BB<Ref> bb = new BB<Ref>();
            bb.Print();
            // BB<int> bbDash = new BB<int>(); 참조 형식으로 사용하라 제한했으므로
            // BB<string>bbDash = new BB<string>(); string 등 참조형이면 가능하긴 함

            CC<II> cc = new CC<II>();
            // cc._interface = new Ref(); 이미 상속을 통한 명시적 변환이 선언되었으므로
            cc._interface = new DD();
            cc._interface.IIPrint();
        }
    }
}
