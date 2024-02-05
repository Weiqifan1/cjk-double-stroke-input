using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace test_double_stroke.testSchemdictValuesBeforePrint;

public class TestCharacterOrdering
{
    private int jundaFreq5001 = 183;
    private int tzaiFreq5001 = 88;
    
    private static JsonSerializerOptions options = new JsonSerializerOptions();
    private static string testDirectory = TestContext.CurrentContext.TestDirectory;
    private static string charToSchemaPath = Path.Combine(testDirectory,
        @"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
    private static string codeToSchemaPath = Path.Combine(testDirectory,
        @"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\codeToSchemaMap.txt");
    private Dictionary<string, SchemeRecord> charToSchemaDict;
    private Dictionary<string, HashSet<SchemeRecord>> codeToSchemaDich;

    private Dictionary<string, List<SchemeRecord>> simplifiedDictList;
    private Dictionary<string, List<SchemeRecord>> traditionalDictList;
    private List<Dictionary<string, List<SchemeRecord>>> simplifiedListDictList;
    private List<Dictionary<string, List<SchemeRecord>>> traditionalListDictList;
    private List<List<Tuple<string, List<SchemeRecord>>>> simplifiedListListTupples;
    private List<List<Tuple<string, List<SchemeRecord>>>> traditionalListListTupples;
    private List<Tuple<string, SchemeRecord>> simplifiedListTuples;
    private List<Tuple<string, SchemeRecord>> traditionalListTuples;
    private List<string> simplifiedListString;
    private List<string> traditionalListString;

    
    [OneTimeSetUp]
    public void Setup()
    {
        string charToSchemaJson = File.ReadAllText(charToSchemaPath);
        string codeToSchemaJson = File.ReadAllText(codeToSchemaPath);
        
        charToSchemaDict = 
            JsonSerializer.Deserialize<Dictionary<string, SchemeRecord>>(charToSchemaJson, options);
        
        codeToSchemaDich = 
            JsonSerializer.Deserialize<Dictionary<string, HashSet<SchemeRecord>>>(codeToSchemaJson, options);

        simplifiedDictList = createListOfStringReadyForPrint
            .replaceHashSetToList(true, codeToSchemaDich);
        traditionalDictList = createListOfStringReadyForPrint
            .replaceHashSetToList(false, codeToSchemaDich);
        
        simplifiedListDictList = createListOfStringReadyForPrint.splicIntoCodeLengths(simplifiedDictList);
        traditionalListDictList= createListOfStringReadyForPrint.splicIntoCodeLengths(traditionalDictList);

        simplifiedListListTupples = 
            createListOfStringReadyForPrint.getNestedListFromListOfDicts(simplifiedListDictList);
        traditionalListListTupples =
            createListOfStringReadyForPrint.getNestedListFromListOfDicts(traditionalListDictList);

        simplifiedListTuples = createListOfStringReadyForPrint.getSortedListOfTuples(simplifiedListListTupples);
        traditionalListTuples = createListOfStringReadyForPrint.getSortedListOfTuples(traditionalListListTupples);

        simplifiedListString = createListOfStringReadyForPrint.listOfTuplesToStrings(simplifiedListTuples);
        traditionalListString = createListOfStringReadyForPrint.listOfTuplesToStrings(traditionalListTuples);

    }

    /*
    private Dictionary<string, List<SchemeRecord>> simplifiedDictList;
    private Dictionary<string, List<SchemeRecord>> traditionalDictList;
    private List<Dictionary<string, List<SchemeRecord>>> simplifiedListDictList;
    private List<Dictionary<string, List<SchemeRecord>>> traditionalListDictList;
    private List<List<Tuple<string, List<SchemeRecord>>>> simplifiedListListTupples;
    private List<List<Tuple<string, List<SchemeRecord>>>> traditionalListListTupples;
    private List<Tuple<string, SchemeRecord>> simplifiedListTuples;
    private List<Tuple<string, SchemeRecord>> traditionalListTuples;
    private List<string> simplifiedListString;
    private List<string> traditionalListString;
     */
    
    [Test]
    public void testLengthsSimplified()
    {
        var codesWithManyChars = simplifiedDictList.Values.Where(listSch => longlist(listSch)).ToList();

        var number10Junda = codesWithManyChars.Where(listSch => jundaAt10(listSch));//.
            //Select(listTooHigh => listTooHigh[9]).ToList();
        
        string test = "";
    }

    private bool jundaAt10(List<SchemeRecord> listSch)
    {
        if (listSch.Count < 10)
        {
            return false;
        }
        var nr10 = listSch[9];
        var junda = nr10.jundaNumber;
        if (junda.HasValue && junda.Value >= jundaFreq5001)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool longlist(List<SchemeRecord> listSch)
    {
        bool longlist = listSch.Count > 9;

        return longlist;
    }

    
}