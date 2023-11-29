using System;

namespace _098_override
{
    /// <summary>
    /// 부모 클래스 생성하고 재정의를 허용하는 메서드를 멤버에 둠.
    /// </summary>
    public class Super
    {
        /// <summary>
        /// 상속 받는 클래스에서 사용 가능한 필드 값
        /// </summary>
        protected int num = 1;

        /// <summary>
        /// virtual 키워드는 접근 지정자 다음에 적을 수 있음, 기본적 로직만 작성한다 가정.
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine("This is Super: {0}", num);
        }
    }

    /// <summary>
    /// 자식 클래스 생성하고 부모 클래스의 메서드를 재정의할 수 있음
    /// </summary>
    public class AA : Super
    {
        /// <summary>
        /// 여러 클래스에서 사용 가능한 필드 값으로 정의
        /// </summary>
        public int a = 2;
        public static int aDash = 4;

        /// <summary>
        /// <para>override 키워드는 접근 지정자 다음에 작성함, new 키워드는 없음.</para>
        /// <para>
        ///     오버라이드 된 메서드 내부에서 부모 클래스 자체와(base로 공통된 지칭)
        ///     부모 클래스의 멤버 메서드에도 동시에 접근할 수 있음.
        /// </para>
        /// </summary>
        public override void Print()
        {
            base.Print();

            Console.WriteLine("This is AA: {0}", a);
        }
    }

    /// <summary>
    /// 자식 클래스 생성하고 부모 클래스의 메서드를 재정의할 수 있음.
    /// </summary>
    public class BB : Super
    {
        /// <summary>
        /// 여러 클래스에서 사용 가능한 필드 값으로 정의
        /// </summary>
        public int b = 3;

        /// <summary>
        /// <para>override 키워드는 접근 지정자 다음에 작성함, new 키워드는 없음.</para>
        /// <para>
        ///     오버라이드 된 메서드 내부에서 부모 클래스 자체와(base로 공통된 지칭)
        ///     부모 클래스의 멤버 메서드에도 동시에 접근할 수 있음.
        /// </para>
        /// </summary>
        public override void Print()
        {
            base.Print();

            Console.WriteLine("This is BB: {0}", b);
        }
    }

    /// <summary>
    /// <para>1. 부모 타입으로 부모 인스턴스 생성하고 출력해보가</para>
    /// <para>2. 부모 타입으로 자식 인스턴스 생성하고 출력해보기</para>
    /// <para>
    ///     이때 자식 인스턴스는 부모 || 자식 형식을 가지고, 부모 멤버만 인지하고 있음,
    ///     이전 예제에서는 as 키워드로 자식 형식이라 명시하지 않는 이상 부모 || 자식 형식을 가지며
    ///     자식 필드 및 키워드를 인지할 수 없음.
    /// </para>
    /// <para>3. 그리고 자식 인스턴스에서 부모 인스턴스의 메서드 명과 똑같은 Print를 호출하는 상황임.</para>
    /// <para>4. 그런데도 원본 부모 클래스의 필드 값 및 메서드와 자식 클래스의 필드 값 및 메서드에 동시 접근하는 결론.</para>
    /// <para>5. aa 인스턴스를 확실하게 AA 타입으로 변환했다 생각했는데도 여전히 최종 형식은 부모 || 자식임.</para>
    /// <para>
    ///     형변환을 거쳐도 부모 || 자식 형식을 갖게 되고 정해진 우선순위는 없으며 로직에서 우선순위 정해준 걸 따라감.
    ///     다만 자식 형식의 필드를 인지할 수 있게 됨
    /// </para>
    /// <para>
    ///     변환한 인스턴스에서도 원본 메서드와 필드 값에 여전히 접근 가능하고
    ///     변환한 인스턴스에서 오버라이딩 된 내용까지 실행 가능함.
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            Super super = new Super();
            super.Print();

            Super aa = new AA();
            aa.Print();

            Super bb = new BB();
            bb.Print();

            Console.WriteLine("Is aa SUPER?: {0}", aa is Super);
            Console.WriteLine("Is bb also SUPER?: {0}", bb is Super);

            Console.WriteLine("Then, Is aa AA?, {0}", aa is AA);
            Console.WriteLine("Then, Is bb BB?, {0}", bb is BB);

            // 불가: 형식이 부모 || 자식인 경우에는 부모의 필드 값을 우선 따름
            // Console.WriteLine(aa.a);

            // if (aa is AA aaDash) aaDash.Print(); // is와 타입 및 인스턴스 식별자를 써서 즉시 인스턴스를 생성해줄 수 있음
            // 물론 AA aaDash를 통해서 유효한 인스턴스가 만들어진 것이지 is 키워드 자체는 bool 형 값을 반환함
            AA aaDash = aa as AA;

            // AA 타입을 명시하고 필드 값을 출력해봄
            // Console.WriteLine(aaDash.a);

            if (aaDash is Super) Console.WriteLine("형변환을 해도 부모 타입으로 취급 받을 수 있음");
            else if (aaDash is AA) aaDash.Print();

            if (aaDash is AA) aaDash.Print();
            else if (aaDash is Super) Console.WriteLine("부모 || 자식 타입일 경우 정해진 우선순위는 없고 로직에서 우선순위 정해주는 걸 따라감");
        }
    }
}
