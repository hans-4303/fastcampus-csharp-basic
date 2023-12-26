using System;
using System.Collections.Generic;
// 파일 및 관련된 클래스 다루기
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _152_File_Default
{
    
    internal class Program
    {
        /// <summary>
        /// <para>파일 생성 기본</para>
        /// <para>1. 경로 변수 생성</para>
        /// <para>2. 파라미터 길이를 따져서 동작</para>
        /// <para>
        ///     파라미터 길이가 0보다 작다면
        ///     디렉토리 클래스에서 GetCurrentDirectory(); 메서드 호출하여 경로 반환,
        ///     반환 받은 경로에 \a.txt 더해주기
        /// </para>
        /// <para>
        ///     파라미터가 있다면 [0] 요소 사용하기
        /// </para>
        /// <para>3. 경로를 따져서 동작</para>
        /// <para>
        ///     경로에 해당하는 파일 \a.txt가 있다면
        ///     파일 클래스에서 GetCreationTime(파일 이름); 메서드 호출하여 생성 시간 반환
        /// </para>
        /// <para>
        ///     아직 파일이 없다면 \a.txt 만들 수 있도록
        ///     파일 클래스에서 Create(파일 경로); 메서드 호출하여 파일 생성 후 FileStream 변수에 반환
        ///     변수에서 Close 메서드 호출하여 소켓과 파일 핸들 리소스 해제
        /// </para>
        /// <para>4. 즉시 파일 생성</para>
        /// <para>
        ///     FileInfo 인스턴스를 만들고 이름 지정,
        ///     FileStream 변수에 FileInfo 인스턴스.Create(); 반환 후 Close 메서드 호출하기
        /// </para>
        /// <para>5. 리턴</para>
        /// <para>
        ///     클래스 상 File != FileInfo 이지만
        ///     File.Create();와 FileInfo.Create();의 리턴형은 FileStream으로 같음.
        /// </para>
        /// </summary>
        /// <param name="args">cmd 실행 시 받을 수 있는 파라미터</param>
        private static void Main (string[] args)
        {
            string path;

            if (args.Length <= 0)
            {
                path = Directory.GetCurrentDirectory();
                path += "\\a.txt";

                Console.WriteLine("path: " + path);
            }
            else
            {
                path = args[0];
            }

            if (File.Exists(path))
            { //using System.IO;
                Console.WriteLine("\nGetCreationTime: " + File.GetCreationTime(path));
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }

            FileInfo fileInfo = new FileInfo("b.txt");
            FileStream ff = fileInfo.Create();

            ff.Close();
        }
    }
}
