using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _097_class_is_as
{
    /// <summary>
    /// 여러 클래스들이 상속할 베이스 클래스
    /// </summary>
    public class Base
    {
        /// <summary>
        /// 현재 클래스만 읽을 필드 값 num;
        /// </summary>
        private readonly int num = 1;
        /// <summary>
        /// 현재 클래스의 num 변수 출력
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Base: {0}", num);
        }
    }

    /// <summary>
    /// AA 클래스 만들고 Base 클래스 상속
    /// </summary>
    public class AA : Base
    {
        /// <summary>
        /// 현재 클래스에서 활용할 필드 값 a
        /// </summary>
        private readonly int a = 2;

        /// <summary>
        /// 현재 클래스의 a 값 출력
        /// </summary>
        public void PrintA()
        {
            Console.WriteLine("AA: {0}", a);
        }
    }

    /// <summary>
    /// BB 클래스 만들고 Base 클래스 상속
    /// </summary>
    public class BB : Base
    {
        /// <summary>
        /// 현재 클래스에서 활용할 필드 값 b
        /// </summary>
        private readonly int b = 3;

        /// <summary>
        /// 현재 클래스의 b 값 출력
        /// </summary>
        public void PrintB()
        {
            Console.WriteLine("BB: {0}", b);
        }
    }

    internal class Program
    {
        /// <summary>
        /// <para>1. Base, AA 인스턴스 만들고 출력</para>
        /// <para>이때 인스턴스의 타입을 부모로 선언하고 생성할 인스턴스는 자식 인스턴스로 만들 수 있음: 자식 인스턴스가 부모 인스턴스의 허용된 멤버에 접근 가능해짐</para>
        /// <para>단, 자식 인스턴스가 생성됐다 생각들지만 부모 클래스의 멤버들만 인지하고 있으며 타입만 부모 클래스 || 자식 클래스인 상태임</para>
        /// 
        /// <para>2. AA 인스턴스의 타입으로 분기문 작동해보기</para>
        /// 
        /// <para>3. BB 인스턴스 생성하고 as BB로 형식 변환 후 BB 클래스의 멤버 메서드 실행해보기</para>
        /// <para>처음은 위 상황과 같이 부모 클래스 멤버들을 인지하고 있으며 타입만 Base || BB인 상태임</para>
        /// <para>as 키워드의 반환 값이 null이 아님 == Base || BB인 타입을 BB로 변환할 수 있었고 실제 BB 인스턴스로서 할당됨</para>
        /// <para>따라서 BB 인스턴스의 멤버 메서드에 접근 가능했음</para>
        /// 
        /// <para>4. BB 인스턴스를 as AA로 형변환 시도해보고 null인지 확인해보기</para>
        /// <para>불가능: 왜냐하면 Base 인스턴스 = new BB(); 를 통해 만들어진 인스턴스 타입은 Base || BB임, Base || AA가 아니므로 as 키워드로 변환할 수는 없고 아무 값도 들어가지 못해 null 반환</para>
        /// 
        /// <para>5. BB 인스턴스를 as AA로 형변환할 수 없었음, AA 인스턴스 다시 할당 후 로직 호출해보기</para>
        /// <para>(AA)bb와 같이 명시적으로 타입을 변경 시도하지만 불가능할 때에는 예외를 던짐</para>
        /// <para>bb as AA;는 변환이 불가능할 때 null을 반환할 수 있음</para>
        /// <para>단 as 키워드는 값 타입 간 변환에서는 사용할 수 없으며 값 타입끼리는 명시적 캐스팅 사용하기</para>
        /// 
        /// <para>6. 할당한 AA 인스턴스를 강제로 형변환해보고 AA 클래스의 메서드 호출해보기 </para>
        /// </summary>
        private static void Main(/* string[] args */)
        {
            Base _base = new Base();
            _base.Print();

            Base aa = new AA();
            aa.Print();
            // aa.PrintA();

            if (aa is Base)
            {
                Console.WriteLine("aa는 Base의 객체입니다.");
            }
            if (aa is BB)
            {
                Console.WriteLine("aa는 BB의 객체입니다.");
            }            
            else if (aa is AA)
            {
                Console.WriteLine("aa는 AA의 객체입니다.");
            }

            Base bb = new BB();
            BB copyBB = bb as BB;
            if(null != copyBB)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("copyBB는 BB객체를 형식 변환");
                copyBB.PrintB();
            }

            // AA copyAA = (AA)bb; // 예외 상황 발생(??)
            AA copyAA = bb as AA;
            if(null == copyAA)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("copyAA는 AA 객체가 아니므로 null");

                copyAA = new AA();
                copyAA.Print();
                // copyAA.PrintA(); // 오류: 다형성으로 가능(??)

                // == AA asAA = copyAA
                AA asAA = copyAA as AA; // 강제 형 변환
                asAA.PrintA();
            }
        }
    }
}
