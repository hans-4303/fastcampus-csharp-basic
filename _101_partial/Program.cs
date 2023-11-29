namespace _101_partial
{
    /// <summary>
    /// 인스턴스 생성 및 함수 호출하는 메인 메서드
    /// </summary>
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            AA aa = new AA();
            aa.SetNum(10);
            aa.ADD();

            aa.SetNum(100);
            aa.MUL();
        }
    }
}
