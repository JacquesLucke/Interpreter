using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Code
    {
        string code;

        public static Code FromFile(string fileName)
        {
            CodeLoader cl = new CodeLoader(fileName);
            return new Code(cl.Load());
        }

        public Code(string codeText)
        {
            this.code = SimplifyCodeText(codeText);
        }
        private string SimplifyCodeText(string codeText)
        {
            char quoteType = ' ';
            for(int i = 0; i< codeText.Length; i++)
            {
                char c = codeText[i];
                UpdateQuoteStatus(c, ref quoteType);
                if (quoteType == '"') { int e = 0; e++; }
                if (CheckIfCharMustBeRemoved(c, quoteType))
                {
                    codeText = codeText.Remove(i, 1);
                    i--;
                }
            }
            return codeText;
        }
        private void UpdateQuoteStatus(char c, ref char quoteType)
        {
            if (c == '"' && quoteType == ' ') quoteType = '"';
            else if (c == '"' && quoteType == '"') quoteType = ' ';
            else if (c == Convert.ToChar("'") && quoteType == ' ') quoteType = Convert.ToChar("'");
            else if (c == Convert.ToChar("'") && quoteType == Convert.ToChar("'")) quoteType = ' ';
        }
        private bool CheckIfCharMustBeRemoved(char c, char quoteType)
        {
            if (quoteType == ' ')
            {
                if (c == ' ') return true;
                if (c == '\r') return true;
                if (c == '\n') return true;
            }
            return false;
        }

        public string CodeText
        {
            get { return code; }
        }
    }
}
