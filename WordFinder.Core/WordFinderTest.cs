using WordFinder.Core;

//Simple wrapper for the operations that execute to test the wordfinder service
public static class WordFinderTest
{
    static CharMatrix SAMPLE_MATRIX = new CharMatrix
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

        static List<string> SAMPLE_TARGET = new List<string>
        {
            "cold",
            "snow",
            "red",
            "blue"
        };

    public static void Run()
    {
        WordFinderService wordFinder = new WordFinderService();
        var result = wordFinder.FindWords(SAMPLE_MATRIX, SAMPLE_TARGET);
        Console.Write(result.ToString());
    }
}