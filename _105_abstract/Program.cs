using System;

namespace _105_abstract
{
    /// <summary>
    /// <para>추상 클래스 만들어보기</para>
    /// <para>일반 클래스와 유사한 점이 있음:</para>
    /// <para>
    ///     필드 값, 생성자, override 가능하거나 일반 메서드 작성할 수 있음
    /// </para>
    /// <para>일반 클래스와 차이점 있음:</para>
    /// <para>
    ///     추상 클래스로 정의되면 인스턴스를 만들 수 없음
    ///     추상 메서드로 정의되면 상속받은 클래스는 반드시 해당 메서드 오버라이딩 해야 함
    /// </para>
    /// </summary>
    public abstract class AbstractAA
    {
        protected int num;

        public AbstractAA(int num)
        {
            this.num = num;
        }

        public abstract void AbstractPrint();

        public virtual void VirtualPrint()
        {
            Console.WriteLine("this method is virtual method in abstract class");
        }

        public void Print()
        {
            Console.WriteLine("this method is just method from abstract class");
        }
    }

    /// <summary>
    /// <para>추상 클래스 상속 받은 실체 클래스</para>
    /// <para>
    ///     경우에 따라 실체 클래스의 생성자와 추상 클래스 생성자를 연계해줘야 할 수 있음,
    ///     추상 메서드는 반드시 오버라이딩 해야 함
    ///     virtual 메서드 혹은 통상 메서드는 반드시 오버라이딩 할 필요는 없음
    /// </para>
    /// </summary>
    public class AA : AbstractAA
    {
        public AA(int num) : base(num)
        {
            Console.WriteLine("{0}", num);
        }

        public override void AbstractPrint()
        {
            Console.WriteLine("this method should override in this class.");
        }

        public override void VirtualPrint()
        {
            base.VirtualPrint();

            Console.WriteLine("this method can override in this class, but not compulsory.");
        }
    }

    /// <summary>
    /// <para>실체 클래스와 추상 클래스 활용</para>
    /// <para>
    ///     추상 클래스 상속받은 실체 클래스로 인스턴스 만들고 메서드 호출 가능
    ///     실체 클래스로 인스턴스 만들되, 타입이 추상 클래스라 선언하는 것도 가능
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA(10);
            aa.AbstractPrint();
            aa.VirtualPrint();
            aa.Print();

            AbstractAA aaDash1 = new AA(20); // 가능: 추상 클래스 타입을 갖는다 선언할 수는 있다.
            aaDash1.AbstractPrint();
            aaDash1.Print();
            // AbstractAA aaDash2 = new AbstractAA(20); // 불가능: 추상 클래스는 인스턴스화 할 수 없다.
        }
    }
}
