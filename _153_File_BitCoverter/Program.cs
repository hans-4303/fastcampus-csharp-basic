using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153_File_BitCoverter
{
    internal class Program
    {
        const string fileName = "a.txt";

        /// <summary>
        /// <para>FileStream + BitConverter</para>
        /// <para>1. 파일 이름 지정: a.txt</para>
        /// <para>2. 파일 내용 변수 생성</para>
        /// <para>3. FileStream 인스턴스</para>
        /// <para>
        ///     파일 이름과 FileMode.Create enum 대입해서 FileStream 인스턴스 생성,
        ///     Close(); 호출 전까지 파일과 인스턴스를 사용
        /// </para>
        /// <para>4. BitConverter 클래스</para>
        /// <para>
        ///     GetBytes(내용인 인수); 메서드 호출하고 byte[]로 반환
        /// </para>
        /// <para>5. byte[] 순회</para>
        /// <para>6. FileStream.Write(); 메서드 호출</para>
        /// <para>
        ///     byte[], offset, count 인수를 던짐,
        ///     아마도 배열 길이만큼 데이터를 읽고 byte[]에 다시 저장하는 걸로 보임.
        /// </para>
        /// <para>7. FileStream.Close(); 메서드로 해당 파일 닫기</para>
        /// <para>8. 새로운 FileStream 인스턴스</para>
        /// <para>
        ///     파일 이름과 FileMode.Open enum 대입해서 FileStream 인스턴스 생성,
        ///     Close(); 호출 전까지 파일과 인스턴스를 사용
        /// </para>
        /// <para>9. FileStream.Read(); 메서드 호출</para>
        /// <para>
        ///     byte[], offset, count 인수를 던짐, 설명 볼 때
        ///     rBytes 배열 길이만큼 데이터를 읽고 rBytes에 다시 저장하는 걸로 보임.
        ///     편집된 rBytes 배열에 BitConverter.To***(타입)으로 접근하는 거면 어느 정도 이해됨.
        /// </para>
        /// <para>10. using 블록</para>
        /// <para>
        ///     using (FileStream inStream = new FileStream(fileName, FileMode.Open)) {}...
        ///     블록으로 파일 작성 가능, 이렇게 하면 블록 벗어날 시 Dispose 메서드가 호출되어
        ///     메서드 내에서 파일 닫는 작업이 이루어짐.
        ///     명시적으로 Close(); 메서드 호출하지 않아도 됨.
        /// </para>
        /// </summary>
        private static void Main ()
        {
            //파일 쓰기
            long lValue = 1234567890123456789;
            int num = 100;
            Console.WriteLine("lValue: " + lValue);
            Console.WriteLine("num: " + num);

            using (Stream outStream = new FileStream(fileName, FileMode.Create))
            {
                byte[] wBytes = BitConverter.GetBytes(lValue);

                Console.Write("Byte: ");
                foreach (var item in wBytes)
                    Console.Write("{0:X2} ", item);
                Console.WriteLine();

                outStream.Write(wBytes, 0, wBytes.Length);

                wBytes = BitConverter.GetBytes(num);

                Console.Write("Byte: ");
                foreach (var item in wBytes)
                    Console.Write("{0:X2} ", item);
                Console.WriteLine();

                outStream.Write(wBytes, 0, wBytes.Length);
            } // 여기서 outStream이 자동으로 닫힙니다.

            // outStream.Close(); 필요 없어진 Close 메서드


            //파일 읽기
            using (FileStream inStream = new FileStream(fileName, FileMode.Open))
            {
                byte[] rBytes = new byte[sizeof(long)];
                inStream.Read(rBytes, 0, rBytes.Length);
                long readValue = BitConverter.ToInt64(rBytes, 0);

                rBytes = new byte[sizeof(int)];
                inStream.Read(rBytes, 0, rBytes.Length);
                int readNum = BitConverter.ToInt32(rBytes, 0);

                Console.WriteLine("Read Data:" + readValue);
                Console.WriteLine("Read Data:" + readNum);
            } // 여기서 inStream이 자동으로 닫힙니다.

            // inStream.Close(); 필요 없어진 Close 메서드
        }
    }
}
