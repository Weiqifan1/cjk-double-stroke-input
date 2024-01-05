
using double_stroke.projectFolder.StaticFileMaps;

public class Tests
{
    private Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions; 
    
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

    }

    [Test]
    public void Test1()
    {
        Console.WriteLine("test start");

        var result1 = foundExceptions[new UnicodeCharacter("扳")];
        
        Console.WriteLine("next");
        
        
        Console.WriteLine("test end");
    }
}