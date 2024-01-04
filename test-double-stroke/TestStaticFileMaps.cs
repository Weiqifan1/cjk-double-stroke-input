
using double_stroke.projectFolder.StaticFileMaps;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        
        
        //var idsPath = "../doule-stroke/projectFolder/StaticFiles/ids.txt";
        //const string codepointPath = "../double-stroke/projectFolder/StaticFiles/codepoint-character-sequence.txt";

        //var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        //const string codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";

        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        
        GenerateFileMaps gen = new GenerateFileMaps();
        var codeExceptions = gen.generateCodeExceptions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = gen.generateIdsMap(idsPath);
        var codepointMap = gen.generateCodepointMap(
            codeExceptions, idsMap, codepointPath);
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            gen.generateFoundEsceptionsMap(codepointMap, codeExceptions, idsMap);
        
        // Test code here
        Assert.True(idsMap.Count > 0);
    }
}