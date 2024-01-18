namespace test_double_stroke.testExceptions;

using double_stroke.projectFolder.StaticFileMaps;

public class testMissingCorrectExceptions : testSetup
{
    //TODO: change initials to be a list and ids matches to be a list
    /*
    private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
    private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint;
    private Dictionary<string, FrequencyRecord> junda;
    private Dictionary<string, FrequencyRecord> tzai;
    private ExceptionHelper exceptionHelper = new ExceptionHelper();
    
    [SetUp]
    public void Setup()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        
        GenerateFileMaps gen = new GenerateFileMaps();
        CodeExceptions exp = new CodeExceptions();
        codeExceptionsFromIds = exp.generateCodeExceptionsFromCharacter();
        codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
        Dictionary<string, IdsBasicRecord> idsMap = gen.generateIdsMap(idsPath);
        var codepointMap = gen.generateCodepointMap(
            codeExceptionsFromIds, idsMap, codepointPath);
        foundExceptions = gen.generateFoundEsceptionsMap(codepointMap, codeExceptionsFromIds, codeExceptionsFromCodepoint, idsMap);

        //var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        //var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        
        string jundaPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\Junda2005.txt");
        string tzaiPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\Tzai2006.txt");
        
        junda = gen.generateJundaMap(jundaPath);
        tzai = gen.generateTzaiMap(tzaiPath);
        
    }
*/
    
    [Test]
    public void IdentifyLackOfExceptionsThatShouldHaveBeenThere()
    {
        Console.WriteLine("test start IdentifyLackOfExceptionsThatShouldHaveBeenThere");
        
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        
        Assert.AreEqual(2+2, 4);

        Console.WriteLine("test end IdentifyLackOfExceptionsThatShouldHaveBeenThere");
    }
    
    
    [Test]
    public void testHandFullsize_cardsThatMatchStrokesButNotElement()
    {
        Console.WriteLine("test start TesthandFullSize");
        
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;

        var handFull = 
            exceptionHelper.FiltDict_hasCodeNotIds(foundExceptions, 
                new() {"3112"},
                new() {"手"});

        var finalres = exceptionHelper.displayDict(handFull);

        Assert.AreEqual(2+2, 4);

        Console.WriteLine("test end IdentifyLackOfExceptionsThatShouldHaveBeenThere");
    }
    
    
    
    
    /*
        //s   "手","扌"   "121"
        //d    "目"  "25111"
        //f    "足",  2512134
        //f     "𧾷"   "251(215|2121)";   //251215  2512121
        //j    "虫"  "251214"
        //k    "木","朩"  "1234"
        //l     "竹","⺮","ケ" "314314"

        //t     "金"   "34112431"
        //y    "食","飠"    "34(1|4)(51154|511211)"    
        // "344511211"  "34451154",  "34151154",  "341511211",
        //g     "車"    "1251112"
        //h     "糸"    "(554234|554444)"   "554234"  "554444"
        //v      "言","訁"    "(1|4)111251"     "1111251"    "4111251"
        //b      "馬"    "(12|21)11254444"    "1211254444"   "2111254444"
        //n     "𠁣","𠃛","門"    "25112511"
     */
    
    
    /*
    [Test]
    public void IdentifyDetectedExceptionsThatShouldntBeThere()
    {
        Console.WriteLine("test start");
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        
        Assert.AreEqual(2+2, 4);

        Console.WriteLine("test end");
    }
    
    [Test]
    public void IdentifyExceptionsThatShouldHaveBeenADifferetException()
    {
        Console.WriteLine("test start");
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        
        Assert.AreEqual(2+2, 4);

        Console.WriteLine("test end");
    }*/
    
}