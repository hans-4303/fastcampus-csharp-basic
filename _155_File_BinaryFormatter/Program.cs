using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _155_File_BinaryFormatter
{
    /// <summary>
    /// <para>사용자 자료 입출력을 위한 struct: [Serializable] 사용</para>
    /// <para>물론 필드 값 밖에 없고 public으로 접근이 가능함</para>
    /// </summary>
    [Serializable]
    public struct Player
    {
        public string _Name;
        public int _Level;
        public double _Exp;
    }

    /// <summary>
    /// <para>사용자 자료 입출력</para>
    /// <para>1. 플레이어 배열 초기화 및 직접 값 입력</para>
    /// <para>2. FileStream 인스턴스 생성으로 파일 생성</para>
    /// <para>3. BinaryFormatter 인스턴스 생성</para>
    /// <para>4. BinaryFormatter.Serialize(파일, 형식);을 이용해 시리얼 라이즈해서 저장하고 파일 닫기</para>
    /// <para>
    ///     이 과정 때문에 직접 열어본 파일은 바이너리화 되어 있었음.
    /// </para>
    /// <para>5. FileStream 인스턴스 생성으로 파일 열기</para>
    /// <para>6. BinaryFormatter 인스턴스 생성</para>
    /// <para>
    ///     BinaryFormatter.Deserialize(파일);을 이용해 디 시리얼 라이즈,
    ///     이때 타입 보장을 위해 명시적 캐스팅함.
    ///     어차피 디 시리얼 라이즈 메서드는 object를 리턴하기 때문에
    ///     어떤 걸 리턴받을 지 모르는 상황은 없고, 만든 클래스와 일치시켜주면 됨.
    /// </para>
    /// <para>7. 작업 후 파일 닫기</para>
    /// </summary>
    internal class Program
    {
        const string fileName = "savePlayer.txt";

        private static void Main ()
        {
            Player[] player = new Player[2];

            player[0]._Name = "aaa";
            player[0]._Level = 10;
            player[0]._Exp = 5400;

            player[1]._Name = "bbb";
            player[1]._Level = 99;
            player[1]._Exp = 53460;

            //쓰기
            FileStream fsW = new FileStream(fileName, FileMode.Create);

            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(fsW, player);

            fsW.Close();


            //읽기
            FileStream fsR = new FileStream(fileName, FileMode.Open);

            BinaryFormatter bf2 = new BinaryFormatter();
            Player[] readPlayer = (Player[]) bf2.Deserialize(fsR);

            for (int i = 0; i < readPlayer.Length; i++)
            {
                Console.WriteLine("Name: " + readPlayer[i]._Name);
                Console.WriteLine("Level: " + readPlayer[i]._Level);
                Console.WriteLine("Exp: " + readPlayer[i]._Exp);
            }

            fsR.Close();
        }
    }
}