using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _033_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> scores = new List<string>();
            int sum = 0;
            float avg = 0.0f;

            Console.Write("국어 점수 입력: ");
            string ko = Console.ReadLine();
            scores.Add(ko);
            Console.Write("영어 점수 입력: ");
            string en = Console.ReadLine();
            scores.Add(en);
            Console.Write("수학 점수 입력: ");
            string ma = Console.ReadLine();
            scores.Add(ma);
            Console.Write("과학 점수 입력: ");
            string sc = Console.ReadLine();
            scores.Add(sc);

            for(int i = 0; i < scores.Count; i++)
            {
                if (scores[i] is  string)
                {
                    if (int.TryParse((string)scores[i], out int intVal))
                    {
                        sum += intVal;
                    }
                }
            }

            avg = (float)sum / scores.Count;

            Console.WriteLine("국어: {0}, 영어: {1}, 수학: {2}, 과학: {3}", ko, en, ma, sc);
            Console.WriteLine("총점: {0}, 평균: {1}", sum, avg);
        }
    }
}
