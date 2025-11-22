
namespace TS.TechnicalTest;

public class LongestSentanceAnswer
{
    public static int Solution(string s)
    {
        var sentences = GetListOfSentences(s);
        int counter = 0;

        if(sentences.Count == 0)
        {
            return counter;
        }

        // Assign the next maximum count
        foreach (var sentence in sentences)
        {
            var words = sentence.Split(" ");
            var wordlenth = words.Length - 1;
            if (wordlenth > counter)
            {
                counter = wordlenth;
            }
        }
        return counter;
    }

    /**
      param name="sentence" string on sentences.
     */
    static private List<string> GetListOfSentences(string sentence)
    {
        List<string> result = [];
        if (string.IsNullOrEmpty(sentence))
        {
            return result;
        }

        char delimiter = '.';
        var sentences = sentence.Split(delimiter);
        foreach (var sentenceRecord in sentences) {
            if(!string.IsNullOrEmpty(sentenceRecord)) {
                //Remove the special character
                var cleanSentence = sentenceRecord.Replace("?","").Replace("!","");
                result.Add(cleanSentence);
            }
        }
        return result;
    }
}
