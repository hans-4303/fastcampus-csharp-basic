using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _148_LINQgroup2
{
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

    internal class Program
    {
        /// <summary>
        /// <para>종합</para>
        /// <para>
        ///     group ~ by ~ into +
        ///     orderby +
        ///     select "그룹 변수"
        ///     구성
        /// </para>
        /// <para>1. 데이터 순회</para>
        /// <para>2. 데이터를 평균 / 10으로 그룹화하고 gTemp 그룹 배열에 대입, 그룹화된 게 인덱스에 반영</para>
        /// <para>3. 그룹 변수의 키대로 정렬: 이때 5 6 7 8 키가 생겼고 by 조건으로 만들어졌음</para>
        /// <para>4. 그룹 배열 선택</para>
        /// <para>5. 쿼리 데이터를 foreach로 순회하여 그룹 접근, data.Key Prop 활용해서 계산</para>
        /// <para>6. 그룹 데이터를 foreach로 순회하여 학생 접근, 필드 활용해서 계산하고 출력</para>
        /// </summary>
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

            var QueryData =
                from student in arrStudents
                // tempGroup[0] == Key: 5, Jane, Tom
                group student by ( ( student._eng + student._kor ) / 2 ) / 10 into tempGroup
                // tempGroup.Key == ( ( student._eng + student._kor ) / 2 ) / 10
                orderby tempGroup.Key ascending
                select tempGroup;

            foreach (var group in QueryData)
            {
                Console.WriteLine("data: {0} 에서 {1}", group.Key * 10, ( group.Key + 1 ) * 10);

                foreach (var student in group)
                {
                    Console.WriteLine("\t name: {0}, avg: {1}", student._name, ( student._kor + student._eng ) / 2f);
                }
            }
        }
    }
}
