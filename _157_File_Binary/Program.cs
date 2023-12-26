using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _157_File_Binary
{
    using CCPS = CustomClassPlayerSpecial;

    /// <summary>
    /// <para>using의 세 번째 용도: 클래스 이름 줄여서 쓰기</para>
    /// </summary>
    public class CustomClassPlayerSpecial
    {
        public int num;
    }

    /// <summary>
    /// <para>BinaryWriter - BinaryReader</para>
    /// <para>BinaryWriter 클래스로 값을 작성하고 BinaryReader 클래스로 값을 읽는 형식</para>
    /// <para>
    ///     클래스 활용이 엄격한 편이라 Writer로 작성한 순서와 형식까지 똑같이 Reader로 읽어야 함.
    /// </para>
    /// </summary>
    internal class Program
    {
        static public string fileName = "data.dat";
        static public string fileName2 = "dataUsing.dat";

        static void WriteData ()
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(100);
            bw.Write(100.001f);
            bw.Write("Hello World");
            bw.Write(true);

            bw.Close();
        }

        static void ReadData ()
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            int num = br.ReadInt32();
            float fNum = br.ReadSingle();
            string str = br.ReadString();
            bool isData = br.ReadBoolean();

            Console.WriteLine("num: " + num);
            Console.WriteLine("fNum: " + fNum);
            Console.WriteLine("str: " + str);
            Console.WriteLine("isData: " + isData);

            br.Close();
        }

        static void WriteDataUsing ()
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName2, FileMode.Create)))
            {
                bw.Write(100);
                bw.Write(100.001f);
                bw.Write("Hello World");
                bw.Write(true);
            }
        }

        static void ReadDataUsing ()
        {
            using (BinaryReader br = new BinaryReader(new FileStream(fileName2, FileMode.Open)))
            {
                int num = br.ReadInt32();
                float fNum = br.ReadSingle();
                string str = br.ReadString();
                bool isData = br.ReadBoolean();

                Console.WriteLine("num: " + num);
                Console.WriteLine("fNum: " + fNum);
                Console.WriteLine("str: " + str);
                Console.WriteLine("isData: " + isData);
            } //using 키워드 => 자동으로 br.close();
        }

        static void TestUsing ()
        {
            _ = new CCPS
            {
                num = 100
            };
        }

        private static void Main ()
        {
            WriteData();
            ReadData();

            WriteDataUsing();
            ReadDataUsing();
        }
    }
}
