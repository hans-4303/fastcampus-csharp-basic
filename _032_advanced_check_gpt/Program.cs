using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_advanced_check_gpt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> valList = new List<object>();

            Console.Write("첫번째 데이터를 입력해주세요.");
            object val1 = Console.ReadLine();
            valList.Add(val1);

            Console.Write("두번째 데이터를 입력해주세요.");
            object val2 = Console.ReadLine();
            valList.Add(val2);

            Console.Write("세번째 데이터를 입력해주세요.");
            object val3 = Console.ReadLine();
            valList.Add(val3);

            Console.Write("네번째 데이터를 입력해주세요.");
            object val4 = Console.ReadLine();
            valList.Add(val4);

            for (int i = 0; i < valList.Count; i++)
            {
                if (valList[i] is string)
                {
                    if (int.TryParse((string)valList[i], out int intVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, intVal, intVal.GetType());
                    }
                    else if (float.TryParse((string)valList[i], out float floatVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, floatVal, floatVal.GetType());
                    }
                    else if (double.TryParse((string)valList[i], out double doubleVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, doubleVal, doubleVal.GetType());
                    }
                    else if (decimal.TryParse((string)valList[i], out decimal decimalVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, decimalVal, decimalVal.GetType());
                    }
                    else
                    {
                        Console.WriteLine("숫자로 변환할 수 없는 값이 입력되었습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("입력된 값이 문자열이 아닙니다.");
                }
            }
        }
    }
}
