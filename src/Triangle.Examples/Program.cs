
namespace TriangleNet
{
    using System;
    using System.Linq;
    using TriangleNet.Examples;

    class Program
    {
        static void Main(string[] args)
        {
            bool print = args.Contains("--print");
            var examples = ExampleProvider.Examples();
            examples.ForEach(e => Check($"{e.Name}", e.Run(print)));
            //Check("Example  1", new Example1().Run(print));
            //Check("Example  2", new Example2().Run(print));
            //Check("Example  3", new Example3().Run(print));
            //Check("Example  4", new Example4().Run(print));
            //Check("Example  5", new Example5().Run(print));
            //Check("Example  6", new Example6().Run(print));
            //Check("Example  7", new Example7().Run(print));
            //Check("Example  8", new Example8().Run(print));
            //Check("Example  9", new Example9().Run());
            //Check("Example 10", new Example10().Run(print));
            //Check("Example 11", new Example11().Run(print));
        }

        static void Check(string item, bool success)
        {
            var color = Console.ForegroundColor;

            Console.Write(item + " ");
            Console.ForegroundColor = success ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
            Console.WriteLine(success ? "OK" : "Failed");
            Console.ForegroundColor = color;
        }
    }
}