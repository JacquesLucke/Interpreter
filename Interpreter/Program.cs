using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeLoader codeLoader = new CodeLoader(@"F:\Projekte\Interpreter\TestFiles\test1.txt");
            string codeText = codeLoader.Load();
            Console.WriteLine(codeText);
            Console.WriteLine();
            Code code = new Code(codeText);
            Console.WriteLine(code.CodeText);
            Console.ReadLine();
        }
    }
}
