
using double_stroke.projectFolder.StaticFileMaps;

public class Tests
{
    private Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions; 
    private Dictionary<UnicodeCharacter, FrequencyRecord> junda;
    private Dictionary<UnicodeCharacter, FrequencyRecord> tzai;
    
    [SetUp]
    public void Setup()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        
        GenerateFileMaps gen = new GenerateFileMaps();
        var codeExceptionsFromIds = gen.generateCodeExceptionsFromCharacter();
        var codeExceptionsFromCodepoint = gen.generateCodeExceptionsFromCodepoint();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = gen.generateIdsMap(idsPath);
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

    [Test]
    public void IdentifyMissingJundaAndTzaiCharacters()
    {
        GenerateFileMaps gen = new GenerateFileMaps();
        Console.WriteLine("test start");
        //var result1 = foundExceptions[new UnicodeCharacter("扳")];
        Console.WriteLine("next");


        Dictionary<UnicodeCharacter, FrequencyRecord> missingJunda = new Dictionary<UnicodeCharacter, FrequencyRecord>();
        Dictionary<UnicodeCharacter, FrequencyRecord> missingTzai = new Dictionary<UnicodeCharacter, FrequencyRecord>();
        
        foreach (var VARIABLE in junda.Keys)
        {
            if (!foundExceptions.ContainsKey(VARIABLE))
            {
                missingJunda.Add(VARIABLE, junda.GetValueOrDefault(VARIABLE));
            }
        }
        foreach (var VARIABLE in tzai.Keys)
        {
            if (!foundExceptions.ContainsKey(VARIABLE))
            {
                missingTzai.Add(VARIABLE, tzai.GetValueOrDefault(VARIABLE));
            }
        }
        
        //missing junda:
        //裏 3 秊  1
        
        //missing tzai:
        // 兀  119  嗀  11

        var result1 = foundExceptions.GetValueOrDefault(new UnicodeCharacter("裏"));
        var result2 = foundExceptions.GetValueOrDefault(new UnicodeCharacter("秊"));
        var result3 = foundExceptions.GetValueOrDefault(new UnicodeCharacter("兀"));
        var result4 = foundExceptions.GetValueOrDefault(new UnicodeCharacter("嗀"));
        
        Assert.AreEqual(missingJunda.Count, 0);
        Assert.AreEqual(missingTzai.Count, 0);

        Console.WriteLine("test end");
    }
}