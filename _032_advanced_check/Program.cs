using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _032_advanced_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] valArr = { };

            Console.Write("첫번째 데이터를 입력해주세요.");
            object val1 = Console.ReadLine();
            valArr = valArr.Append(val1).ToArray();
            Console.Write("두번째 데이터를 입력해주세요.");
            object val2 = Console.ReadLine();
            valArr = valArr.Append(val2).ToArray();
            Console.Write("세번째 데이터를 입력해주세요.");
            object val3 = Console.ReadLine();
            valArr = valArr.Append(val3).ToArray();
            Console.Write("네번째 데이터를 입력해주세요.");
            object val4 = Console.ReadLine();
            valArr = valArr.Append(val4).ToArray();

            for (int i = 0; i < valArr.Length; i++)
            {
                if (valArr[i] is string)
                {
                    if (int.TryParse((string)valArr[i], out int intVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, intVal, intVal.GetType());
                    }
                    else if (float.TryParse((string)valArr[i], out float floatVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, floatVal, floatVal.GetType());
                    }
                    else if (double.TryParse((string)valArr[i], out double doubleVal))
                    {
                        Console.WriteLine("{0}번째 데이터: {1}, 데이터 타입: {2}", i, doubleVal, doubleVal.GetType());
                    }
                    else if (decimal.TryParse((string)valArr[i], out decimal decimalVal))
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
