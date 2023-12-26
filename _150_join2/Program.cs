using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _150_join2
{
    /// <summary>
    /// <para>join을 위한 struct, 필드와 생성자 함수만 가짐</para>
    /// </summary>
    public struct Student
    {
        public int _id;
        public string _name;
        public int _kor;
        public int _eng;

        public Student (int _id, string _name, int _kor, int _eng)
        {
            this._id = _id;
            this._name = _name;
            this._kor = _kor;
            this._eng = _eng;
        }
    }

    /// <summary>
    /// <para>join을 위한 struct, 필드만 가짐</para>
    /// </summary>
    public struct Detail
    {
        public string _name;
        public int gender;
    }

    /// <summary>
    /// <para>외부 join을 이용한 LINQ 처리</para>
    /// <para>
    ///     join ~ in ~ on ~ equals 구문을 통해 기본 데이터.name과
    ///     병합 데이터._name이 같지 않을 경우 필터링 됐음.
    /// </para>
    /// <para>
    ///     into 구문이 큰 차이를 냈다 볼 수 있음.
    ///     만약 into 구문을 써서 범위 변수를 만들지 않았다면 위의 join ~ 구문은
    ///     { 인스턴스, 인스턴스, 인스턴스, 인스턴스 } 구조를 가지게 됨.
    /// </para>
    /// <para>
    ///     하지만 into 구문과 범위 변수를 생성함으로써
    ///     범위 변수는 { 인스턴스, 인스턴스, null, 인스턴스, 인스턴스 }와 같은 구조를 띔.
    /// </para>
    /// <para>
    ///     그래서 범위 변수를 대상으로 DefaultIfEmpty() 메서드를 적용할 수 있었고,
    ///     null인 요소에 new Detail(); 인스턴스를 만들며 값을 대입했음.
    ///     결과 범위 변수를 순회하되, null인 요소는 기본 인스턴스를 대입했음.
    /// </para>
    /// <para>
    ///     결과 기본 데이터와 조건에 따라 병합된 데이터,
    ///     그리고 해당 데이터를 순회하고 요소가 null일 경우 추가로 만든 인스턴스까지 다뤘다 볼 수 있음.
    ///     기본 데이터와 병합된 데이터끼리 일치하지 않는 행도 모두 반환하면서 사용했기 때문에 외부 join임.
    /// </para>
    /// <para>
    ///     데이터 누락을 허용하거나, 기본 값 설정 혹은 특정 값을 통해 빈 값 채우기를 할 때 외부 join을 사용할 것.
    /// </para>
    /// </summary>
    internal class Program
    {
        private static void Main ()
        {
            Student[] arrStudents =
            {
                new Student(){_id = 100, _name ="John", _kor = 100, _eng = 20},
                new Student(){_id = 200, _name ="Jane", _kor = 80, _eng = 20},
                new Student(300, "Tom", 51, 60),
                new Student(400, "Max", 83, 86),
                new Student(500, "Jack", 70, 70),
            };

            Detail[] arrDetails =
            {
                new Detail(){ _name = "John", gender = 1 },
                new Detail(){ _name = "Jane", gender = 0 },
                new Detail(){ _name = "Juliet", gender = 0 },
                new Detail(){ _name = "Max", gender = 1 },
                new Detail(){ _name = "Jack", gender = 1 },
            };

            var QueryData =
                from data in arrStudents
                join detail1 in arrDetails on data._name equals detail1._name into inData
                from detail2 in inData.DefaultIfEmpty(new Detail() { gender = 1 })
                select new
                {
                    name = data._name,
                    total = data._eng + data._kor,
                    gender = ( detail2.gender == 0 ) ? "여자" : "남자"
                };

            foreach (var item in QueryData)
            {
                Console.WriteLine("name: " + item.name);
                Console.WriteLine("gender: " + item.gender);
                Console.WriteLine("total: " + item.total);

                Console.WriteLine();
            }
        }
    }
}
