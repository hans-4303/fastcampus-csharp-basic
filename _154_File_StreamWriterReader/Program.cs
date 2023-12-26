using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _154_File_StreamWriterReader
{
    internal class Program
    {
        /// <summary>
        /// <para>FileStream + StreamWriter + StreamReader</para>
        /// <para>1. FileStream, StreamWriter 인스턴스 생성</para>
        /// <para>2. StreamWriter 인스턴스에 Write || WriteLine으로 값 작성</para>
        /// <para>3. StreamWriter 인스턴스 닫기</para>
        /// <para>4. File 클래스에서 Open 메서드로 파일 읽고 FileStream 인스턴스 만들기</para>
        /// <para>5. StreamReader 인스턴스 생성하고 FileStream 인스턴스를 인수로 받기</para>
        /// <para>6. StreamReader 클래스 Prop</para>
        /// <para>
        ///     StreamReader.BaseStream.Length: 해당 파일 문자열 길이를 뜻함.
        ///     StreamReader.EndOfStream: 현재 스트림 위치가 스트림 끝에 있는지를 뜻함
        /// </para>
        /// <para>7. StreamWriter/Reader 단독 사용</para>
        /// <para>
        ///     두 인스턴스가 무조건 FileStream 인스턴스 기반으로 쓰여야 하는 것은 아님.
        ///     단독 사용 가능함.
        /// </para>
        /// <para>8. using 절과 인스턴스 다루기</para>
        /// <para>
        ///     using절을 이용해 인스턴스를 생성 후 사용 가능,
        ///     이때는 IDisposable 상속에 의해 Close(); 메서드를 명시하지 않아도 됨.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            //쓰기..

            FileStream fsWrite = new FileStream("a.txt", FileMode.Create);
            // == File.Create("a.txt");
            StreamWriter sw = new StreamWriter(fsWrite);
            // == StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create));

            sw.Write("Hello World");
            sw.WriteLine(" Line ");
            sw.WriteLine(" Line ");
            sw.Write(" Close ");

            sw.Close();

            //읽기..
            FileStream fsRead = File.Open("a.txt", FileMode.Open); //new FileStream("a.txt", FileMode.Open);  // File.Create("a.txt");
            StreamReader sr = new StreamReader(fsRead);

            Console.WriteLine("sr.BaseStream.Length:" + sr.BaseStream.Length);

            while (false == sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();

            //-----------------------------------------------
            //StreamWriter, StreamReader 단독 사용
            //-----------------------------------------------
            StreamWriter streamWriter1 = new StreamWriter("b.txt");

            streamWriter1.WriteLine("A");
            streamWriter1.WriteLine("B");
            streamWriter1.WriteLine("C");
            streamWriter1.WriteLine("D");

            streamWriter1.Close();

            StreamReader streamReader1 = new StreamReader("b.txt");

            while (false == streamReader1.EndOfStream)
            {
                Console.WriteLine(streamReader1.ReadLine());
            }

            streamReader1.Close();

            // IDisposable 상속 받은 StreamReader를 using으로 활용..
            using(StreamReader streamReader2 = new StreamReader("b.txt")) {
                while(false == streamReader2.EndOfStream) {
                   Console.WriteLine(streamReader2.ReadLine());
                }
            }
        }
    }
}
