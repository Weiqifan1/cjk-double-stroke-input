// See https://aka.ms/new-console-template for more information

using System;
using double_stroke.projectFolder;

//using double_stroke.projectFolder;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World Chr");
        CreateDeckFileController myClassInstance = new CreateDeckFileController();
        myClassInstance.myFunction();
        Console.WriteLine("end");
    }
}

/*

    [Test]
    public void Test1()
    {
        
        /*
        var codeExceptions = gen.generateCodeExceptions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = gen.generateBasicIdsMap();
        var codepointMap = gen.generateCodepointMap(codeExceptions, idsMap);
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            gen.generateFoundEsceptionsMap(codepointMap, codeExceptions, idsMap);* /
        
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        const string codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";

        GenerateFileMaps gen = new GenerateFileMaps(); 
        var codeExceptions = gen.generateCodeExceptions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = gen.generateIdsMap(idsPath);
        var codepointMap = gen.generateCodepointMap(
            codeExceptions, idsMap, codepointPath);
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            gen.generateFoundEsceptionsMap(codepointMap, codeExceptions, idsMap);
        
        // Test code here
        Assert.Pass();
        
    }
 */