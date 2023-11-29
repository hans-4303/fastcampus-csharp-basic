using System;

namespace _096_class_base
{
    public class Super
    {
        /// <summary>
        /// 부모 클래스의 필드 값들
        /// </summary>
        private readonly int num;
        protected string name;

        /// <summary>
        /// 만약 아무 파라미터도 안 받는 생성자가 있다면 자식 클래스에서도 파라미터 없는 생성자를 통해 유연한 처리 가능할 수 있음
        /// 하지만 반드시 어떤 값을 받아야 하는 생성자가 있다 전제
        /// </summary>
        public Super(int num)
        {
            this.num = num;
        }

        /// <summary>
        /// 현재 부모 클래스의 num을 출력하는 함수로 만듦
        /// </summary>
        public void PrintSuper()
        {
            Console.WriteLine("This is Super: {0}", num);
        }
    }

    public class Sub : Super
    {
        /// <summary>
        /// 자식 클래스가 가지는 name 필드
        /// 부모 클래스의 name과 유사할 수는 있지만 다른 값이어야 하기 때문에
        /// private new readonly 속성 명시
        /// </summary>
        private new readonly string name;

        /// <summary>
        /// <para>
        /// 자식 생성자가 부모 생성자의 파라미터와 다른 경우만 있다면 부모 생성자를 못 맞춰주기 때문에 문제됨
        /// 상속과 처리가 원만하지 못하니까
        /// </para>
        /// <para>
        /// 하지만 자식 생성자 뒤에 부모 생성자와 알맞는 파라미터를 명시해줄 수 있음
        /// </para>
        /// <para>
        /// 이렇게 하면 자식 생성자가 부모 생성자와 다른 파라미터를 받는다고 해도 파라미터 중 하나를
        /// 부모 생성자에 알맞게 대입해주는 상황이 됨
        /// </para>
        /// </summary>
        /// 
        /// <param name="num">자식 생성자에서 num 파라미터를 받지만 동시에 부모 클래스의 생성자에도 전달됨</param>
        /// <param name="name">자식 생성자에서 name을 받고 자식 클래스 내부에서 처리됨</param>
        public Sub(int num, string name) : base(num)
        {
            this.name = name;
        }

        /// <summary>
        /// <para>자식 클래스에서 출력하는 메서드</para>
        /// <para>부모 클래스의 필드 값에 직접 값을 대입하고 부모 클래스의 메서드 호출 (접근 권한이 알맞다면)</para>
        /// <para>이후 부모 클래스의 필드 값을 현재 자식 메서드에서 출력해보며 자식 클래스 자신의 필드 값을 출력하고 있음</para>
        /// </summary>
        public void PrintSub()
        {
            base.name = "Super";
            // == base.PrintSuper();
            PrintSuper();

            Console.WriteLine("This is Super on Sub: {0}", base.name);
            // == Console.WriteLine("This Sub: {0}", this.name);
            Console.WriteLine("This is Sub: {0}", name);
        }
    }

    internal class Program
    {
        /// <summary>
        /// <para>num 파라미터를 자식 클래스에서 받되 부모 클래스의 알맞는 생성자까지 올려서 처리</para>
        /// <para>자식 클래스의 메서드에서 부모 클래스 메서드 처리하고 생성자 함수로 받은 인수를 자식 클래스 자신의 필드 값으로 처리 </para>
        /// </summary>
        private static void Main(/* string[] args */)
        {
            Sub sub = new Sub(26, "Jack");
            sub.PrintSub();
        }
    }
}
