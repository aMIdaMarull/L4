namespace Lab4
{
    public class UpperCaseTransformer : ITextTransformer
    {
        public string Apply(string text)
        {        
            return text.ToUpper();
        }

        public string Reverse(string text)
        {
            return text.ToLower();
        }
    }
}
