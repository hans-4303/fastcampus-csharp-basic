using System;

namespace _093_parameter
{
    /// <summary>
    /// 참조 혹은 복사될 클래스
    /// </summary>
    public class AA
    {
        public int a;
        public int b;

        public AA()
        {
            a = 0;
            b = 0;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("{0}, {1}", a, b);
        }
    }

    internal class Program
    {
        /// <summary>
        /// 파라미터로 넘어온 인스턴스를 로컬 값으로 대입
        /// call by reference라 불변성 깨짐
        /// </summary>
        /// <param name="aa"></param>
        private static void ModifyClassByReference(AA aa)
        {
            AA refAA = aa;
            refAA.a = 100;
            refAA.b = 10000;
        }
 
        /// <summary>
        /// 새로운 인스턴스 생성하고 필드 값에 파라미터의 필드 값을 대입하거나 새로운 값으로 연산 후
        /// 인스턴스를 반환하기 때문에 불변성을 지킨다 볼 수 있음
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        private static AA CopyDeepClass(AA aa)
        {
            // 인스턴스 생성
            AA tempAA = new AA
            {
                a = aa.a,
                b = aa.b
            };
            tempAA.a = 0;

            return tempAA;
        }

        /// <summary>
        /// 1. 새 인스턴스 aa1 생성
        /// 2. aa1 인스턴스 Print 함수 실행
        /// 3. Class Program에 속한 CopyRefClass 메서드 실행: 인수로 aa1 인스턴스 대입
        /// 4. aa1 인스턴스 Print 함수 실행
        /// 5. CopyDeepClass 메서드 실행: 인수로 aa1 인스턴스 대입하고 결과를 aa2 인스턴스에 반환 받음
        /// 6. aa2 인스턴스에서 결과 확인
        /// 7. aa1 == aa2 성립하는 지 aa1 출력 확인, aa1 != aa2 확인 됨
        /// 8. aa1은 call by reference를 거쳐서 필드 값 수정됐음
        /// 9. aa2는 새로운 인스턴스를 생성 후 대입 및 수정하고 반환함, 바라보는 주소 값과 값이 달라짐
        /// </summary>
        private static void Main(/* string[] args */)
        {
            AA aa1 = new AA();
            aa1.Print();

            ModifyClassByReference(aa1);
            aa1.Print();

            AA aa2 = CopyDeepClass(aa1);
            aa2.Print();

            aa1.Print();
        }
    }
}
