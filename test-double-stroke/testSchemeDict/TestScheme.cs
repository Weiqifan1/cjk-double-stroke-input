using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testSchemeDict;

public class TestScheme: testSetup
{
    //List<string> testStr = new List<string>{"扔", "丠", "甑"};
    
    //  手目足   虫木竹   扔  眤 趵  虾 松 签    丠  甑        
    
    private List<SchemeRecord> schemeRecList;
    
    [OneTimeSetUp]
    public void Setup()
    {
        schemeRecList = generateTestSchemeDict
            .schemeFromDictionary(foundExceptions, junda, tzai);
    }
    
    [Test]
    public void handNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "手");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void handCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "扔");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void eyeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "目");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void eyeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "眤");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void footNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "足");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void footCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "趵");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void insectNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虫");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void insectCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虾");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void treeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "木");
        Assert.AreEqual(2,2);
    }
    
    //朩
    [Test]
    public void treeAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "朩");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void treeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "松");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void bambooNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "竹");
        Assert.AreEqual(2,2);
    }
    
    [Test]
    public void bambooCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "签");
        Assert.AreEqual(2,2);
    }
    
    
    
    [Test]
    public void noExceptOne()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "丠");
        Assert.AreEqual(2,2);
    }

    [Test]
    public void noExceptionTwo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "甑");
        Assert.AreEqual(2,2);
    }
    
    
}