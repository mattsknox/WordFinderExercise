namespace WordFinder.Core;

using System.Text.RegularExpressions;

public class WordFinderService : IWordFinderService
{
    public WordFindReport FindWords(CharMatrix characterMatrix, List<string> targetWords)
    {
        ValidateInput(characterMatrix, targetWords);
        
        var result = new WordFindReport
        {
            Matrix = characterMatrix,
            TargetWords = targetWords
        };

        for(int i = 0; i < characterMatrix.Rows.Count; i++)
        {
            var row = characterMatrix.Rows[i];
            var horizontalMatches = FindRowMatches(row, targetWords, i);
            result.WordsFound = result.WordsFound.Concat(horizontalMatches).ToList();
        }

        var pivotedColumns = GetPivotedColumns(characterMatrix);

        for(int i = 0; i < pivotedColumns.Count; i++)
        {
            var column = pivotedColumns[i];
            var verticalMatches = FindColumnMatches(column, targetWords, i);
            result.WordsFound = result.WordsFound.Concat(verticalMatches).ToList();
        }
        
        return result;
    }

    void ValidateInput(CharMatrix matrix, List<string> targetWords)
    {
        if (targetWords.Count < 1)
        {
            throw new ArgumentNullException("Must have target words");
        }

        if (matrix.Rows[0].Length != matrix.Rows.Count())
        {
            var columns = matrix.Rows[0].Length;
            var rows = matrix.Rows.Count;
            throw new ArgumentException($"Matrix must be square (Columns: {columns}, Rows: {rows})");
        }

        foreach(var word in targetWords)
        {
            if ( word.Length > 10
            || word.Length < 2 )
            {
                throw new ArgumentException($"Target words must be between 2 and 10 characters ({word})");
            }

            if (Regex.Match(word, @"\W").Success)
            {
                throw new ArgumentException($"Target words can only contain English word characters");
            }
        }

        foreach(var row in matrix.Rows)
        {
            if (Regex.Match(row, @"\W").Success)
            {
                throw new ArgumentException($"Matrix must only contain English word characters");
            }
        }

    }

    List<WordFindInstance> FindRowMatches(string row, 
        List<string> targetWords,
        int rowIndex)
    {
        var wordsFound = new List<WordFindInstance>();

        foreach(var word in targetWords)
        {
            Match match = Regex.Match(row, word, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                wordsFound.Add(new WordFindInstance
                {
                    Row = rowIndex + 1,
                    Index = match.Index + 1,
                    Direction = FindDirection.Horizontal,
                    Word = word
                });
            }
        }

        return wordsFound;
    }

    List<WordFindInstance> FindColumnMatches(string column,
        List<string> targetWords,
        int columnIndex)
    {
        var wordsFound = new List<WordFindInstance>();

        foreach(var word in targetWords)
        {
            Match match = Regex.Match(column, word, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                wordsFound.Add(new WordFindInstance
                {
                    Row = match.Index + 1,
                    Index = columnIndex + 1,
                    Direction = FindDirection.Vertical,
                    Word = word
                });
            }
        }

        return wordsFound;
    }

    List<string> GetPivotedColumns(CharMatrix characterMatrix)
    {
        List<string> columns
            = new List<string>();

        for(int i = 0; i < characterMatrix.Rows.Count; i++)
        {
            var row = characterMatrix.Rows[i];
            if (i == 0)
            {
                foreach(var character in row)
                {
                    columns.Add(character.ToString());
                }
            }
            else
            {
                var rowIndex = 0;
                foreach(var character in row)
                {
                    columns[rowIndex] += character.ToString();
                    rowIndex++;
                }
            }
        }

        return columns;
    }
}