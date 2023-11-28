using System;

namespace _088_class_greeting
{
    /// <summary>
    /// 클래스와 함께 생성자도 접근 한정자로 접근 수준 정해줄 필요 있음
    /// </summary>
    public class StiffCalculator
    {
        public readonly int x, y;
        public StiffCalculator(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int StiffAdd() { return x + y; }
        public int StiffSubtract() { return x - y; }
        public int StiffMultyply() { return x * y; }
        public int StiffDivide() { return x / y; }
    }

    /// <summary>
    /// 계산기 클래스 생성해봄
    /// 필드 값을 따로 준 것은 아님
    /// 사칙 연산에 대한 메서드만 생성했고, 연산은 각 메서드가 파라미터 받았을 때 진행하며 결과 값 반환
    /// 
    /// 이때, 꼭 class Program 내부에 있지 않아도 클래스 생성 및 호출은 괜찮음
    /// (접근 한정자가 public 이라면)
    /// </summary>
    public class Calculator
    {
        public int Add(int x, int y) { return x + y; }
        public int Subtract(int x, int y) { return x - y; }
        public int Multyply(int x, int y) { return x * y; }
        public int Divide(int x, int y) { return x / y; }
    }

    /// <summary>
    /// 필드 값을 가지고, 생성자를 통해 초기화 할 수 있다 가정한 경우
    /// </summary>
    public class NameTag
    {
        public string name;

        /// <summary>
        /// 클래스 내부에 더미 값을 유지시킨 생성자.
        /// 
        /// 출력 시도 시 공백 외에는 확인되지 않았고
        /// GetType() 출력을 시도해도 잘 동작하지 않음.
        /// 
        /// 생성자 자체만 두고, 아무 기능도 하지 않는 깡통 생성자를 만들 수는 있음.
        /// 이 경우 this.name이 초기화 되지 않는다 전제할 수 있고, this.name !== null 조건으로 처리도 가능하며 에러도 없었음.
        /// </summary>
        public NameTag()
        {
            // Console.WriteLine(this.name);
            // Console.WriteLine(this.name.GetType());
        }

        /// <summary>
        /// 생성자를 새로 만들고, 인스턴스 생성 할 때 필드 값을 줬다 가정할 경우
        /// 필드 값에 파라미터로 받아온 값을 대입할 수 있음.
        /// </summary>
        /// <param name="name"></param>
        public NameTag(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name ?? "아직 이름을 입력하지 않으셨습니다.";
        }
        public void SetName(string name)
        {
            this.name = name;
        }
    }

    /// <summary>
    /// 클래스 개념:
    /// 
    /// 클래스는 사용자가 직접 만든 틀
    /// 변수(클래스 내부의 값들)과 함수(메서드)를 하나의 단위로 결합
    /// 
    /// 상속, 다형성, 파생이 가능:
    /// 클래스의 특수화 메커니즘
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// private || protected는 특정 클래스 안에서만 접근하고자 할 때 유용한 걸로 짐작됨
        /// </summary>
        private class Printer
        {
            /// <summary>
            /// 단 메서드들은 private || protected로 한정하기 곤란했음
            /// 호출이 안 된다
            /// </summary>
            /// <param name="text"></param>
            public void PrintToWrite(string text)
            {
                Console.WriteLine(text);
            }
        }

        private static void Main()
        {
            // 클래스 타입 명시하고 인스턴스 만들기, 필드 값이 있지는 않음
            // 필드 값이 필요하다면 생성자를 따로 만들어야 할 것
            Calculator cal = new Calculator();

            // 인스턴스에서 메서드 호출하고 인수 대입하여 사용
            Console.WriteLine(cal.Add(1, 3));
            Console.WriteLine(cal.Subtract(6, 10));
            Console.WriteLine(cal.Multyply(6, 6));
            Console.WriteLine(cal.Divide(21, 3));

            Console.WriteLine("--------------------\n");

            // 접근 한정자를 통해 현재 클래스에서만 Printer 인스턴스 생성 가능
            Printer pri = new Printer();
            // 인스턴스에서 메서드는 접근 한정자로 제어하기 곤란했음
            pri.PrintToWrite("끄적끄적");

            Console.WriteLine("--------------------\n");

            // 접근자를 통해 인스턴스 생성 시 필드 값을 초기화 하는 경우
            NameTag nameTag = new NameTag("aaa");
            Console.WriteLine(nameTag.GetName());

            Console.WriteLine("--------------------\n");

            // 접근자를 기본 값으로 돌리고 인스턴스 생성 시 필드 값을 초기화 하지 않는 경우
            NameTag newNameTag = new NameTag();
            Console.WriteLine(newNameTag.GetName());

            Console.WriteLine("--------------------\n");

            StiffCalculator stiffCal = new StiffCalculator(2, 3);
            Console.WriteLine(stiffCal.StiffAdd());
            Console.WriteLine(stiffCal.StiffSubtract());
            Console.WriteLine(stiffCal.StiffMultyply());
            Console.WriteLine(stiffCal.StiffDivide());

            Console.WriteLine("--------------------\n");
        }
    }
}
