using System;

namespace _108_Encapsulation
{
    /// <summary>
    /// <para>프로퍼티를 통한 캡슐화</para>
    /// <para>1. 인스턴스화 할 수 있는 통상 클래스를 만듦</para>
    /// <para>
    ///     이때 해당 클래스만 알고 있는 필드 값을 둠
    ///     필드 값은 외부에서 직접 대입 혹은 참조될 수 없음
    /// </para>
    /// </summary>
    public class Person
    {
        private string name;
        private int age;
        
        public string Name
        {
            get { return name;  }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0) age = value;
                else throw new ArgumentException("나이는 음수일 수 없습니다.");
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine("이름: {0}, 나이: {1}", Name, Age);
        }
    }

    internal class Program
    {
        public static void Main(/* string[] args*/)
        {
            Person person = new Person("나스", 30);

            person.PrintInfo();

            Console.WriteLine("이름: {0}, 나이: {1}", person.Name, person.Age);

            person.Name = "김철수";
            person.Age = 25;

            person.PrintInfo();
        }
    }
}
