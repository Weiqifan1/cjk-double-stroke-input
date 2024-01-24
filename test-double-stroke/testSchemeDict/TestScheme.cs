using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testSchemeDict;

public class TestScheme: testSetup
{
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
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 1);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void handCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "扔");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eyeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "目");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
        
    }
    
    [Test]
    public void eyeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "眤");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void footNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "足");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void footCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "趵");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void insectNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虫");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void insectCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虾");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void treeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "木");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    //朩
    [Test]
    public void treeAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "朩");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void treeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "松");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void bambooNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "竹");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void bambooCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "签");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void goldNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "金");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void goldCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "錯");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eatNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "食");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eatAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飠");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eatCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飼");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void carNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "車");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void carCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "軒");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void threadNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "糸");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void threadCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "絆");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "言");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "訁");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "謬");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void horseNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "馬");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void horseCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "騎");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "門");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𠁣");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "閥");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void noExceptOne()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "丠");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void noExceptionTwo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "甑");
        
        Assert.IsTrue(hand.code4.Count == 1);
        Assert.IsTrue(hand.code4.Contains("s"));
        Assert.IsTrue(hand.code6.Count == 2);
        Assert.IsTrue(hand.code6.Contains("tf"));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.Count == 1);
        Assert.IsTrue(hand.foundExceptionElems.Contains("手"));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
}