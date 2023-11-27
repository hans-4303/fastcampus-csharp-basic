using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_data_var
{
    internal class Program
    {
        // var: 지역 변수로써, class 단위 전역에서는 사용할 수 없다.
        // var globalVar = 100; (X)
        static void Main(string[] args)
        {
            // 틀린 사용법, var는 선언과 동시에 초기화 해야 하기 때문에
            // var y;
            // y = 100;

            // 선언과 초기화 거친 다음 다시 값 할당하는 건 가능하다
            var z = false;
            z = true;

            var a = 100;
            var b = 3.1415923134134134141344f;
            var c = 3.1415923134134134141344m;
            var d = 'H';
            // var 형식은 ToString 등으로 변환시켜 줘야 함, 이때도 불변성은 유지될 것
            var dDash = d.ToString().ToLower();
            var e = 'i';
            var eDash = e.ToString().ToUpper();
            var f = "World!";
            var fDash = f.ToString().Replace("W", "Hello W");
            var g = false;
            object i = 3.1415923134134134141344f;

            // var이지만 암시적으로 변하여 각각 타입과 값이 맞게 출력되고 있으며, 불변성도 유지됐음
            // 물론 int -> int32, float -> single로 타입이 변하는데, cts에 따라 여러 운영체제에 유연하게 대응하기 위함임
            Console.WriteLine("{0} {1}", a.GetType(), a);
            Console.WriteLine("{0} {1}", b.GetType(), b);
            Console.WriteLine("{0} {1}", c.GetType(), c);
            Console.WriteLine("{0} {1}", d.GetType(), d);
            Console.WriteLine("{0} {1}", dDash.GetType(), d);
            Console.WriteLine("{0} {1}", e.GetType(), e);
            Console.WriteLine("{0} {1}", eDash.GetType(), eDash);
            Console.WriteLine("{0} {1}", f.GetType(), f);
            Console.WriteLine("{0} {1}", fDash.GetType(), fDash);
            Console.WriteLine("{0} {1}", g.GetType(), g);

            // object도 형변환될까? 물론 됐음, object보다 각 타입을 쓰는 건 요구에 비해 과한 유연성을 잡아내기 위한 걸로 보임
            Console.WriteLine("{0} {1}", i.GetType(), i);
        }
    }
}
