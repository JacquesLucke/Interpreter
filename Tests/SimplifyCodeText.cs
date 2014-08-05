using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter;

namespace Tests
{
    class SimplifyCodeText : ITest
    {
        public bool Test()
        {
            Console.WriteLine("start simplify code test");
            Console.WriteLine();

            List<KeyValuePair<string, string>> tests = new List<KeyValuePair<string, string>>();
            tests.Add(Create("a=1", "a=1"));
            tests.Add(Create("a = 1", "a=1"));
            tests.Add(Create("a= 'hallo welt'", "a='hallo welt'"));
            tests.Add(Create("var1 = ' df' + ' d'", "var1=' df'+' d'"));
            tests.Add(Create("a = \" es \"", "a=\" es \""));
            tests.Add(Create("a=1;\r\nb=2", "a=1;b=2"));

            bool allCorrect = true;

            foreach(KeyValuePair<string, string> testData in tests)
            {
                if (TestSimplification(testData)) TestOutputUtils.WritePositiveText("success: " + testData.Key);
                else
                {
                    TestOutputUtils.WriteNegativeText("SimplifyCodeText Error: " + testData.Key);
                    allCorrect = false;
                }
            }

            return allCorrect;
        }
        private bool TestSimplification(KeyValuePair<string, string> testData)
        {
            Code code = new Code(testData.Key);
            return code.CodeText == testData.Value;
        }

        private KeyValuePair<string, string> Create(string input, string expectedOutput)
        {
            return new KeyValuePair<string, string>(input, expectedOutput);
        }
    }
}
