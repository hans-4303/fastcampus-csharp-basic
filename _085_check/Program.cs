using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _085_check
{
    internal class Program
    {
        static void InputId(int[] students, int index)
        {
            Console.Write("학생 ID를 등록하세요: ");
            int id = Convert.ToInt32(Console.ReadLine());
            // call by reference 때문에
            students[index] = id;
        }

        static void InputKor(int[] kors, int index)
        {
            Console.Write("국어 점수를 입력하세요?: ");
            int kor = Convert.ToInt32(Console.ReadLine());
            kors[index] = kor;
        }

        static void InputMath(int[] maths, int index)
        {
            Console.Write("수학 점수를 입력하세요?: ");
            int math = Convert.ToInt32(Console.ReadLine());
            maths[index] = math;
        }

        static void InputEng(int[] engs, int index)
        {
            Console.Write("영어 점수를 입력하세요?: ");
            int eng = Convert.ToInt32(Console.ReadLine());
            engs[index] = eng;
        }

        // 간단하게 입력된 배열을 출력한다 생각하면 됐음
        // 첫번째 파라미터 max는 반복 횟수임
        static void PrintId(int max, int[] ID)
        {
            for(int i = 0; i < max; i++) Console.WriteLine("학생 ID: {0}", ID[i]);
        }

        // 함수 전에 선언된 id(Console.ReadLine())이 입력된 값과 일치하는지 체크
        // 및 여러 배열에 접근할 수 있도록 인덱스 반환
        static int SelectIdToIndex(int id, int max, int[] ID)
        {
            // 입력된 배열 길이만큼, i == max일 때 끝나므로 인덱스 구조와 같음
            for (int i = 0; i < max; i++)
            {
                // 받은 값이 배열의 요소와 같다면
                if (id == ID[i])
                {
                    // 해당 인덱스를 리턴
                    return i;
                }
            }
            // 반복을 끝내도 해당 값이 없다면 -1 리턴하고 조건으로 활용
            return -1;
        }

        static void Main(string[] args)
        {
            // 검증할 인원
            const int PERSONNEL = 3;

            // 검증할 인원만큼 배열 초기화
            int[] students = new int[PERSONNEL];
            int[] kors = new int[PERSONNEL];
            int[] maths = new int[PERSONNEL];
            int[] engs = new int[PERSONNEL];

            // 학생 ID 입력받을 변수
            int inputStudentID = 0;
            // 선택된 인덱스 할당받을 변수
            int selectedIndex = -1;
            
            // 인원만큼 함수 반복 호출
            for(int i = 0; i < PERSONNEL; i++)
            {
                InputId(students, i);
                InputKor(kors, i);
                InputMath(maths, i);
                InputEng(engs, i);

                Console.WriteLine();
            }

            Console.Clear();

            while (true)
            {
                // 단순히 배열 반복 출력하는 함수
                PrintId(PERSONNEL, students);
                // 입력과 검증 부분
                Console.Write("학생 아이디를 입력하세요. (0) 나가기");
                inputStudentID = int.Parse(Console.ReadLine());
                // ID를 입력하지 않고 0 입력했다면 스코프 끝내기
                if (inputStudentID == 0) break;

                // ID를 입력했다면 입력 값과 인원수, 학생 배열을 인수로 ID 체크 함수 호출하고 값 반환
                // 인덱스 형태로 반환됨
                selectedIndex = SelectIdToIndex(inputStudentID, PERSONNEL, students);

                // ID 배열 중 어느 인덱스와 같은 값이 나왔다면
                if (selectedIndex >= 0)
                {
                    // 각 배열에 인덱스로 접근하고 출력
                    Console.WriteLine("국어 점수: {0}", kors[selectedIndex]);
                    Console.WriteLine("수학 점수: {0}", maths[selectedIndex]);
                    Console.WriteLine("영어 점수: {0}", engs[selectedIndex]);

                    // 합산
                    int total = kors[selectedIndex] + maths[selectedIndex] + engs[selectedIndex];

                    // 출력
                    Console.WriteLine("총점: {0}", total);
                    Console.WriteLine("평균: {0}", total / (float)PERSONNEL);

                    Console.WriteLine();
                }
                // 입력 값은 있지만 ID 배열 중 어느 인덱스와도 같은 값이 나오지 않아 -1 반환된 경우
                else Console.WriteLine("해당 학생 ID가 없습니다, 다시 입력하세요.");
            }
        }
    }
}
