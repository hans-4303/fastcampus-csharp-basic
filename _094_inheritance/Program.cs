using System;

namespace _094_inheritance
{
    public class Super
    {
        protected int a;
        public void Print()
        {
            Console.WriteLine("Super Print()");
        }
    }

    public class Sub: Super
    {
        private readonly int b = 1;
        public new void Print()
        {
            Console.WriteLine("{0}, {1}", a, b);
        }
    }

    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            Sub sub = new Sub();
            sub.Print();
        }
    }
}
