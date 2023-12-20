using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _115_Indexer01
{
    /// <summary>
    /// <para>인덱서</para>
    /// <para>
    ///     사실 인덱서라는 기능이 있다고 하기보다 클래스를 만들 때
    ///     클래스 핵심 정보는 private 등을 통해 캡슐화할 거고 클래스 값을 직접 접근하도록 하지 않겠지만
    ///     우회해서 값을 입력할 수 있도록 해주는 내용에 가깝다 보임.
    /// </para>
    /// <para>1. private를 적용한 멤버가 있다고 가정</para>
    /// <para>2. this를 통해 인스턴스 자체가 호출됐을 때 취할 동작을 적음</para>
    /// <para>
    ///     접근지정은 public이기 때문에 클래스 밖에서도 사용 가능한 동작이 됨,
    ///     반환 값은 int이기 때문에 동작하고 나서 반환 값이 int일 것을 뜻함,
    ///     [int index]는 인스턴스를 호출할 때 aa[0]과 같이 동작할 수 있는 걸 뜻함,
    ///     get 동작을 통해 멤버 배열의 요소에 접근할 수 있게 되고
    ///     set 동작을 통해 할당되는 값을 멤버 배열 요소에 대입할 수 있게 됨.
    /// </para>
    /// </summary>
    public class AA
    {
        private readonly int[] num = new int[10];

        public int this[int index]
        {
            get { return num[index]; }
            set { num[index] = value; }
        }
    }

    internal class Program
    {
        /// <summary>
        /// <para>인덱서를 통한 접근</para>
        /// <para>1. 인스턴스를 생성함</para>
        /// <para>2. 클래스에 지정된 동작대로 작동</para>
        /// <para>
        ///     aa[i] = i, aa[0] = 1000; 등은 this와 함께 지정된 set 동작,
        ///     aa[i] 출력은 this와 함께 지정된 get 동작임.
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            AA aa = new AA();
            for ( int i = 0; i < 10; i++ ) { aa[i] = i; }

            aa[0] = 1000;
            aa[1] = 100;

            for ( int i = 0; i < 10; i++) Console.WriteLine("aa[{0}]: {1}", i, aa[i]);
        }
    }
}
