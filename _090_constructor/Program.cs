using System;

namespace _090_constructor
{
    /// <summary>
    /// 여러 생성자 함수를 갖는 클래스
    /// </summary>
    public class AA
    {
        private readonly int a;
        private readonly float f;
        private int count = 0;
        private static int staticCount = 0;

        /// <summary>
        /// 같은 클래스 안에도 생성자는 여러 개 만들 수 있음, 파라미터의 개수나 타입으로 구분됨
        /// </summary>
        public AA()
        {
            a = 0;
            f = 0f;
            Console.WriteLine("{0}, {1}", a, f);
        }

        /// <summary>
        /// 정수 하나만 들어온 생성자 함수
        /// 파라미터 이름과 필드 값이 같다면 this 키워드 써서 명시적 구분 가능
        /// </summary>
        /// <param name="a"></param>
        public AA(int a)
        {
            this.a = a;

            Console.WriteLine("{0}, {1}", this.a, f);
        }

        /// <summary>
        /// 정수와 소수 들어온 생성자 함수
        /// 파라미터와 이름이 같은 경우 및 다른 경우 작성해봄
        /// </summary>
        /// <param name="a"></param>
        /// <param name="_f"></param>
        public AA(int a, float _f)
        {
            // 필드 값 식별자와 파라미터 이름을 똑같게 쓴다면 this 키워드 사용도 괜찮음
            this.a = a;
            // 필드 값 식별자와 파라미터 이름을 다르게 쓴다면 this 키워드 없이 필드 값 식별자만 작성해도 인지함
            f = _f;

            Console.WriteLine("{0}, {1}", a, f);
        }

        /// <summary>
        /// 소멸자 함수:
        /// 소멸자 함수에는 어떤 파라미터도 넣을 수 없음.
        /// 인스턴스가 소멸할 때 호출됨 == componentDidUnmounted
        /// 
        /// static 키워드 없는 필드 값: 같은 클래스를 본 떠서 인스턴스를 여러 번 만들었다고 하더라도 필드 값은 각각 존재하기 때문에
        /// 인스턴스를 세 번 만들었다고 필드 값 count가 3이 되진 않음.
        /// 마치 리액트에서 특정 컴포넌트를 반복해서 부른다고 반복 되는 컴포넌트 내부 state가 반복 연산되지 않는 것과 유사한 원리임.
        /// 
        /// static 키워드 있는 필드 값: 인스턴스를 만들고 static 키워드 있는 필드 값을 다룬다면 인스턴스 생성 횟수만큼 반영됨.
        /// 인스턴스를 세 번 만들면 필드 값 staticCount가 3, 다섯 번 만들면 5로 만들 수 있음.
        /// 마치 반복되는 컴포넌트들이 앱 전역 상태를 조작하고 반영했다 연상할 수 있음.
        /// </summary>
        ~AA(/* int a (X) */)
        {
            Console.WriteLine("bye bye, {0}, {1}", ++count, ++staticCount);
        }
    }

    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            // 생성자 함수만 사용할 거라면 타입으로 사용되는 클래스명과 인스턴스 식별자 날려버리고 인스턴스 생성만 해도 됨
            _ = new AA();
            _ = new AA(10);
            _ = new AA(100, 0.5f);

            // ==
            // AA a1 = new AA();
            // AA a2 = new AA(10);
            // AA a3 = new AA(100, 0.5f);
        }
    }
}
