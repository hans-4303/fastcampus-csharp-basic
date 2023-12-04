using System;

namespace _106_property_01
{
    /// <summary>
    /// <para>캡슐화된 클래스</para>
    /// <para>해당 클래스의 필드 값은 외부 혹은 자식 클래스조차 사용하지 못함</para>
    /// <para>필드 값은 Set을 통해서만 움직이며 Get을 통해서 받아올 수 있음.</para>
    /// </summary>
    public class AA
    {
        /// <summary>
        /// <para>캡슐화된 필드 값</para>
        /// </summary>
        private int num;

        /// <summary>
        /// <para>Set 부분 구현하지 않으면 readonly와 같은 읽기 전용으로 취급</para>
        /// </summary>
        public int NUM
        {
            get { return num; }
            set { num = value; }
        }
    }

    /// <summary>
    /// <para>캡슐화된 클래스, 필드 값 접근 제한되는 점 확인</para>
    /// <para>Get, Set으로 값 출력 혹은 입력</para>
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA
            {
                // aa.num = 100;
                NUM = 100
            };
            Console.WriteLine(aa.NUM);
        }
    }
}
