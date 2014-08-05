using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Interpreter
{
    public class CodeLoader
    {
        string fileName;

        public CodeLoader(string fileName)
        {
            this.fileName = fileName;
        }

        public string Load()
        {
            StreamReader sr = new StreamReader(fileName);
            string codeText = sr.ReadToEnd();
            sr.Close();
            return codeText;
        }
    }
}
