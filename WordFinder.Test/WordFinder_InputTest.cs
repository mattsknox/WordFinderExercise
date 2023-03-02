namespace WordFinder.Test;

using System.Collections.Generic;

using WordFinder.Core;

public class Tests
{
    IWordFinderService WordFinder;

    [SetUp]
    public void Setup()
    {
        WordFinder = new WordFinderService();
    }

    [Test]
    public void WordFinderCore_FindsVertical()
    {
        //Arrange
        var sampleMatrix = new CharMatrix
        {
            Rows = new List<string>
            {
                { "XCX" },
                { "XAX" },
                { "XTX" }
            }
        };
        var sampleTarget = new List<string>
        {
            "cat"
        };

        //Act
        var result = WordFinder.FindWords(sampleMatrix, sampleTarget);

        //Assert
        Assert.IsTrue(result.WordsFound.Count > 0 );
    }
    
    [Test]
    public void WordFinderCore_FindsHorizontal()
    {
        //Arrange
        var sampleMatrix = new CharMatrix
        {
            Rows = new List<string>
            {
                { "XXX" },
                { "CAT" },
                { "XXX" }
            }
        };
        
        
        var sampleTarget = new List<string>
        {
            "cat"
        };

        //Act
        var result = WordFinder.FindWords(sampleMatrix, sampleTarget);

        //Assert
        Assert.IsTrue(result.WordsFound.Count > 0 );
    }

    [Test]
    public void WordFinderCore_SampleMatrix()
    {
        var sampleMatrix = new CharMatrix
        {
            Rows = new List<string>
            {
                "USIMMLECJJQTJQCPNZTZ",
                "VTOOTGRCBAWAYUWSJWUA",
                "FUDDPDEOLBROCKGKWVCZ",
                "CGDQOSTSHURNICEYYFOU",
                "FUEVELJFVIQIXVCMFGLG",
                "ZKSMSTMBSKENWRDTVYDT",
                "JUZUUFFPWMDTCOWUGISU",
                "MNGNFSEJFAKESLSLXJDC",
                "UXMOSFBIQOHROIYTBBYZ",
                "VCCCJZKRDWFFIAMFJPGO",
                "JTFRDRTHWSUANWINDOIW",
                "QLPDCXJEOTNCSCHILLRH",
                "SNOWFOHPYRIETEKZXDMN",
                "NEJUQEYLYGPOABGRJPQV",
                "TYIVLGKBKRXLNNILMWTK",
                "ASUTPBDDWZKTCUCJTYMD",
                "ZGOKBKBAEMNUETWDGCJJ",
                "EYEHGIAWQEOTHYMZFYUZ",
                "HVTPABGUFNUBGYKGNLYS",
                "KXHZJILKNCLASSBFVAXA"
            }
        };

        var sampleTarget = new List<string>
        {
            "cold",
            "snow",
            "red",
            "blue"
        };

        
        //Act
        var result = WordFinder.FindWords(sampleMatrix, sampleTarget);

        //Assert
        Assert.IsTrue(result.WordsFound.Count > 0 );
    }

    [Test]
    public void WordFinderCore_MatrixSymbolError()
    {

        //Arrange
        var sampleMatrix = new CharMatrix
        {
            Rows = new List<string>
            {
                { "!CX" },
                { "XAX" },
                { "XTX" }
            }
        };
        var sampleTarget = new List<string>
        {
            "cat"
        };

        //Act
        var exception = Assert.Throws<ArgumentException>(() => WordFinder.FindWords(sampleMatrix, sampleTarget));

        //Assert
        Assert.That(exception.Message == "Matrix must only contain English word characters");
    }
}