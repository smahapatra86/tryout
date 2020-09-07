using System;

namespace dotnetsample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]} from .net to docker");
            }
            else
            {
                Console.WriteLine("Hello World! from .net to docker");
            }

            Console.ReadLine();
        }
    }
}
