using test_double_stroke.testExceptions;

namespace test_double_stroke;

using double_stroke.projectFolder.StaticFileMaps;

public class testSetup
{
    
    //TODO: change initials to be a list and ids matches to be a list

    protected static Dictionary<string, IdsBasicRecord> idsMap;
    protected static Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
    protected static  Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    protected static  Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint;
    protected static  Dictionary<string, FrequencyRecord> junda;
    protected static  Dictionary<string, FrequencyRecord> tzai;
    protected static  ExceptionHelper exceptionHelper = new ExceptionHelper();
    protected static GenerateIds genIds = new GenerateIds();
    
    [OneTimeSetUp]
    public void Setup()
    {
        //find exceptions in the CodeException file new UnicodeCharacter("手")
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, 
            @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, 
            @"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        string newPathForSaveFile = Path.Combine(testDirectory, 
            @"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        
        GenerateIds genIds = new GenerateIds();
        GenerateFileMaps gen = new GenerateFileMaps();
        CodeExceptions exp = new CodeExceptions();
        codeExceptionsFromIds = exp.generateCodeExceptionsFromCharacter();
        codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
        idsMap = genIds.readIdsMap(newPathForSaveFile);
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