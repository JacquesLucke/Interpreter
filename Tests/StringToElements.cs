using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter;
using Interpreter.Elements;

namespace Tests
{
    class StringToElements : ITest
    {
        public bool Test()
        {
            Console.WriteLine("start simplify code test");
            Console.WriteLine();

            List<KeyValuePair<string, List<IElement>>> tests = new List<KeyValuePair<string, List<IElement>>>();
            tests.Add(Create("5", new NumberElement(5)));
            tests.Add(Create("5.2", new NumberElement(5.2)));

            bool allCorrect = true;
            foreach (KeyValuePair<string, List<IElement>> testData in tests)
            {
                if (TestParser(testData)) TestOutputUtils.WritePositiveText("success: " + testData.Key);
                else
                {
                    TestOutputUtils.WriteNegativeText("SimplifyCodeText Error: " + testData.Key);
                    allCorrect = false;
                }
            }

            return allCorrect;
        }
        private bool TestParser(KeyValuePair<string, List<IElement>> testData)
        {
            StringToElementsParser parser = new StringToElementsParser(testData.Key);
            return CompareElementList(parser.ParseElements(), testData.Value);
            
        }
        private bool CompareElementList(List<IElement> list1, List<IElement> list2)
        {
            if (list1.Count != list2.Count) return false;
            for(int i= 0; i< list1.Count; i++)
            {
                if(list1[i].ToString() != list2[i].ToString()) return false;
            }
            return true;
        }

        private KeyValuePair<string, List<IElement>> Create(string input, params IElement[] elements)
        {
            return new KeyValuePair<string, List<IElement>>(input, elements.ToList());
        }
    }
}
