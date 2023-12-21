using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _135_communicationClassWithGeneric
{
    public class EventPublisher<T>
    {
        public event Action<T> DataChanged;

        private T data;

        public T Data
        {
            get { return data; }
            set
            {
                try
                {
                    // 예외 처리
                    if (EqualityComparer<T>.Default.Equals(value, default(T)))
                    {
                        throw new ArgumentException("Data value must not be default.");
                    }

                    data = value;
                    OnDataChanged();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception caught in EventPublisher: {ex.Message}");
                }
            }
        }

        protected virtual void OnDataChanged ()
        {
            DataChanged?.Invoke(Data);
        }
    }

    public class EventSubscriber<T>
    {
        public void Subscribe (EventPublisher<T> publisher)
        {
            publisher.DataChanged += data =>
            {
                try
                {
                    // 예외 처리
                    if (EqualityComparer<T>.Default.Equals(data, default(T)))
                    {
                        throw new ArgumentException("Invalid data value detected.");
                    }

                    Console.WriteLine($"Data changed via anonymous function: {data}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in EventSubscriber: {ex.Message}");
                }
            };
        }
    }

    internal class Program
    {
        static void Main ()
        {
            EventPublisher<int> intPublisher = new EventPublisher<int>();
            EventSubscriber<int> intSubscriber = new EventSubscriber<int>();
            intSubscriber.Subscribe(intPublisher);

            // 데이터 변경
            intPublisher.Data = 0; // 값 데이터 형의 기본 값 0을 넣으면 예외 처리
            intPublisher.Data = 42;

            // 다른 타입의 이벤트 발행자와 구독자
            EventPublisher<string> stringPublisher = new EventPublisher<string>();
            EventSubscriber<string> stringSubscriber = new EventSubscriber<string>();
            stringSubscriber.Subscribe(stringPublisher);

            // 데이터 변경
            stringPublisher.Data = null; // 참조 형 데이터의 기본 값 null을 넣으면 예외 처리
            stringPublisher.Data = "hello";

            /**
             * 
             * 일부러 publisher와 subscriber를 맞추지 않아봄
             * 하지만 Subscriber 클래스와 메서드 모두 제네릭으로 선언된 타입을 토대로 따지기 때문에
             * 컴파일 단계부터 다른 제네릭으로 생성된 인스턴스들을 매칭할 수 없다 확인됨.
             * 
             * EventPublisher<int> wrongPublisher = new EventPublisher<int>();
             * EventSubscriber<string> wrongSubscriber = new EventSubscriber<string>();
             * wrongSubscriber.Subscribe(wrongPublisher);
             */
        }
    }
}
