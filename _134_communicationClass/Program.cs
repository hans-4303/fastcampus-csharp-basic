using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _134_communicationClass
{
    /// <summary>
    /// <para>이벤트 발행 클래스, 이벤트 인지와 Prop 관리를 맡음</para>
    /// </summary>
    public class EventPublisher
    {
        /// <summary>
        /// <para>
        ///     직접 delegate 키워드를 쓴 건 아니지만
        ///     파라미터로 int를 받고 반환 값이 없는 메서드를 참조할 수 있는 델리게이트를 나타냄.
        /// </para>
        /// </summary>
        public event Action<int> DataChanged;

        /// <summary>
        /// <para>private로 숨겨진 필드 값</para>
        /// </summary>
        private int data;

        /// <summary>
        /// <para>필드 값에 대한 Prop, get과 get 동작으로 구분됨</para>
        /// </summary>
        public int Data
        {
            get { return data; }
            set
            {
                data = value;
                // 델리게이트 이벤트 발생
                OnDataChanged();
            }
        }

        /// <summary>
        /// <para>이벤트 발생 메서드</para>
        /// <para>
        ///     호출되면 DataChanged 이벤트 핸들러에게 알림,
        ///     DataChanged 이벤트가 null이 아니라면
        ///     Invoke를 통해 해당 델리게이트가 참조하는 메서드를 실행하고 Data Prop을 대입
        /// </para>
        /// </summary>
        protected virtual void OnDataChanged ()
        {
            // 델리게이트 이벤트 호출
            DataChanged?.Invoke(Data);
        }
    }

    /// <summary>
    /// <para>이벤트 구독 클래스, 다른 인스턴스 다루기와 델리게이트 접근 및 동작을 맡음</para>
    /// <para>
    ///     Subscribe 메서드는 EventPublisher 클래스의 인스턴스를 파라미터로 받고 동작함,
    ///     클래스의 DataChanged 델리게이트에 접근해서
    ///     data를 인수로 받고 출력하는 화살표 함수를 대입함
    /// </para>
    /// </summary>
    public class EventSubscriber
    {
        // 익명 함수를 이용한 이벤트 핸들러 등록
        public void Subscribe (EventPublisher publisher)
        {
            publisher.DataChanged += data => Console.WriteLine($"Data changed via anonymous function: {data}");

            /** 
             * // 람다식을 풀어서 쓴 익명 함수
             * publisher.DataChanged += delegate(int data)
             * {
             *  Console.WriteLine($"Data changed via anonymous function: {data}");
             * };
             */
        }
    }

    /// <summary>
    /// <para>클래스 간 통신 케이스</para>
    /// <para>
    ///     두 클래스 각각 인스턴스 만듦,
    ///     구독 인스턴스에서 구독 메서드를 호출하고 발행 인스턴스를 대입함,
    ///     받아온 발행 인스턴스의 DataChanged 델리게이트에 접근해
    ///     동작할 함수를 대입함.
    /// </para>
    /// <para>
    ///     발행 인스턴스의 Data Prop에 접근하고 set 동작
    ///     -> OnDataChanged() 메서드 호출해서 DataChanged 델리게이트에 로직 있는지 확인 후
    ///     DataChanged에 Subscribe를 통해 대입된 로직 호출,
    ///     Data는 data = value 과정을 통해 이미 넘어갔으니 get할 수 있는 걸로 보임
    /// </para>
    /// </summary>
    internal class Program
    {
        static void Main ()
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            // 익명 함수를 이용한 이벤트 핸들러 등록
            subscriber.Subscribe(publisher);

            // 데이터 변경
            publisher.Data = 42;
            publisher.Data = 84;
        }
    }
}
