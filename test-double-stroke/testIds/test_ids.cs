using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testIds;

public class test_ids
{
    
    [Test]
    public void handFull_ThatShouldHaveBeenThere()
    {
        //var mydict = foundExceptions;
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        
        //string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");

        //var idsPath = "../../../double-stroke/projectFolder/StaticFiles/ids.txt"; 
        GenerateIds genIds = new GenerateIds();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = genIds.generateIdsMap(idsPath);
        
        //𢺓
        var basic = idsMap.GetValueOrDefault(new UnicodeCharacter("𢺓"));
        Assert.AreEqual(12, basic.rolledOutIdsWithNoShape.Count);
        Assert.AreEqual(new UnicodeCharacter("八"), basic.rolledOutIdsWithNoShape[5]);
        Assert.AreEqual(new UnicodeCharacter("一"), basic.rolledOutIdsWithNoShape[11]);
        
    }
    
    
    
    [Test]
    public void testReadIdsMap()
    {
        //DONT DELETE!
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string newPathForSaveFile = Path.Combine(testDirectory, 
            @"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        GenerateIds genIds = new GenerateIds();
        Dictionary<UnicodeCharacter, IdsBasicRecord>  idsMap = genIds.readIdsMap(newPathForSaveFile);
        
        //𢺓
        var basic = idsMap.GetValueOrDefault(new UnicodeCharacter("𢺓"));
        Assert.AreEqual(12, basic.rolledOutIdsWithNoShape.Count);
        Assert.AreEqual(new UnicodeCharacter("八"), basic.rolledOutIdsWithNoShape[5]);
        Assert.AreEqual(new UnicodeCharacter("一"), basic.rolledOutIdsWithNoShape[11]);
    }
    
    [Test]
    public void generateAndSaveIdsMap()
    {
        //DONT DELETE!
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string newPathForSaveFile = Path.Combine(testDirectory, 
            @"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        GenerateIds genIds = new GenerateIds();
        //cjk-double-stroke-input\double-stroke\projectFolder\GeneratedFiles\idsMap.txt
        //genIds.generateAndSaveIdsMap(idsPath, newPathForSaveFile);
    }
}