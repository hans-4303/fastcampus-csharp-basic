using System;

namespace _109_check1
{
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

        public CStudent()
        {
            this.id = 0;
            this.ko = 0;
            this.ma = 0;
            this.en = 0;
        }

        public void InputID()
        {
            Console.Write("학생 ID를 등록하세요: ");
            id = Convert.ToInt32(Console.ReadLine());
        }
        public void InputKo()
        {
            Console.Write("국어 점수를 입력하세요?: ");
            ko = Convert.ToInt32(Console.ReadLine());
        }
        public void InputMa()
        {
            Console.Write("수학 점수를 입력하세요?: ");
            ma = Convert.ToInt32(Console.ReadLine());
        }
        public void InputEn()
        {
            Console.Write("영어 점수를 입력하세요?: ");
            en = Convert.ToInt32(Console.ReadLine());
        }

        public void PrintID()
        {
            Console.WriteLine("학생 ID: {0}", id);
        }

        public int GetTotal()
        {
            return ko + ma + en;
        }
    }

    internal class Program
    {
        static void PrintID(CStudent[] arrStudents)
        {
            foreach(CStudent data in arrStudents)
            {
                data.PrintID();
            }
        }

        static int CheckID(int id, CStudent[] arrStudents)
        {
            for(int i = 0; i < arrStudents.Length; i++)
            {
                if (id == arrStudents[i].ID) return i;
            }
            return -1;
        }

        private static void Main(/* string[] args */)
        {
            // 검증할 인원
            const int PERSONNEL = 3;
            CStudent[] arrStudents = new CStudent[PERSONNEL];

            for(int i = 0; i < PERSONNEL; i++)
            {
                arrStudents[i] = new CStudent();
                arrStudents[i].InputID();
                arrStudents[i].InputKo();
                arrStudents[i].InputMa();
                arrStudents[i].InputEn();

                Console.WriteLine();
            }

            while(true)
            {
                PrintID(arrStudents);
                Console.Write("학생 ID를 입력하세요. 혹은 (0)으로 나가기");
                int inputSel = Convert.ToInt32(Console.ReadLine());
                if (inputSel == 0) break;

                int selID = CheckID(inputSel, arrStudents);
                if (selID >= 0)
                {
                    Console.WriteLine("국어 점수: {0}", arrStudents[selID].KO);
                    Console.WriteLine("수학 점수: {0}", arrStudents[selID].MA);
                    Console.WriteLine("영어 점수: {0}", arrStudents[selID].EN);

                    int total = arrStudents[selID].GetTotal();

                    Console.WriteLine("총점: {0}", total);
                    Console.WriteLine("평균: {0}", total / (float)PERSONNEL);

                    Console.WriteLine();
                }
                else Console.WriteLine("학생 ID가 없습니다. 다시 입력해주세요.");
            }
        }
    }
}
