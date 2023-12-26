using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _156_File_BinaryFormatter
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
    /// <para>FileStream + BinaryFormatter + .dat</para>
    /// <para>
    ///     이전 예제와 구조는 비슷함,
    ///     List를 통해 입력할 자료형을 정하고 for문으로 인스턴스를 생성하여 List 편집.
    ///     이후 인스턴스 생성하고 파일을 특정 형식으로 시리얼 라이즈한 뒤 저장.
    /// </para>
    /// <para>
    ///     저장된 파일을 열고, 인스턴스 생성한 뒤
    ///     object로 된 값들을 특정 타입이라 명시적 캐스팅하여 사용.
    /// </para>
    /// </summary>
    internal class Program
    {
        const string fileName = "list.dat";

        private static void Main ()
        {
            List<Player> listPlayers = new List<Player>();

            for (int i = 0; i < 10; i++)
            {
                Player player = new Player
                {
                    _Name = i.ToString(),
                    _Level = i,
                    _Exp = i * 10
                };

                listPlayers.Add(player);
            }

            //쓰기
            FileStream fsw = new FileStream(fileName, FileMode.Create);

            BinaryFormatter bfW = new BinaryFormatter();
            bfW.Serialize(fsw, listPlayers);

            fsw.Close();


            //읽기
            FileStream fsr = new FileStream(fileName, FileMode.Open);

            BinaryFormatter bfr = new BinaryFormatter();
            List<Player> readPlayers = (List<Player>) bfr.Deserialize(fsr);

            foreach (var data in readPlayers)
            {
                Console.WriteLine("_Name: {0} _Level:{1} _Exp:{2}", data._Name, data._Level, data._Exp);
            }

            fsr.Close();
        }
    }
}
