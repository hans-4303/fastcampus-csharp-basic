using System;

/*-----------------------------------------------------------------------------
 * Name: _084_override2
 * DESC: 오버라이딩(다형성): 실제 게임에서 사용되는 예를 보여준다.
-----------------------------------------------------------------------------*/
namespace _099_override2
{
    /// <summary>
    /// 부모 클래스가 되는 Army
    /// </summary>
    public class Army
    {
        /// <summary>
        /// 현재 클래스와 상속된 클래스에서만 활용할 수 있는 protected 필드 값들
        /// </summary>
        protected int _HP;
        protected int _MP;
        protected int _Speed;
        protected int _Attack;

        /// <summary>
        /// 오버라이딩 할 수 있는 Run 함수, 필드 값을 출력해줌
        /// </summary>
        public virtual void Run()
        {
            Console.Write("{0}의 속도로 ", _Speed);
        }

        /// <summary>
        /// 오버라이딩 할 수 있는 Attack 함수, (연산된) 필드 값 출력
        /// </summary>
        public virtual void Attack()
        {
            Console.WriteLine();

            if (this is Healer)
            {
                Console.Write("[마법 공격력 - {0}]으로 ", _Attack * _MP);
            }
            else
            {
                Console.Write("[공격력 - {0}]으로 ", _Attack);
            }
        }
    }

    /// <summary>
    /// 자식 클래스 중 하나
    /// </summary>
    public class Barbarian : Army
    {
        /// <summary>
        /// 기본 생성자로 상속 받아온 필드 값에 대입
        /// </summary>
        public Barbarian()
        {
            _HP = 100;
            _MP = 0;
            _Speed = 100;
            _Attack = 100;
        }

        /// <summary>
        /// 오버라이드 된 Run 메서드
        /// 부모 클래스의 Run 메서드 호출 및 유닛 별 추가 메시지 출력
        /// </summary>
        public override void Run()
        {
            base.Run();

            Console.WriteLine("Barbarian 달려갑니다. ");
        }

        /// <summary>
        /// 오버라이드 된 Attack 메서드
        /// 부모 클래스의 Attack 메서드 호출 및 유닛 별 추가 메시지 출력
        /// </summary>
        public override void Attack()
        {
            base.Attack();

            Console.WriteLine("Barbarian이 칼로 공격!!! ");
        }
    }

    /// <summary>
    /// 자식 클래스 중 하나
    /// </summary>
    public class Giant : Army
    {
        /// <summary>
        /// 생성자 함수로 상속 받아온 필드 값에 대입
        /// </summary>
        public Giant()
        {
            _HP = 200;
            _MP = 0;
            _Speed = 10;
            _Attack = 200;
        }

        /// <summary>
        /// 오버라이드 된 Run 메서드
        /// 부모 클래스의 Run 메서드 호출 및 유닛 별 추가 메시지 출력
        /// </summary>
        public override void Run()
        {
            base.Run();

            Console.WriteLine("Giant 달려갑니다. ");
        }

        /// <summary>
        /// 오버라이드 된 Attack 메서드
        /// 부모 클래스의 Attack 메서드 호출 및 유닛 별 추가 메시지 출력
        /// </summary>
        public override void Attack()
        {
            base.Attack();

            Console.WriteLine("Giant 공격!!! ");
        }
    }

    /// <summary>
    /// 자식 클래스 중 하나
    /// </summary>
    public class Healer : Army
    {
        /// <summary>
        /// 생성자 함수로 상속 받아온 필드 값에 대입
        /// </summary>
        public Healer()
        {
            _HP = 50;
            _MP = 100;
            _Speed = 200;
            _Attack = 10;
        }

        /// <summary>
        /// 오버라이드 된 Run 메서드
        /// 부모 클래스의 Run 메서드 호출 및 유닛 별 추가 메시지 출력
        /// </summary>
        public override void Run()
        {
            base.Run();

            Console.WriteLine("Healer 날아갑니다. ", _Speed);
        }

        /// <summary>
        /// <para>오버라이드 된 Attack 메서드 부모 클래스의 Attack 메서드 호출 및 유닛 별 추가 메시지 출력</para>
        /// <para>
        ///     이때 자식 클래스가 어떤 형식인지 인지
        ///     Attack() 메서드에서 클래스의 형식으로 분기문을 작성했음
        ///     if(this is Healer) {} 분기에 따라 _Attack * _MP가 계산 됨
        /// </para>
        /// </summary>
        public override void Attack()
        {
            base.Attack();

            Console.WriteLine("Healer 마법 공격!!! ");
        }
    }

    /// <summary>
    /// <para>1. 여러 유닛들이 들어갈 수 있는 배열 생성, 형식은 부모 클래스 형식</para>
    /// <para>2. 배열의 요소에 구체적인 유닛들을 대입함, 이때 형식은 부모 || 자식 클래스 형식 </para>
    /// <para>3. 배열을 반복하면서 구체적인 유닛 들어간 각 요소에 접근하고 Run, Attack 메서드 호출</para>
    /// <para>4. 각 요소는 부모 클래스의 메서드 및 오버라이딩 된 내용까지 같이 호출</para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            Army[] arrArmys = new Army[10];

            arrArmys[0] = new Barbarian();
            arrArmys[1] = new Giant();
            arrArmys[2] = new Healer();

            for (int i = 0; i < arrArmys.Length; i++)
            {
                if (null != arrArmys[i])
                {
                    arrArmys[i].Run();
                    System.Threading.Thread.Sleep(1000);
                }
            }

            for (int i = 0; i < arrArmys.Length; i++)
            {
                if (null != arrArmys[i])
                {
                    arrArmys[i].Attack();
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}