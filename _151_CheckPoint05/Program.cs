using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _151_CheckPoint05
{
    /// <summary>
    /// <para>메인 메서드에서 사용할 클래스</para>
    /// </summary>
    public class CStudent
    {
        /// <summary>
        /// <para>private로 은닉된 필드, 생성자 함수로만 움직이기 때문에 readonly도 가능해보임.</para>
        /// </summary>
        private readonly int id;
        private readonly int kor;
        private readonly int math;
        private readonly int eng;
        private readonly int total;

        /// <summary>
        /// <para>public으로 허용된 Prop, 필드 값 반환</para>
        /// </summary>
        public int ID { get { return id; } }
        public int KOR { get { return kor; } }
        public int MATH {  get { return math; } }
        public int ENG { get { return eng; } }
        public int TOTAL { get { return total; } }

        /// <summary>
        /// <para>생성자 함수를 통한 인스턴스 생성, param 값을 대입해서 생성 가능</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kor"></param>
        /// <param name="math"></param>
        /// <param name="eng"></param>
        public CStudent(int id, int kor, int math, int eng)
        {
            this.id = id;
            this.kor = kor;
            this.math = math;
            this.eng = eng;
            this.total = kor + math + eng;
        }
    }

    internal class Program
    {
        /// <summary>
        /// <para>임의 학생 데이터 생성</para>
        /// <para>
        ///     0 0 0 0,
        ///     1 ? ? ?,
        ///     ...
        /// </para>
        /// </summary>
        /// <param name="_students"></param>
        private static void InitData(List<CStudent> _students)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                CStudent data = new CStudent(i, random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));
                _students.Add(data);
            }
        }

        /// <summary>
        /// <para>리스트 출력 함수, List를 순회하면서 각 요소 Prop을 지정하고 표처럼 출력해줌</para>
        /// </summary>
        /// <param name="_students"></param>
        private static void PrintList(List<CStudent> _students)
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "ID", "KOR", "MATH", "ENG", "TOTAL");
            Console.WriteLine("==========================================================");
            foreach (var item  in _students)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", item.ID, item.KOR, item.MATH, item.ENG, item.TOTAL);
            }
        }

        /// <summary>
        /// <para>정렬 함수: List.Sort 메서드 사용하고 delegate 혹은 람다식으로 진행</para>
        /// <para>
        ///     정렬 이후 출력 함수 호출하고 결과 List를 인수로 넘기기
        /// </para>
        /// </summary>
        /// <param name="_students"></param>
        private static void SortByID(List<CStudent> _students)
        {
            //_students.Sort(delegate (CStudent a, CStudent b)
            //    {
            //        if (a.ID > b.ID) return 1;
            //        else if (a.ID < b.ID) return -1;
            //        else return 0;
            //    }
            //);
            _students.Sort((a, b) =>
            {
                if (a.ID > b.ID) return 1;
                else if (a.ID < b.ID) return -1;
                else return 0;
            });
            Console.WriteLine("아이디 순에 따른 정렬 완료");
            PrintList( _students );
        }

        /// <summary>
        /// <para>정렬 함수: LINQ 이용하고 List로 변환</para>
        /// </summary>
        /// <param name="_students"></param>
        private static void SortByTotal(List<CStudent> _students)
        {
            var els = from el in _students
            orderby el.TOTAL descending
            select el;

            List<CStudent> sortedStudents = els.ToList<CStudent>();

            Console.WriteLine("총점 순에 따른 정렬 완료");
            PrintList(sortedStudents);
        }

        /// <summary>
        /// <para>정렬 함수: List.Sort 메서드 호출하고 람다식으로 진행</para>
        /// </summary>
        /// <param name="_students"></param>
        private static void SortByKor(List<CStudent> _students)
        {
            _students.Sort((CStudent a, CStudent b) => { return b.KOR - a.KOR; });

            Console.WriteLine("국어 점수 순에 따른 정렬 완료");
            PrintList(_students);
        }

        /// <summary>
        /// <para>범위에 따른 검색 함수: isUp 변수 따라서 이상, 이하 찾기</para>
        /// <para>
        ///     필요하다면 예외 처리, try catch finally 블록 활용.
        ///     isUp 변수 따라서 이상, 이하 결과를 찾고
        ///     LINQ 혹은 List.FindAll() 메서드는 자유롭게 골라도 됨.
        /// </para>
        /// </summary>
        /// <param name="_students"></param>
        /// <param name="isUp"></param>
        private static void FindDataByRange(List<CStudent> _students, bool isUp)
        {
            if (isUp)
            {
                Console.WriteLine("총점 몇 점 이상을 찾으시겠습니까? (점수를 입력하세요.)");
            }
            else
            {
                Console.WriteLine("총점 몇 점 이하를 찾으시겠습니까? (점수를 입력하세요.)");
            }

            string totalTrigger = Console.ReadLine();
            int num = 0;

            try
            {
                num = int.Parse(totalTrigger);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("입력 값으로 {0}이 들어왔습니다. 숫자만 입력하세요.", num);
            }
            finally
            {
                if (num < 0)
                {
                    Console.Clear();
                    Console.WriteLine("작은 수를 입력하셨습니다.");
                }
                if (num > 300)
                {
                    Console.Clear();
                    Console.WriteLine("큰 수를 입력하셨습니다.");
                }
            }

            if(num >= 0 && num <= 300)
            {
                if(isUp)
                {
                    var findData =
                    from student in _students
                    where student.TOTAL >= num
                    select student;

                    List<CStudent> outputData = findData.ToList<CStudent>();
                    PrintList(outputData);

                    // SortByID(outputData);
                    // SortByTotal(outputData);
                }
                else
                {
                    List<CStudent> outputData = _students.FindAll((student) => student.TOTAL < num);
                    PrintList(outputData);
                    // SortByID(outputData);
                    // SortByTotal(outputData);
                }
            }
        }

        /// <summary>
        /// <para>무한 반복 프로그램으로 작성하고 List와 초기화 함수 실행 후 루프 돌기</para>
        /// </summary>
        private static void Main ()
        {
            bool isLoop = true;

            List<CStudent> students = new List<CStudent>();
            InitData(students);

            do
            {
                Console.WriteLine("메뉴를 골라주세요");
                Console.Write("(1): ID 정렬 (2) 성적순 정렬 (3) 국어 점수 정렬 (4) 특정 점수 이상 검색 (5) 특정 점수 이하 검색 (0) 나가기");
                string inputTrigger = Console.ReadLine();
                switch(inputTrigger)
                {
                    case "0":
                        Console.WriteLine("프로그램 종료");
                        isLoop = false;
                        break;
                    case "1":
                        SortByID(students);
                        break;
                    case "2":
                        SortByTotal(students);
                        break;
                    case "3":
                        SortByKor(students);
                        break;
                    case "4":
                        FindDataByRange(students, true);
                        break;
                    case "5":
                        FindDataByRange(students, false);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("메뉴에 맞는 숫자를 입력해주세요.");
                        break;
                }
            } while (isLoop);
        }
    }
}
