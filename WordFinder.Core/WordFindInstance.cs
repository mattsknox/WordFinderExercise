namespace WordFinder.Core;

public class WordFindInstance
{
    //Row number of the starting letter in the char matrix
    public int Row { get; set; }
    //The index of the starting letter in the matrix row
    public int Index { get; set; }
    public FindDirection Direction { get; set; }

    //Word found at the specified location
    public string Word { get; set; } = "";

}