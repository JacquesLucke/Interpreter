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
            Code code = Code.FromFile(@"F:\Projekte\Interpreter\TestFiles\test1.txt");
            Console.WriteLine(code.CodeText);
            Console.ReadLine();
        }
    }
}
