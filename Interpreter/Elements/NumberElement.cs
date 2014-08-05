namespace Interpreter.Elements
{
    public class NumberElement : IElement
    {
        double number = 0;

        public NumberElement(double number)
        {
            this.number = number;
        }

        public override string ToString()
        {
            return "" + number;
        }
    }
}
