namespace _101_partial
{
    /// <summary>
    /// AA 클래스를 부분 별로 나누어 처리: 필드 및 생성자와 Setter 부분
    /// </summary>
    public partial class AA
    {
        int num;

        public AA()
        {
            num = 0;
        }

        public void SetNum(int num)
        {
            this.num = num;
        }
    }
}
