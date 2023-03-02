namespace WordFinder.Core;

public interface IWordFinderService
{
    public WordFindReport FindWords(CharMatrix characterMatrix, List<string> targetWords);
}