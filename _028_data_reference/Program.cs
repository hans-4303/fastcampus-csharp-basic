using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_data_reference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 데이터 선언 및 초기화
            int num = 100;
            // 이때 num을 대입한다고 생각함
            int isItRefNum = num;
            // 새로운 값을 대입
            isItRefNum = 1000;

            // 하지만 원본 num은 불변성을 지켰음, num != isItRefNum인 결과가 나왔는데
            // 두 데이터는 서로를 참조하지 않는 것으로 이해해야 함
            Console.WriteLine("{0} {1} {2}", num, isItRefNum, Object.ReferenceEquals(num, isItRefNum));

            // int 배열로 이루어진 데이터
            int[] arrNum = { 100, 200 };
            // 얼핏 보면 arrNum의 값을 갖는 새로운 배열로 보임
            int[] arrIsItRefNum = arrNum;
            // 생성된 배열의 요소에 1000을 새로 할당함
            arrIsItRefNum[0] = 1000;

            // 두 데이터는 서로를 참조했음
            // 새로운 배열이며 서로 참조 하지 않는다면 arrNum[0] === 100, arrIsItRefNum[0] === 1000으로 달라야 했음
            // 하지만 값은 1000으로 같고, Object.ReferenceEquals로 확인했을 때에도 같은 주소 값을 참조하는 것으로 확인됨
            Console.WriteLine("{0} {1} {2}", arrNum[0], arrIsItRefNum[0], Object.ReferenceEquals(arrNum, arrIsItRefNum));
        }
    }
}
