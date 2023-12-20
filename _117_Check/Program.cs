using System;
using System.Collections;

namespace _117_Check
{
    /// <summary>
    /// <para>클래스는 그대로 사용됐음</para>
    /// <para>
    ///     필드 값들 전부 존재하고 Prop도 단순한 Get으로 짜임,
    ///     Input과 total 등 간단한 메서드로 구성됐음.
    /// </para>
    /// </summary>
    public class CStudent
    {
        private int id;
        private int ko;
        private int ma;
        private int en;

        public int ID { get { return id; } }
        public int KO { get { return ko; } }
        public int MA { get { return ma; } }
        public int EN { get { return en; } }

        public CStudent ()
        {
            this.id = 0;
            this.ko = 0;
            this.ma = 0;
            this.en = 0;
        }

        public void InputID ()
        {
            Console.Write("학생 ID를 등록하세요: ");
            id = Convert.ToInt32(Console.ReadLine());
        }
        public void InputKo ()
        {
            Console.Write("국어 점수를 입력하세요?: ");
            ko = Convert.ToInt32(Console.ReadLine());
        }
        public void InputMa ()
        {
            Console.Write("수학 점수를 입력하세요?: ");
            ma = Convert.ToInt32(Console.ReadLine());
        }
        public void InputEn ()
        {
            Console.Write("영어 점수를 입력하세요?: ");
            en = Convert.ToInt32(Console.ReadLine());
        }

        public void PrintID ()
        {
            Console.WriteLine("학생 ID: {0}", id);
        }

        public int GetTotal ()
        {
            return ko + ma + en;
        }
    }

    internal class Program
    {
        /// <summary>
        /// <para>ID 출력 메서드</para>
        /// <para>
        ///     Hashtable의 Key를 순회하면서 요소를 호출하고 캐스팅함,
        ///     캐스팅한 요소에서 PrintID 메서드 호출
        /// </para>
        /// </summary>
        /// <param name="students">학생들에 해당하는 Hashtable</param>
        static void PrintID (Hashtable students)
        {
            foreach (int key in students.Keys)
            {
                CStudent castStudent = (CStudent) students[key];
                castStudent.PrintID();
            }
        }

        /// <summary>
        /// <para>ID 체크 메서드</para>
        /// <para>
        ///     Hashtable이 key를 가지고 있다면 id를, 그렇지 않으면 -1 리턴
        /// </para>
        /// </summary>
        /// <param name="id">체크하고자 하는 ID</param>
        /// <param name="students">학생들에 해당하는 Hashtable</param>
        /// <returns></returns>
        static int CheckID (int id, Hashtable students)
        {
            if (students.ContainsKey(id)) return id;
            return -1;
        }

        /// <summary>
        /// <para>성적 입력을 Hashtable로 하는 로직</para>
        /// <para>1. 제어와 입력을 위한 변수 생성</para>
        /// <para>2. 학생들을 받을 Hashtable 생성(Hashtable의 배열로 생성해야 하는 건 아님)</para>
        /// <para>3. 첫번째 while문</para>
        /// <para>
        ///     a. 학생 ID 출력하기
        ///     b. 학생 입력 여부 묻기
        ///     c. CStudent 인스턴스 생성, 입력 메서드 호출하기
        ///     d. While문 스코프 밖에 있는 Hashtable의 요소로 temp를 추가하기
        /// </para>
        /// <para>
        ///     따라서 로직이 한 번 돌 때마다
        ///     hashStudents = {
        ///         55: CStudent(id, ko, ma, en),
        ///         12: CStudent(id, ko, ma, en),
        ///         ...
        ///     }
        ///     같은 구조로 누적되고, CStudent는 각각 새로운 인스턴스와 값을 갖게 됨.
        /// </para>
        /// <para>4. 두번째 while문</para>
        /// <para>
        ///     a. 학생 ID 출력하기
        ///     b. 학생 ID 입력 여부 묻기
        ///     c. 입력 값과 Hashtable을 인수로 받아서 학생 ID 체크하기
        ///     d. 값이 있다면 Hashtable[ID]와 같이 접근
        /// </para>
        /// <para>
        ///     접근하고 나면
        ///     hashStudents[55] == CStudent(id, ko, ma, en, ...),
        ///     hashStudents[12] == CStudent(id, ko, ma, en, ...)
        ///     와 같이 반환받을 수 있음, 캐스팅한 뒤 클래스의 Prop과 메서드를 사용
        /// </para>
        /// </summary>
        private static void Main (/* string[] args */)
        {
            int inputSel = 0;
            int selID = -1;

            Hashtable hashStudents = new Hashtable();

            while (true)
            {
                PrintID(hashStudents);
                Console.Write("== 성적 입력중 == (0)나가기  ");
                if (Console.ReadLine() == "0")
                    break;

                CStudent temp = new CStudent();
                temp.InputID();
                temp.InputKo();
                temp.InputMa();
                temp.InputEn();

                hashStudents.Add(temp.ID, temp);
                Console.WriteLine();
            }

            Console.Clear();

            while (true)
            {
                PrintID(hashStudents);
                Console.Write("학생 아이디를 입력하세요? (0)나가기  ");
                inputSel = int.Parse(Console.ReadLine());

                if (inputSel == 0)
                    break;

                selID = CheckID(inputSel, hashStudents);

                if (selID >= 0)
                {
                    CStudent selCStudent = (CStudent) hashStudents[selID];
                    Console.WriteLine("국어 점수:  {0}", selCStudent.KO);
                    Console.WriteLine("수학 점수:  {0}", selCStudent.MA);
                    Console.WriteLine("영어 점수:  {0}", selCStudent.EN);

                    int total = selCStudent.GetTotal();

                    Console.WriteLine("총점:  {0}", total);
                    Console.WriteLine("평균:  {0}", total / 3f);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("학생 아이디가 없어요. 다시 입력하세요");
                }
            }
        }
    }
}
