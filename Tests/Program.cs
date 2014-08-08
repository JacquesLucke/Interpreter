using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            List<ITest> tests = new List<ITest>();
            tests.Add(new SimplifyCodeText());
            tests.Add(new StringToElements());

            bool allCorrect = true;
            foreach(ITest test in tests)
            {
                if (!test.Test()) allCorrect = false;
            }
            Console.WriteLine();
            Console.WriteLine("all tests are done");
            Console.WriteLine();
            if(allCorrect)
            {
                TestOutputUtils.WritePositiveText("all tests run without errors");
            }
            else
            {
                TestOutputUtils.WriteNegativeText("there were at least one error");
            }
        }
    }
}
