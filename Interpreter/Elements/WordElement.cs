namespace Interpreter.Elements
{
    public class WordElement : IElement
    {
        string word = "";

        public WordElement(string word)
        {
            this.word = word;
        }

        public override string ToString()
        {
            return word;
        }
    }
}
