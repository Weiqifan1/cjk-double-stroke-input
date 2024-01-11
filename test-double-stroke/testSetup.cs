using test_double_stroke.testExceptions;

namespace test_double_stroke;

using double_stroke.projectFolder.StaticFileMaps;

public class testSetup
{
    
    //TODO: change initials to be a list and ids matches to be a list
    
    protected static Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions;
    protected static  Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptionsFromIds;
    protected static  Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint;
    protected static  Dictionary<UnicodeCharacter, FrequencyRecord> junda;
    protected static  Dictionary<UnicodeCharacter, FrequencyRecord> tzai;
    protected static  ExceptionHelper exceptionHelper = new ExceptionHelper();
    
    [OneTimeSetUp]
    public void Setup()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        
        GenerateFileMaps gen = new GenerateFileMaps();
        CodeExceptions exp = new CodeExceptions();
        codeExceptionsFromIds = exp.generateCodeExceptionsFromCharacter();
        codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
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
    
}