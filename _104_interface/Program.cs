using System;

namespace _104_interface
{
    /// <summary>
    /// <para>인터페이스 작성해보기</para>
    /// <para>
    ///     인터페이스는 상속할 클래스에게 강제성을 줄 수 있는 설계도,
    ///     인터페이스 자체는 설계도 개념으로 별도의 필드 값이나 접근 형태를 지정하지 않음.
    ///     따라서 필드 값을 생성할 수 없음.
    ///     프로퍼티와 메서드도 명시할 수 있지만 구체적 구현은 하지 않음.
    /// </para>
    /// </summary>
    public interface IAA
    {
        // public int a;
        // private void IPrint() {}
        // public void Iprint() {}
        int A { get; set; } // 프로퍼티 명시 가능
        void IAAPrint(); // 구현을 하지 않은 메서드 명시 가능
    }

    /// <summary>
    /// 메서드가 하나 있는 인터페이스 작성됨
    /// </summary>
    public interface IBB
    {
        void IBBPrint();
    }

    /// <summary>
    /// <para>필드 값과 메서드를 가진 클래스</para>
    /// <para>필드 값과 메서드를 상속시켜 줄 수 있지만 override가 강제되지는 않음</para>
    /// </summary>
    public class Super
    {
        protected int num;
        public virtual void Print()
        {
            Console.WriteLine("------------------------------");
        }
    }

    /// <summary>
    /// <para>IAA 인터페이스로 만든 클래스</para>
    /// <para>
    ///     인터페이스를 상속받아 클래스를 만들면 명시된 프로퍼티와 메서드를 재정의하는 것이 강제됨,
    ///     예측 가능하고 견고한 코드 만드는 데 도움
    /// </para>
    /// </summary>
    public class AA : IAA
    {
        public int A { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void IAAPrint()
        {
            Console.WriteLine("interface IAA -> class AA에 IAAPrint() 메서드 구현");
        }
    }

    /// <summary>
    /// <para>여러 인터페이스를 상속받아 만든 클래스</para>
    /// <para>
    ///     여러 인터페이스를 상속받아 클래스를 만들면 모든 인터페이스 내용에 대해 재정의해야 함
    ///     다중 클래스 상속은 불가능하지만 다중 인터페이스 상속으로 도움
    /// </para>
    /// </summary>
    public class BB : IAA, IBB
    {
        public int A
        {
            get { return A; }
            set { A = value; }
        }

        public void IAAPrint()
        {
            Console.WriteLine("interface IAA -> class BB에 IAAPrint() 메서드 구현");
        }

        public void IBBPrint()
        {
            Console.WriteLine("interface IBB -> class BB에 IBBPrint() 메서드 구현");
        }
    }

    /// <summary>
    /// <para>클래스 상속 VS 인터페이스 상속</para>
    /// <para>
    ///     클래스 상속 시에는 virtual로 상속할 메서드가 있어도 강제성을 띄는 건 아님,
    ///     하지만 인터페이스 상속 시에는 상속하거나 구현할 부분에 있어서 강제성을 띔
    /// </para>
    /// </summary>
    public class CC : Super, IAA, IBB
    {
        public int A
        {
            get { return A; }
            set { A = value; }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("class Super -> class CC에 Print() 메서드 재정의");
        }

        public void IAAPrint()
        {
            Console.WriteLine("interface IAA -> class CC에 IAAPrint() 메서드 구현");
        }

        public void IBBPrint()
        {
            Console.WriteLine("interface IBB -> class CC에 IBBPrint() 메서드 구현");
        }
    }

    /// <summary>
    /// <para>인터페이스와 클래스 호출</para>
    /// <para>
    ///     클래스를 인스턴스로 바로 생성할 수도 있고 재정의 끝난 메서드를 사용할 수도 있음.
    ///     (인터페이스 상속으로 인해 재정의가 보장됨)
    /// </para>
    /// <para>
    ///     인스턴스를 생성할 때 인터페이스 형식을 참조하며 생성 시키는 것도 가능함
    ///     인스턴스가 어떤 인터페이스 형식으로 만들어져 있는지 보장할 수 있고, 매칭되는 메서드 호출 가능함 
    /// </para>
    /// <para>
    ///     클래스 + 다중 인터페이스 상속도 가능함
    ///     해당 방법으로 생성된 인스턴스는 클래스 및 다중 인터페이스로 구현된 메서드 전부에 접근 가능
    /// </para>
    /// <para>
    ///     단, 클래스 + 다중 인터페이스 상속된 클래스가 어느 한 클래스 혹은 인터페이스로 형식 변환되었다면
    ///     변환된 형식 외 다른 형식은 인지하지 못함
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA();
            aa.IAAPrint();

            BB bb = new BB();
            bb.IAAPrint();
            bb.IBBPrint();

            IAA Iaa = new AA();
            Iaa.IAAPrint();

            // == IBB Ibb = bb as IBB;
            IBB Ibb = bb;
            Ibb.IBBPrint();

            CC cc = new CC();
            cc.Print();
            cc.IAAPrint();
            cc.IBBPrint();

            Super sCC = cc;
            sCC.Print();

            IAA IAAcc = cc;
            IAAcc.IAAPrint();
            // IAAcc.IBBPrint(); // 불가: IAA 인터페이스 타입으로 형태 변환 되었음, IBB 인터페이스를 인지하지 못함

            IBB IBBcc = cc;
            IBBcc.IBBPrint();
        }
    }
}
