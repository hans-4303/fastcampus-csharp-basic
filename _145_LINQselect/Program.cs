using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _145_LINQselect
{
    /// <summary>
    /// <para>간단하게 쓰일 struct, 값과 파라미터 위주로 구성</para>
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

    public struct StudentDash
    {
        public int id;
        public string name;
        public int total;

        // 명시적으로 호출될 생성자
        public StudentDash (int _id, string _name, int _kor, int _eng)
        {
            this.id = _id;
            this.name = _name;
            this.total = _kor + _eng;
        }
    }

    /// <summary>
    /// <para>LINQ: select</para>
    /// <para>
    ///     LINQ에서 세부 요소를 선택하거나 지정하는 과정을 select로 처리할 수 있음.
    /// </para>
    /// <para>1. struct 배열을 생성하고 요소 생성, 생성자로도 가능하고 필드 지명해도 상관 없음</para>
    /// <para>2. 배열을 지정해서 LINQ 순회</para>
    /// <para>
    ///     a. 순회할 요소에 이름 붙이기
    ///     b. 순회할 요소에 멤버가 있다면 조회 가능(웬만하면 클래스에서는 Prop으로 정의했을 것)
    ///     c. 세부 조건으로 순회할 요소의 멤버 값을 비교
    ///     d. select로 요소를 뱉어내지만 new {} 작성 가능,
    ///     새로운 멤버를 가진 새로운 자료형으로 뱉어낼 수 있음.
    ///     e. select로 요소를 뱉어낼 때는 디폴트 생성자로 생각하면 됨.
    ///     f. 자료형을 뱉어낼 때 var로 뱉어내서 유연성을 올릴 수도 있고,
    ///     자료형을 명시해서 가독성과 안정성을 챙길 수도 있음
    ///     g. select를 통해 요소 생성할 시 특별한 초기화 로직이 필요하다면
    ///     사용자 정의 생성자를 호출해서 인스턴스를 만들어줘도 됨.
    /// </para>
    /// </summary>
    internal class Program
    {
        static void Main ()
        {
            Student[] arrStudents =
            {
                new Student(){_id = 100, _name ="John", _kor = 100, _eng = 20},
                new Student(){_id = 200, _name ="Jane", _kor = 80, _eng = 20},
                new Student(300, "Tom", 50, 60),
                new Student(400, "Max", 80, 80),
                new Student(500, "Jack", 70, 70),
            };

            var QueryData1 =
                from data in arrStudents
                where data._id > 200 && data._kor > 50
                select new
                {
                    id = data._id,
                    name = data._name,
                    total = data._kor + data._eng
                };

            IEnumerable<StudentDash> QueryData2 =
                from data in arrStudents
                where data._id > 200 && data._kor > 50
                select new StudentDash
                {
                    id = data._id,
                    name = data._name,
                    total = data._kor + data._eng
                };

            IEnumerable<StudentDash> QueryData3 =
                from data in arrStudents
                where data._id > 200 && data._kor > 50
                select new StudentDash(data._id, data._name, data._kor, data._eng);

            foreach (var data in QueryData3)
            {
                Console.WriteLine("data.id: " + data.id);
                Console.WriteLine("data.name: " + data.name);
                Console.WriteLine("data.total: " + data.total);
                Console.WriteLine();
            }
        }
    }
}
