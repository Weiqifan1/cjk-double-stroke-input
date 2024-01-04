using double_stroke.projectFolder.StaticFileMaps;

namespace double_stroke.projectFolder;

public class CreateDeckFileController
{
    public void myFunction()
    {
        Console.WriteLine("Hello, this is my function.");
        GenerateFileMaps genJunda = new GenerateFileMaps();
        genJunda.Run();
    }
    
}

/*
 using double_stroke_input.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using double_stroke_input.projectFolder.StaticFileMaps;
using double_stroke_input.projectFolder.YourNamespace;

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

 */