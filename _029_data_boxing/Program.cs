using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_data_boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 데이터 선언 및 초기화
            int i = 123;
            // 박싱: i를 힙 영역으로, o는 i에 대한 주소 값 가짐
            object o = i;
            // 언박싱: o를 스택 영역으로, j는 o값을 가지고 힙 영역은 안 가짐
            int j = (int)o;
            // i에 값 대입해보기
            i = 456;

            // i != o, j
            Console.WriteLine("{0} {1} {2}", i, o, j);
            // i의 주소가 o와 같지 않음: o는 i 값을 힙 영역으로 뺐으니까
            Console.WriteLine("{0}", Object.ReferenceEquals(i, o));
            // i와 j 주소도 같지 않음, 별개로 선언된 값이라 여겨서
            Console.WriteLine("{0}", Object.ReferenceEquals(i, j));
        }
    }
}
