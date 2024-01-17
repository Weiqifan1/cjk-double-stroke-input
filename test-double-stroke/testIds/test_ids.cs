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
        
        Assert.AreEqual(69, 5+4, "Result should be 4");
    }
}