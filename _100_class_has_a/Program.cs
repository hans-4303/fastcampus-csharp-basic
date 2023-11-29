using System;

namespace _100_class_has_a
{
    /// <summary>
    /// <para>어떠한 클래스를 포함하는 클래스: 컨테이너라 연상하면 됨</para>
    /// <para>1. 필드 값은 요소 클래스의 배열이라 선언함</para>
    /// <para>2. 생성자 호출 시 필드 값을 빈 배열로 초기화함 </para>
    /// <para>3. SetNum 메서드 호출 시 index와 num을 파라미터로 받음</para>
    /// <para>
    ///     index가 aa의 길이보다 작다면 필드 값 배열의 인덱스에 접근해서 인스턴스를 만듦
    ///     해당 요소에서 SetNum(num) 메서드를 다시 호출함
    /// </para>
    /// <para>4. Print 메서드 호출 시 필드 값 배열의 길이만큼 반복하고 요소가 있다면 해당 요소에서 Print() 메서드를 다시 호출함</para>
    /// </summary>
    public class AAContainer
    {
        readonly AAElement[] aa;

        public AAContainer()
        {
            aa = new AAElement[5];
        }

        public void SetNum(int index, int num)
        {
            if (index < aa.Length)
            {
                aa[index] = new AAElement();
                aa[index].SetNum(num);
            }
        }

        public void Print()
        {
            for (int i = 0; i < aa.Length; i++)
            {

                if (null != aa[i])
                    aa[i].Print();
            }
        }
    }

    /// <summary>
    /// <para>어떠한 클래스에 종속된 클래스: 이 경우 반복 호출되는 요소라 연상하면 됨</para>
    /// <para>1. 필드 값을 선언함</para>
    /// <para>2. SetNum 메서드 호출 시 num을 파라미터로 받고 필드 값에 대입함</para>
    /// <para>3. Print 메서드 호출 시 현재 필드 값 num을 출력함</para>
    /// </summary>
    public class AAElement
    {
        private int num;
        public void SetNum(int num)
        {
            this.num = num;
        }

        public void Print()
        {
            Console.WriteLine("{0}", num);
        }
    }

    /// <summary>
    /// <para>1. AA 요소 배열로 이루어진 컨테이너를 인스턴스로 만듦, 생성자에 의해 현재 AA 요소 자리는 5개 있음</para>
    /// <para>2. 컨테이너 인스턴스에서 SetNum 메서드를 호출 </para>
    /// <para>
    ///     index와 num을 받고 컨테이너에서 필드 값 배열에 해당하는 인덱스를 지목
    ///     해당 요소에 대해 SetNum 메서드를 호출하고 num 값을 넘겨줌
    ///     지정된 AA 요소에 대해 SetNum 메서드가 호출되어 값 대입
    /// </para>
    /// <para>3. 컨테이너 인스턴스에서 Print 메서드를 호출</para>
    /// <para>
    ///     컨테이너의 필드 값 배열 길이만큼 반복문 시작
    ///     만약 각 요소가 null이 아니라면 지정된 AA 요소에 대해 Print 메서드를 호출
    ///     SetNum에 의해 먼저 대입된 필드 값을 출력
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AAContainer aa = new AAContainer();
            aa.SetNum(0, 0);
            aa.SetNum(1, 100);
            aa.SetNum(2, 200);
            aa.SetNum(3, 200);

            aa.Print();
        }
    }
}
