namespace Lab4
{
    public class TextTransformerProxy : ITextTransformer
    {
        private readonly ITextTransformer realTransformer;
        private readonly string filePath;

        public TextTransformerProxy(ITextTransformer transformer, string filePath)
        {
            this.realTransformer = transformer;
            this.filePath = filePath;
        }

        public string Apply(string text)
        {
            // Apply the transformation using the real transformer
            string transformedText = realTransformer.Apply(text);

            // Save the transformed text to a file
            File.WriteAllText(filePath, transformedText);

            return transformedText;
        }

        public string Reverse(string text)
        {
            string originalText = realTransformer.Reverse(text);

            return originalText;
        }
    }
}
