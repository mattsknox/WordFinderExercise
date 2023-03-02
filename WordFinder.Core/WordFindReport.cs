namespace WordFinder.Core;

public class WordFindReport
{
    public List<WordFindInstance> WordsFound { get; set; }
        = new List<WordFindInstance>();

    public CharMatrix Matrix { get; set; }
    public List<string> TargetWords { get; set; }
    public IEnumerable<string> WordsNotFound 
    {
        get {
            IEnumerable<string> wordsFound = WordsFound.Select(_ => _.Word);
            return TargetWords.Except(wordsFound);
        }
    }

    public override string ToString()
    {
        string message = $"Words Found: {WordsFound.Count}\n";
        if (WordsFound.Count > 0)
        {
            foreach(var findReport in WordsFound)
            {
                
                message += $"\t{findReport.Word} ({findReport.Row}, {findReport.Index}, {findReport.Direction})\n";
            }
        }

        var wordsNotFound = WordsNotFound;
        if (wordsNotFound.Count() > 0)
        {
            message += $"Words not found:\n";

            foreach(var word in wordsNotFound)
            {
                message += $"\t{word}\n";
            }
        }

        return message;
    }
}