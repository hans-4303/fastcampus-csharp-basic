using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _149_join1
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
    /// <para>명확한 타입을 주기 위한 Result struct</para>
    /// </summary>
    public struct Result
    {
        public string name;
        public int total;
        public string gender;
    }

    /// <summary>
    /// <para>join 기초, struct끼리 join 해보기</para>
    /// <para>1. struct 생성</para>
    /// <para>
    ///     생성자 함수 가지는 지 그렇지 않은지 따라 생성 과정은 다를 수 있음
    /// </para>
    /// <para>2. LINQ 접근</para>
    /// <para>
    ///     기본 데이터를 순회 -> join으로 병합할 데이터 선택하고 순회 ->
    ///     on과 equals로 데이터 조건 지정
    /// </para>
    /// <para>
    ///     on은 기본 데이터에, equals는 병합할 데이터에 작성했음.
    /// </para>
    /// <para>
    ///     select new로 새로운 자료구조 반환,
    ///     select new Result 같이 자료구조를 명시할 수도 있고
    ///     select new { ... } 같이 필드와 값을 바로 줄 수도 있음
    /// </para>
    /// <para>
    ///     +, not equals 같은 문법은 없지만
    ///     where를 이용하여 비슷한 효과를 볼 수 있음
    ///     예) ... join detail in arrDetails on data._name equals detail._name "where" data._eng + data._kor != 150: 예시 조건
    /// </para>
    /// <para>
    ///     이 경우 tom은 기본 데이터에 있지만 병합할 데이터에 명시되어 있지 않고
    ///     join문의 on ~ equals 조건에 의해 필터링 되었기 때문에 출력되지 않았음: 내부 조인
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
                join detail in arrDetails on data._name equals detail._name
                select new
                {
                    name = data._name,
                    total = data._eng + data._kor,
                    gender = ( detail.gender == 0 ) ? "여자" : "남자"
                };
                //select new Result
                //{
                //    name = data._name,
                //    total = data._eng + data._kor,
                //    gender = ( detail.gender == 0 ) ? "여자" : "남자"
                //};

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
