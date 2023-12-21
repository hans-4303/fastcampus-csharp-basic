using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _137_delegateCheckNull
{
    internal delegate void DelegateFunc ();

    internal class MessageProcess
    {
        private DelegateFunc callFunc;

        public void SetDelegate (DelegateFunc func)
        {
            callFunc = func ?? throw new ArgumentNullException(nameof(func), "Delegate cannot be null.");
        }

        public void InvokeDelegateSafely ()
        {
            try
            {
                // ?.Invoke()를 사용하여 무시하고 null이 아닌 경우에만 호출
                callFunc?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }

    internal class Program
    {
        private static void Main ()
        {
            MessageProcess messageProcess = new MessageProcess();

            try
            {
                // SetDelegate에 null을 전달하면 ArgumentNullException이 발생
                messageProcess.SetDelegate(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in Main: {ex.Message}");
            }

            // 정상적인 Delegate 설정
            messageProcess.SetDelegate(() => Console.WriteLine("Call in Delegate"));

            // InvokeDelegateSafely 호출
            messageProcess.InvokeDelegateSafely();

            MessageProcess messageProcess1 = new MessageProcess();
            // messageProcess1.SetDelegate(3); // 값을 DelegateFunc 타입으로 쓸 수 없어서 컴파일 단계 에러
            messageProcess1.SetDelegate(() => { throw new Exception("억지로 Exception 만들어보기"); }); // 함수 맞아서 런타임까지는 가는데 InvokeDelegateSafely(); 에서 catch 블록 처리됨
            messageProcess1.InvokeDelegateSafely();
        }
    }
}
