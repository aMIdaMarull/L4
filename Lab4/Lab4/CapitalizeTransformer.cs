using System.Text.RegularExpressions;

namespace Lab4
{
    public class CapitalizeTransformer : ITextTransformer
    {
        public string Apply(string text)
        {
            string[] sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string marks = KeepOnlyMarks(text);
            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = sentences[i].Trim();

                if (!string.IsNullOrWhiteSpace(sentences[i]))
                {
                    sentences[i] = sentences[i].Substring(0, 1).ToUpper() + sentences[i].Substring(1).ToLower();
                    sentences[i] += (i < marks.Length ? marks[i] : "");
                }
            }

            return string.Join(" ", sentences); // Reconstruct the text with capitalized sentences
        }

        public string Reverse(string text)
        {
            string[] sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string marks = KeepOnlyMarks(text);
            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = sentences[i].Trim(); 

                if (!string.IsNullOrWhiteSpace(sentences[i]))
                {
                    sentences[i] = sentences[i].Substring(0, 1).ToLower() + sentences[i].Substring(1);
                    sentences[i] += (i < marks.Length ? marks[i] : "");
                }
            }

            return string.Join(" ", sentences);
        }

        private static string KeepOnlyMarks(string text)
        { 
            string pattern = "[^.!?]";
            string result = Regex.Replace(text, pattern, "");
            return result;
        }
    }

}
