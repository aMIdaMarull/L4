namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = "this is an example sentence. how are you? i'm fine, thank you";

            // Create the concrete transformers
            ITextTransformer capitalizeTransformer = new CapitalizeTransformer();
            ITextTransformer upperCaseTransformer = new UpperCaseTransformer();

            // Create a proxy for saving transformations to a file
            ITextTransformer proxyCap = new TextTransformerProxy(capitalizeTransformer, "transformedCap.txt");
            ITextTransformer proxyUp = new TextTransformerProxy(upperCaseTransformer, "transformedUp.txt");
            
            string transformedTextCap = proxyCap.Apply(originalText);
            string transformedTextUp = proxyUp.Apply(originalText);

            Console.WriteLine("Original Text: " + originalText);
            Console.WriteLine();
            Console.WriteLine("Capitalized Text: " + transformedTextCap);
            Console.WriteLine("Uppercased Text: " + transformedTextUp);

            string fileCapText = File.ReadAllText("transformedCap.txt");
            string fileUpText = File.ReadAllText("transformedUp.txt");

            Console.WriteLine();
            Console.WriteLine("Reversed capitalized text: " + proxyCap.Reverse(fileCapText));
            Console.WriteLine("Reversed uppercased text: " + proxyUp.Reverse(fileUpText));
        }
    }
}