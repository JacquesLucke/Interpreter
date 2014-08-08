using Interpreter.Elements;
using System.Collections.Generic;
using System;

namespace Interpreter
{ 
    public class StringToElementsParser
    {
        string codeText;

        delegate IElement GetAndDeleteFirstElement(ref string text);
        List<GetAndDeleteFirstElement> getElementMethods;

        public StringToElementsParser(string codeText)
        {
            this.codeText = codeText;

            SetupParseDictionaries();
        }
        private void SetupParseDictionaries()
        {
            getElementMethods = new List<GetAndDeleteFirstElement>();
            getElementMethods.Add(GetNumber);
            getElementMethods.Add(GetWord);
        }

        public List<IElement> ParseElements()
        {
            List<IElement> elements = new List<IElement>();

            string text = codeText;
            while(text.Length > 0)
            {
                elements.Add(FindAndDeleteFirstElement(ref text));
            }

            return elements;
        }
        private IElement FindAndDeleteFirstElement(ref string text)
        {
            foreach(GetAndDeleteFirstElement method in getElementMethods)
            {
                IElement element = method(ref text);
                if(element != null) return element;
            }

            throw new Exception("can't identify next element");
        }

        private NumberElement GetNumber(ref string text)
        {
            NumberElement element = null;

            int endIndex = -1;
            bool dotInside = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]) || (text[i] == '.' && !dotInside)) endIndex = i;
                else break;
                if (text[i] == '.') dotInside = true;
            }

            if (endIndex >= 0)
            {
                element = new NumberElement(Convert.ToDouble(text.Substring(0, endIndex + 1).Replace('.', ',')));
                text = text.Substring(endIndex + 1);
            }

            return element;
        }
        private WordElement GetWord(ref string text)
        {
            WordElement element = null;
            int endIndex = -1;

            for (int i = 0; i < text.Length; i++)
            {
                if (IsLegalWordChar(text[i])) endIndex = i;
                else break;
            }
            if(endIndex >= 0)
            {
                element = new WordElement(text.Substring(0, endIndex + 1));
                text = text.Substring(endIndex + 1);
            }
            return element;
        }
        private bool IsLegalWordChar(char c)
        {
            return Char.IsLetterOrDigit(c) || c == '_';
        }
    }
}
