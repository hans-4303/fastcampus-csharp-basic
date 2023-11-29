using System;

namespace _094_inheritance
{
    /// <summary>
    /// 
    /// <para>
    /// 부모 클래스 생성
    /// </para>
    /// 
    /// <para>
    /// 상속할 수 있는 필드 값과 메서드를 가지게 함
    /// </para>
    /// 
    /// </summary>
    public class Super
    {
        protected int a;
        public void Print()
        {
            Console.WriteLine("Super Print()");
        }
    }

    /// <summary>
    /// 
    /// <para>
    /// 자식 클래스 생성
    /// </para>
    /// 
    /// <para>
    /// 자식 클래스 자신이 가진 필드 값과 새로운 메서드를 작성함
    /// 또한 부모 클래스로부터 부모 클래스 필드 값과 메서드를 상속 받아올 수 있음
    /// 단, 상속된 멤버 활용은 public이나 protected로 작성된 경우에 한함
    /// </para>
    /// 
    /// <para>
    /// 부모 클래스의 메서드와 이름이 같지만 자식 클래스 혼자 쓸 메서드를 만든다면
    /// 메서드 작성 시 리턴 형 앞에 new를 명시해줄 것
    /// </para>
    /// 
    /// </summary>
    public class Sub : Super
    {
        private readonly int b = 1;
        public new void Print()
        {
            Console.WriteLine("{0}, {1}", a, b);
        }
    }

    internal class Program
    {
        /// <summary>
        /// 
        /// <para>
        /// 자식 클래스를 인스턴스로 만들고 메서드를 호출해봄
        /// </para>
        /// 
        /// <para>
        /// 이때 자식 클래스의 메서드로 부모 클래스의 필드 값을 출력할 수 있었음
        /// </para>
        /// 
        /// <para>
        /// 그러니 부모 클래스는 자식 클래스에게 멤버를 상속해주고
        /// 자식 클래스는 부모 클래스의 멤버를 인지하는 상태가 됐음
        /// </para>
        /// 
        /// </summary>
        private static void Main(/* string[] args */)
        {
            Sub sub = new Sub();
            sub.Print();
        }
    }
}
