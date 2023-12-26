using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _158_File_CSV
{
    /// <summary>
    /// <para>CSV 파일의 Column과 같은 클래스, get set 동작 정의</para>
    /// </summary>
    public class Stage
    {
        public string stage { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int finish { get; set; }
        public int gold { get; set; }
    }

    internal class Program
    {
        /// <summary>
        /// <para>CSV 파일 활용</para>
        /// <para>1. 파일 이름, 인덱스와 리스트 설정</para>
        /// <para>2. using을 통한 StreamReader 인스턴스 초기화</para>
        /// <para>
        ///     StreamReader 인스턴스 생성 시 인수로 new FileStream(파일 이름, FileMode enum)을 줄 수 있음
        /// </para>
        /// <para>3. StreamReader 인스턴스를 순회</para>
        /// <para>
        ///     해당 Line에서 ,을 기준으로 요소를 잘라 배열로 만듦.
        ///     Stage 인스턴스를 만들고 정확한 요소를 파싱 혹은 컨버트,
        ///     List.Add("인스턴스")로 처리.
        /// </para>
        /// <para>4. List를 순회, 알맞게 출력하기</para>
        /// <para>+ String.Split("기준 문자열")도 인지하기</para>
        /// </summary>
        private static void Main ()
        {
            const string fileName = "test.csv";

            int index = 0;
            List<Stage> listStage = new List<Stage>();

            using (StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                //while(false == sr.EndOfStream) {
                //    Console.WriteLine(sr.ReadLine());
                //}

                while (false == sr.EndOfStream)
                {
                    string readStr = sr.ReadLine();

                    if (index++ >= 1)
                    {
                        string[] splitData = readStr.Split(',');

                        Stage temp = new Stage
                        {
                            stage = splitData[0],
                            min = Convert.ToInt32(splitData[1]),
                            max = Convert.ToInt32(splitData[2]),
                            finish = Convert.ToInt32(splitData[3]),
                            gold = Convert.ToInt32(splitData[4])
                        };
                        listStage.Add(temp);
                    }
                }
            }

            foreach (var d in listStage)
            {
                Console.Write("{0} {1} {2} {3} {4}", d.stage, d.min, d.max, d.finish, d.gold);
                Console.WriteLine();
            }
            Console.WriteLine();

            string str = "0, 1, 2, 3, 4, 5";
            string[] splitRead = str.Split(',');
            for (int i = 0; i < splitRead.Length; i++)
            {
                Console.Write(" {0} ", splitRead[i]);
            }
        }
    }
}
