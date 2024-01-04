using double_stroke_input.projectFolder.StaticFileMaps;

namespace test_double_stroke_input.TestStaticFileMaps;

using NUnit.Framework;

public class TestCodeExceptions
{
    [SetUp]
    public void Setup()
    {
        // Setup code here
    }

    [Test]
    public void Test1()
    {
        
        GenerateFileMaps gen = new GenerateFileMaps(); 
        var codeExceptions = gen.generateCodeExceptions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = gen.generateBasicIdsMap();
        var codepointMap = gen.generateCodepointMap(codeExceptions, idsMap);
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            gen.generateFoundEsceptionsMap(codepointMap, codeExceptions, idsMap);
        
        
        // Test code here
        Assert.Pass();
        
    }
}
